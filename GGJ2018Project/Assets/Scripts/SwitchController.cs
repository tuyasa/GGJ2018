
﻿using UnityEngine;
using UnityEngine.Events;

public class SwitchController : MonoBehaviour
{
	public bool Activate = false;
	public UnityEvent triggerEvent;

//	public int Counter = 1;
//	private void OnTriggerEnter2D(Collider2D other)
//	{
//		Character character = other.gameObject.GetComponent<Character>();
//		if (character && character.IsHosting() && Counter>0) 
//		{
//			triggerEvent.Invoke();
//			Counter -= 1;
//		}
//	}
	

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (Activate && other.gameObject.GetComponent<Character>() != null)
		{	
			triggerEvent.Invoke();
		}
	}


	public void ActivateTriggerAble()
	{
		Activate = true;
	}

}
