
using System;
using System.Diagnostics;
using UnityEngine;

public class Controller : MonoBehaviour
{
	//true if the controlled element is a jumper
	public bool jumper= false;
	//movement speed for horizontal movement 

	//set the jump force if a jumper.
	
	
	//next possible jump 



	private void Awake()
	{
		
	}

	// Use this for initialization
	void Start ()
	{

	}
	
	
	private void FixedUpdate()
	{
		
		
//		Vector2 rigidMovement  = new Vector2(hMove,vMove);
//
//		_rgbd.MovePosition(_rgbd.position+rigidMovement );
//
//		if ( Time.time > nextJumpTime )
//		{
//			
//			float jump = Inputs.GetAxis("BioJump")*jumpForce;
//			nextJumpTime = Time.time + jump_cooldown;
//			_rgbd.AddForce(new Vector2(0,jump),ForceMode2D.Impulse);
//
//		}
		
	}

	public bool grounded()
	{
		throw new NotImplementedException();
	}

	public void jump()
	{
		throw new NotImplementedException();
	}

	public void move()
	{
		
	}
}
