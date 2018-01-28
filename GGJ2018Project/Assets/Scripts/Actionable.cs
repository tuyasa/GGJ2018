using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Actionable : MonoBehaviour
{
	public UnityEvent events;
	// Use this for initialization
	void Start () {
		
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		var Character = other.gameObject.GetComponent<Character>();
		if (Character && Character.IsHosting() && Input.GetMouseButtonDown(0))
		{
			events.Invoke();
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
