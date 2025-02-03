using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.Rendering;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class GolfBall : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D ballRb;
    [SerializeField] private LineRenderer lr;
    [SerializeField] private AudioSource golfSwingAudio;

    [Header("Attributes")]
    [SerializeField] private float mxPower = 10f;
    [SerializeField] private float power = 2f;
    [SerializeField] private float mxGoalSpeed = 4f;
    [SerializeField] private GameObject goalFx;

    private bool isDragging;
    private bool inHole;

    private void Update()
    {
        PlayerInput();

        if(LevelManager.main.outofShoots && ballRb.linearVelocity.magnitude <= 0.1f && !LevelManager.main.levelCompleted)
        {
            LevelManager.main.GameOver();
        }
    }

    private bool IsReady()
    {
        return ballRb.linearVelocity.magnitude <= 0.1f;
    }

    private void PlayerInput()
    {
        if (!IsReady())
        {
            return;
        }

        Vector2 touchPosition = new Vector2();

        foreach (Touch touch in Touch.activeTouches)
        {
            touchPosition += touch.screenPosition; //Sum up th positions of all touches
        }

        Vector2 inputPos = Camera.main.ScreenToWorldPoint(touchPosition);
        float distance = Vector2.Distance(transform.position, inputPos);


        if (Touchscreen.current.primaryTouch.press.isPressed && distance <= 0.5f) 
        { 
            DragStart();
        }
        if (Touchscreen.current.primaryTouch.press.isPressed && isDragging) 
        {
            DragChange(inputPos);  
        }
        if (Touchscreen.current.primaryTouch.press.isPressed == false && isDragging) 
        {
            DragRelease(inputPos);  
        } 

   
    }

    private void DragStart()
    {
        isDragging = true;
        lr.positionCount = 2;
    }
    private void DragChange(Vector2 pos)
    {
        Vector2 dir = (Vector2)transform.position - pos;
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, (Vector2)transform.position + Vector2.ClampMagnitude((dir * power) / 2, mxPower / 2));
    }
    private void DragRelease(Vector2 pos)
    {
        float distance = Vector2.Distance((Vector2)transform.position, pos);
        isDragging = false;
        lr.positionCount = 0;

        if(distance < .2f)
        {
            return;
        }

        LevelManager.main.IncreaseShoot();

        Vector2 dir = (Vector2)transform.position - pos;

        ballRb.linearVelocity = Vector2.ClampMagnitude(dir * power, mxPower);

        golfSwingAudio.Play();
    }

    private void CheckWinState()
    {
        if(inHole)return;

        if(ballRb.linearVelocity.magnitude <= mxGoalSpeed)
        {
            inHole = true;

            ballRb.linearVelocity = Vector2.zero;
            gameObject.SetActive(false);

            GameObject fx = Instantiate(goalFx, transform.position, Quaternion.identity);
            Destroy(fx,2f);

            LevelManager.main.LevelComplete();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Goal") CheckWinState();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag =="Goal")CheckWinState();
    }
}
