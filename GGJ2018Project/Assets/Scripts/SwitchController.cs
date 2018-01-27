using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchController : MonoBehaviour
{
	public UnityEvent triggerEvent;

	public Collider2D triggerArea;

	private void OnTriggerEnter(Collider other)
	{
		Character character = other.gameObject.GetComponent<Character>();
		if (character && character.IsHosting()) 
		{
			triggerEvent.Invoke();
		}
	}

	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
}
