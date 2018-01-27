using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inputs : MonoBehaviour
{
	private float hMove;
	private float vMove;
	private Character _character;
	private Collider2D _collider;
	private void Awake()
	{
		_character = GetComponent<Character>();
		_collider = GetComponent<Collider2D>();
	}

	
	
	// Update is called once per frame
	void Update () {
		
		HandleInput();
	}

	public void OnMouseDown()
	{
		Debug.Log(name);
		_character.Host();
	}

	private void HandleInput()
	{
		if (Input.GetButton("BioJump"))
		{
			_character.Jump();
				
		}
/*
		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("clock");
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if(_collider.OverlapPoint(mousePosition))_character.Host();
		}
		*/
		
		_character.Move(Input.GetAxis("BioHorizontal"), Input.GetAxis("BioVertical"));
		
		 
	}
}
