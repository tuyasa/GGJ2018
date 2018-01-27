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
		handleInput();
	}

	private void handleInput()
	{
		if (Input.GetButtonDown("BioJump"))
		{
			_character.jump();
			
		}
	}
}
