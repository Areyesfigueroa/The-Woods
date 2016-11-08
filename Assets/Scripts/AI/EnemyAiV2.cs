using UnityEngine;
using System.Collections;

public class EnemyAiV2 : MonoBehaviour {

    [Space(5)]
    [Header("Movement")]
    public float posDistance = 0.2f;
    public float posSpeed = 1;
    public bool canMove = true;

    private Vector3 startPos, leftPos, rightPos;

    // Use this for initialization
    void Awake()
    {
        startPos = transform.position;

        //left and right start pos
        leftPos = startPos;
        rightPos = startPos;
    }
    void Start()
    {
        leftPos.x = startPos.x + posDistance; //will give coordinates to the left position
        rightPos.x = startPos.x - posDistance; //rightPos coordinates
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            horizontalMovement();
        }
    }

    //left and right
    void horizontalMovement()
    {
        //This will move the passenger left and right 
        //make conditions for when he reaches its destination and returns back to his orignal position and so on.
        transform.position = Vector3.Lerp(leftPos, rightPos, Mathf.PingPong(Time.time * posSpeed, 1.0f));
    }
}
