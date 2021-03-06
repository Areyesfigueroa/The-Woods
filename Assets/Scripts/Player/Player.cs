﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour {

    [Space(5)]
    [Header("Player Jump Settings")]
    public float jumpHeight = 4;
    public float timeToApex = .4f; //how long should the character take before he reacher the max height
    float accelerationTimeAirborne;
    float accelerationTimeGrounded;
	[Space(5)]
	[Header("Player Move Settings")]
    public float moveSpeed= 6;

    #region Jump physics formula
    /*
    Known: jumpHeight, timeToJumpApex
    Solve: gravity, jumpVelocity

     //Formula given for jump movement over time
    deltaMovement = velocityInitial * time + (acceleration * time^2/2)
    
    //Code revision formula
    jumpHeight = ((gravity * timeToJumpApex^2)/2)
    2 * jumpHeight = gravity * (timeToApex^2)
    gravity/2*jumpHeight = 1/timeToJumpApex^2
        
    //Formula given for final jump velocity
    velocityFinal = velocityInitial + acceleration * time

    //Code revision formula
    jumpVelocity = gravity * timeToApex
     */
    #endregion
    private float gravity = -20;
	public float Gravity
	{
		get{ return gravity;}
		set{gravity = value; }
	}
    float jumpVelocity;
    Vector3 velocity;
	public Vector3 Velocity
	{
		get{return velocity; }
		set{velocity = value; }
	}
    float velocityXSmoothing;

    Controller2D controller;

	// Use this for initialization
	void Start () {
        controller = GetComponent<Controller2D>();
        gravity = (-2 * jumpHeight) / Mathf.Pow(timeToApex, 2);
        jumpVelocity = Mathf.Abs(gravity * timeToApex);
        print("Gravity: " + gravity + "Jump Velocity: " + jumpVelocity);
	}

	public bool isJumpApex() //Not done
	{
		Debug.Log ("Velocity.y" + velocity.y + "Combined: " + velocity.y );

		if (velocity.y == (velocity.y + jumpHeight)) {
			Debug.Log ("Max Jump" + jumpHeight + "Velocity y:" + velocity.y);
			return true;
		} else {
			return false;
		}
	}

    void Update()
    {
        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }
		Debug.Log ("Y velocity: " +velocity.y);
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown(KeyCode.Space) && controller.collisions.below)
        {
            velocity.y = jumpVelocity;
        }

        float targetVelocityX = input.x * moveSpeed; //smooth movement on x axis
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded:accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);  
    }
}
