using UnityEngine;
using System.Collections;

public class EnemyAiV2 : MonoBehaviour {

    #region Data
    //Timer
    [Space(5)]
    [Header("Choose When To Delay: ")]
    [Tooltip("Triggers right delay")]
    public bool triggerRightPosDelay = false; //Lets me know which check to toggle
    public bool triggerLeftPosDelay = false;
    private bool checkLeft = false; //toggles on and off to make sure you only check for max reach once
    private bool checkRight = false;


    [Space(5)]
    [Header("Input how long is the delay: ")]
    public float rightPosDelay = 0;
    public float leftPosDelay = 0;

    private float timeSinceEnded = 0;

    //Calculate movement left to right
    [Space(5)]
    [Header("Input the time it takes to reach left and right corners")]
    [Tooltip("How fast should the enemy reach its destination")]
    public float timeTakenDuringLerp = 1f; //time it takes to get from one place to another
    [Space(5)]
    [Header("Input the distance the enemy will move")]
    [Tooltip("Distance value the enemy will travel")]
    public float distance = 2;

    private bool isLerpingRight;
    private bool isLerpingLeft;
    public bool canMove = true;
    bool isGrounded = false;
    //testing
    bool runOnce = false;

    Vector2 startPos;
    Vector2 endPos;

    //testing
    private float offSetRightTimer = 0;

    private float timeStartedLerping;
    #endregion
    void Start()
    {
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

    #region Timer Delays
    //Delay time for when you reach maxLeft or maxRight
    IEnumerator Delay(float delay)
    {
        Debug.Log("Coroutine Start: ");
        yield return new WaitForSeconds(delay);
        Debug.Log("Coroutine End: ");
    }

    #endregion

    void Movement()
    {
        if (isLerpingRight) //Going Right
        {
            float timeSinceStarted = Time.time - timeStartedLerping; //This subtraction means it will start from the point where you leave it on when you start lerp = Start lerp when I decide.
            float percentageComplete = (timeSinceStarted / timeTakenDuringLerp); //calculate the ammount it takes to reach your destination over a period of time.

            transform.position = Vector2.Lerp(startPos, new Vector2(endPos.x + distance, endPos.y), percentageComplete);

            if (startPos.x >= (endPos.x + distance) - .1f)
            {
                Debug.Log("Reached Max Position");
            }
        }

        if (isLerpingLeft) //going left
        {
            float timeSinceStarted = Time.time - timeStartedLerping; //This subtraction means it will start from the point where you leave it on when you start lerp = Start lerp when I decide.
            float percentageComplete = (timeSinceStarted / timeTakenDuringLerp); //calculate the ammount it takes to reach your destination over a period of time.

            transform.position = Vector2.Lerp(startPos, new Vector2(endPos.x + distance, endPos.y), percentageComplete);
        }
    }

    //Lerping init
    void StartLerpingRight()
    {
        isLerpingRight = true;
        timeStartedLerping = Time.time;

        startPos = transform.position; //anywhere
        endPos = transform.position; //Distance will dynamically determine its ending position
    }

    void StartLerpingLeft()
    {
        isLerpingLeft = true;
        timeStartedLerping = Time.time;

        startPos = endPos;
        endPos = startPos;
    }


    //check if we are grounded
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 11) //Ground
        {
            StartLerpingRight();
            isGrounded = true;
        }
    }
    #endregion
}
