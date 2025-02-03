using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.Rendering;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class BallHandler : MonoBehaviour
{

    //Reference to the pivot rigidbody component
    [SerializeField] private Rigidbody2D pivot; 
    //Reference to the ball prefab
    [SerializeField] GameObject ballPrefab;
    [SerializeField] Transform ballTransform;
    [SerializeField] Rigidbody2D lrPivotRb;
    
    [SerializeField] GameObject pivotPrefab;

    [SerializeField] private float detachDelay;
    [SerializeField] private float spawnPivotTime;


    //The rigidbody of the current spawned ball
    [SerializeField] private Rigidbody2D currentBallRigidbody;

    [SerializeField] private SpringJoint2D currentBallSpringJoint;

    [SerializeField] private LineRenderer lr;

    private float velocityToStop = 0.1f;

    private bool isDragging;
    private bool pivotCreated;
    private bool isMoving;
    private bool isKinematic;
    
    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    private void Start()
    {
        isMoving = false;
        currentBallRigidbody = ballPrefab.GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
       

       //if there is no current ball , exit the method
        if (currentBallRigidbody == null) { return; }

        //if (currentBallRigidbody.linearVelocity.magnitude < 0.2f)
        //{
        //    currentBallRigidbody.linearVelocity = Vector2.zero;
        //   isMoving = false;
        //}
        //if (Mathf.Approximately(currentBallRigidbody.linearVelocity.y, 0) && Mathf.Approximately(currentBallRigidbody.linearVelocity.x, 0) && isDragging)
        //{
        //    Invoke(nameof(AttachPivot), spawnPivotTime);

        //}

        if(currentBallRigidbody.linearVelocity.magnitude > velocityToStop)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
            
        }
        
        

        if (!isMoving)
        {
            HandleTouchInput();

            if (LevelManager.main.outofShoots && currentBallRigidbody.linearVelocity.magnitude <= 0.1f && !LevelManager.main.levelCompleted)
            {
                LevelManager.main.GameOver();
            }

            if (currentBallRigidbody.bodyType == RigidbodyType2D.Kinematic )
            {
                AttachPivot();
            }
            
        }
       
        
        
    }
    

    void HandleTouchInput()
    {
        //If I am not touching the screen
        //if (!Touchscreen.current.primaryTouch.press.isPressed)
        //check if there are no active touches
        if (Touch.activeTouches.Count == 0)
        {
            lr.positionCount = 2;

            //if the ball was being dragged , launch it
            if (isDragging)
            {
                LaunchBall();


            }

            //reset the dragging state
            isDragging = false;

            //dont do anything
            return;
        }

       lrPivotRb.bodyType = RigidbodyType2D.Static;

        //first time the player touch the screen
        //mark the ball kinematic to allow manual movement
        currentBallRigidbody.bodyType = RigidbodyType2D.Kinematic;

        //mark the ball as being dragged
        isDragging = true;

        //Get the first active touch
        //Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        Vector2 touchPosition = new Vector2();

        //iterate through all active touches
        foreach (Touch touch in Touch.activeTouches)
        {
            touchPosition += touch.screenPosition; //Sum up th positions of all touches
        }

        //Get the average position of all touches 
        touchPosition /= Touch.activeTouches.Count;

        //convert the touch position to the unity world space
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);

        if (currentBallSpringJoint.connectedBody != null)
        {
            currentBallSpringJoint.enabled = true;
        }


        //Update the ball's position to follow the touch
        currentBallRigidbody.position = worldPosition;

        lr.positionCount = 2;
        lr.SetPosition(0, lrPivotRb.transform.position);
        lr.SetPosition(1, ballTransform.position);
    }

    private void SpawnPivot()
    {
        GameObject pivotInstance = Instantiate(pivotPrefab, ballPrefab.transform.position, Quaternion.identity);
    }

    private void LaunchBall()
    {
        //make the ball dynamic so it reacts to physics
        currentBallRigidbody.bodyType = RigidbodyType2D.Dynamic;

        ////clear the reference to the current's ball rigidbody
        //currentBallRigidbody = null;

        //Schedule the ball's detachment after a delay
        Invoke(nameof(DetachBall), detachDelay);

       pivotCreated = false;
        isMoving = true;
        LevelManager.main.IncreaseShoot();
    }

    private void DetachBall()
    {
        lrPivotRb.bodyType = RigidbodyType2D.Kinematic;
        //Disable the spring joint to disconnect the ball from the pivot
        currentBallSpringJoint.enabled = false;

       currentBallSpringJoint.connectedBody = null;

       pivotPrefab.SetActive(false);
       lr.positionCount = 0;   
       
    }

   
    private void AttachPivot()
    {
        Debug.Log("Hola");

        if(pivotPrefab != null && !pivotCreated)
        {
            
            GameObject pivotInstance = Instantiate(pivotPrefab, ballTransform.position, Quaternion.identity);

            //attach the spring joint of the ball to the pivot
            currentBallSpringJoint.connectedBody = pivotInstance.GetComponent<Rigidbody2D>();
            pivotInstance.SetActive(true);

            pivotCreated = true;
            currentBallSpringJoint.enabled = true;

           lrPivotRb.transform.position = ballPrefab.transform.position;
        }




    }


}
