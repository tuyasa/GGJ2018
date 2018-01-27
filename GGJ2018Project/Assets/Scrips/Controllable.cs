
using System;
using System.Diagnostics;
using UnityEngine;

public class Controllable : MonoBehaviour
{
	//true if the controlled element is a jumper
	public bool jumper= false;
	//movement speed for horizontal movement 
	public float speed;
	//set the jump force if a jumper.
	public float jumpForce;
	
	private float _hSpeed;
	private float _vSpeed;
	//next possible jump 
	private float nextJumpTime = 0;

	private float jump_cooldown = 1;
	
	// Use this for initialization
	void Start ()
	{
		_hSpeed = _vSpeed = speed;
		if (jumper)
		{
			Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
			rigidbody2D.gravityScale = 1;
			_vSpeed = 0;
		}	
	}
	
	
	private void FixedUpdate()
	{
		
		Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
		float hMove= Input.GetAxis("BioHorizontal")*_hSpeed;
		float vMove= Input.GetAxis("BioVertical")*_vSpeed;
		float jump = 0;
		if (Time.time > nextJumpTime)
		{
			vMove += Input.GetAxis("BioJump")*jumpForce;
			nextJumpTime = Time.time + jump_cooldown;
		}

		Vector2 rigidbodyVelocity = new Vector2(hMove,vMove);
		//rigidbody.velocity = rigidbodyVelocity;
		rigidbody.AddForce(new Vector2(0,vMove),ForceMode2D.Impulse);
		}
}
