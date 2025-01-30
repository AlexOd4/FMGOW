using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.Rendering;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class BallHandler : MonoBehaviour
{
    //Reference to the pivot rigidbody component
    [SerializeField] private Rigidbody2D pivot;
    //Reference to the ball prefab
    [SerializeField] GameObject ballPrefab;

    [SerializeField] private float detachDelay;
    [SerializeField] private float respawnDelay;
    

    //The rigidbody of the current spawned ball
    private Rigidbody2D currentBallRigidbody;
    
    private SpringJoint2D currentBallSpringJoint;

   
    private bool isDragging;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //spawn the first ball when the game starts
        SpawnNewBall();
    }

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        //if there is no current ball, exit the method
        if (currentBallRigidbody == null) { return; }

        //if I am not touching the screen
        //if (!Touchscreen.current.primaryTouch.press.isPressed)
        //check if there are no active touches
        if (Touch.activeTouches.Count == 0)
        {
            //if the ball was being dragged, launch it
            if (isDragging) 
            {
                LaunchBall();
            }

            //reset the dragging state
            isDragging = false;

            //currentBallRigidbody.bodyType = RigidbodyType2D.Dynamic;
            //dont do anything
            return;
        }
        
        //*** fisrt time the player touch the screen
        //mark the ball kinematic to allow manual movement
        currentBallRigidbody.bodyType = RigidbodyType2D.Kinematic;

        //mark the ball as being dragged
        isDragging = true;

        //Get the first active touch
        //Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        Vector2 touchPosition = new Vector2();

        foreach (Touch touch in Touch.activeTouches) 
        {
            touchPosition += touch.screenPosition; // Sum up the positions of all touches
        }

        //Get the average position of all touches
        touchPosition /= Touch.activeTouches.Count;

        //convert the touch position to the unity world space
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);

        //Debug.Log("World Position = " + worldPosition);
        //Debug.Log("Screen Position = " + touchPosition);

        //Update the ball's position to follow the touch
        currentBallRigidbody.position = worldPosition;
        
    }

    /// <summary>
    /// Spawn a new ball and attach it to the pivot using SpringJoint2D
    /// </summary>
    private void SpawnNewBall()
    {
        //Instantiate a new ball prefab at the pivot's position
        GameObject ballInstance = Instantiate(ballPrefab, pivot.position, Quaternion.identity);

        //Set the current rigidbody to the newly created instance
        currentBallRigidbody = ballInstance.GetComponent<Rigidbody2D>();

        //Set the springjoint from the newly created instance
        currentBallSpringJoint = ballInstance.GetComponent<SpringJoint2D>();
        
        //attach the spring joint of the ball to the pivot
        currentBallSpringJoint.connectedBody = pivot;



    }

    private void LaunchBall()
    {
        //make the ball dynamic so it reacts to physics
        currentBallRigidbody.bodyType = RigidbodyType2D.Dynamic;

        //clear the reference to the current's ball rigidbody
        currentBallRigidbody = null;

        //Schedule the ball's detachment after a delay
        Invoke(nameof(DetachBall), detachDelay);
    }

    private void DetachBall()
    {
        //Disable the sprint joint to disconnect the ball from the pivot
        currentBallSpringJoint.enabled = false;

        //Clear the reference to the current ball's springjoint2D
        currentBallSpringJoint = null;

        Invoke(nameof(SpawnNewBall), respawnDelay);

        JesusCLevelManager.Instance.UpdateBallUI();

    }
}
