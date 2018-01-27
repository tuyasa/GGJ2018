using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchController : MonoBehaviour
{
	public UnityEvent triggerEvent;

	private void OnTriggerEnter2D(Collider2D other)
	{
	
	
		Debug.Log("triggered");
		Character character = other.gameObject.GetComponent<Character>();
		if (character && character.IsHosting()) 
		{
			triggerEvent.Invoke();
		}
	}

}
