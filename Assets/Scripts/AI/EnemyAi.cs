using UnityEngine;
using System.Collections;

public class EnemyAi : MonoBehaviour {


    //Timer
    [Space(5)]
    [Header("Choose When To Delay: ")]
    [Tooltip("Triggers right delay")]
    public bool triggerRightPosDelay = false;
    public bool triggerLeftPosDelay = false;

    [Space(5)]
    [Header("Input how long is the delay: ")]
    public float rightPosDelay = 0;
    public float leftPosDelay = 0;

    private float passingTime = 0;
    private const float leftTimeOffset = .8f;
    private const float rightTimeOffset = .3f;
    private float finalDelay;

    //Calculate movement left to right
    [Space(5)]
    [Header("Input the time it takes to reach left and right corners")]
    [Tooltip("How fast should the enemy reach its destination")]
    public float timeTakenDuringLerp = 1f; //time it takes to get from one place to another
    [Space(5)]
    [Header("Input the distance the enemy will move")]
    [Tooltip("Distance value the enemy will travel")]
    public float distance = 2;

    private bool isLerping;
    public bool canMove = true;
    bool isGrounded = false;
    bool runOnce = true;

    Vector2 startPos;
    Vector2 endPos;

    Rigidbody2D rb;

    private float timeStartedLerping;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        if (isGrounded && canMove)
        {
            Movement();
            Debug.DrawLine(startPos, new Vector2(endPos.x + distance, endPos.y), Color.red);
        }
    }


    #region Game Functions

    void RightPosDelay()
    {
        if (runOnce)
        { 
            finalDelay = rightPosDelay + Time.time;
            runOnce = false;
        }
        else if (Time.time >= finalDelay)
        {
            isLerping = true;
            runOnce = true;
            passingTime = Time.time + rightTimeOffset; //reset// time offset
        }
    }

    void LeftPosDelay()
    {
        if (runOnce)
        {
            finalDelay = leftPosDelay + Time.time;
            runOnce = false;
        }
        else if (Time.time >= finalDelay)
        {
            isLerping = true;
            runOnce = true;
            passingTime = Time.time - leftTimeOffset; //reset// time offset
            Debug.Log("PassingTime Left: " + passingTime);
        }
    }


    void Movement()
    {
        if (isLerping)
        {
            float timeSinceStarted = passingTime - (Time.time - timeStartedLerping);
            Debug.Log("timeSinceStarted: " + timeSinceStarted);
            float percentageComplete = (timeSinceStarted / timeTakenDuringLerp);


            transform.position = Vector2.Lerp(startPos, new Vector2(endPos.x + distance, endPos.y), Mathf.PingPong(percentageComplete, 1f));
            Debug.Log(Mathf.PingPong(percentageComplete, 1f));
            if (Mathf.PingPong(percentageComplete, 1f) >= .9f && triggerRightPosDelay) //check right first// this is stopping the delay. Starting from where 1 left off 
            {
                Debug.Log("Max Right Delay");
                //stop player movement
                isLerping = false;
            }
            else if (Mathf.PingPong(percentageComplete, 1f) <= 0.1f && triggerLeftPosDelay) //this is stopping the delay. Starting from where 0 left off
            {
                Debug.Log("Max Left Delay");
                //stop player movement
                isLerping = false;
            }
        }
        else if (triggerRightPosDelay) //if you are on ground and you press one delay or both delays
        {
            RightPosDelay();
        }
        else if (triggerLeftPosDelay)
        {
            LeftPosDelay();
        }
    }

    //Lerping init
    void StartLerping()
    {
        isLerping = true;
        timeStartedLerping = Time.time;

        startPos = transform.position;
        endPos =  transform.position;
    }


    //check if we are grounded
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 11) //Ground
        {
            StartLerping();
            isGrounded = true;
        }
    }
    #endregion

}
