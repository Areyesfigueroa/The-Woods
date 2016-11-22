using UnityEngine;
using System.Collections;

public class PowerUpPickUp : MonoBehaviour {

    [Header("Lenght of the final position")]
    public float destination;
    Vector2 endPos;
    [Header("Time it takes until destination")]
    public float timeTakenDuringLerp = 1;

    Vector2 startPos;
    float timeStartedLerping;
	// Use this for initialization
	void Start ()
    {
        startPos = transform.position;
        endPos = new Vector2(transform.position.x, destination);
        timeStartedLerping = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Animation();
        Debug.DrawLine(startPos, endPos, Color.blue);
	}

    void Animation()
    {
        float timeSinceStarted = Time.time - timeStartedLerping;
        float percentageComplete = (timeSinceStarted / timeTakenDuringLerp);

        //goes up and down
        transform.position = Vector2.Lerp(startPos, endPos, Mathf.PingPong(percentageComplete, 1f));
    }

    void OnCollisionEnter(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Call Pick up AudioEvent
            Destroy(this);
        }
    }
}
