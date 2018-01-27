using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BioController: MonoBehaviour {
	private Transform _transform;

	private void Awake()
	{
		_transform = GetComponent<Transform>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		var character = other.gameObject.GetComponent<Character>();
		if (!character) return;
		character.SetInHostingRange(true);
		character.SetBio(_transform);
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		var character = other.gameObject.GetComponent<Character>();
		if (!character) return;
		character.SetInHostingRange(false);
		character.SetBio(null);
	}
}
