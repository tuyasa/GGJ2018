using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inputs : MonoBehaviour
{
	private float hMove;
	private float vMove;
	private Character _character;
	private void Awake()
	{
		_character = GetComponent<Character>();
		
	}

	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () {
		HandleInput();
	}

	private void HandleInput()
	{
		if (Input.GetButton("BioJump"))
		{
			_character.Jump();
			
		}
			_character.Move(Input.GetAxis("BioHorizontal"), Input.GetAxis("BioVertical"));
		 
	}
}
