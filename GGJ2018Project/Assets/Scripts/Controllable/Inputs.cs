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

	
	
	// Update is called once per frame
	void Update () {
		HandleInput();
	}

	public void OnMouseDown()
	{
			Debug.Log("Clicked");
		_character.Host();
	}

	private void HandleInput()
	{
		if (Input.GetButtonDown("Fire1"))
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
		
		_character.SetInput(Input.GetAxis("BioHorizontal"), Input.GetAxis("BioVertical"));
		
		 
	}
}
