
﻿using UnityEngine;
using UnityEngine.Events;

public class SwitchController : MonoBehaviour
{
	public UnityEvent triggerEvent;

	public int Counter = 1;
	private void OnTriggerEnter2D(Collider2D other)
	{
		Character character = other.gameObject.GetComponent<Character>();
		if (character && character.IsHosting() && Counter>0) 
		{
			triggerEvent.Invoke();
			Counter -= 1;
		}
	}

}
