using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
	public float speed;

	public float jumpForce;
	
	private float _nextJump;
	private Controller _controller;

	private void Awake()
	{
		_controller = GetComponent<Controller>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void jump()
	{
		if (_controller.grounded())
		{
			_controller.jump();
		}
		
	}
}
