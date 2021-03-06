﻿using Managers;
using UnityEngine;
using UnityEngine.Events;

public class Windows : MonoBehaviour
{
	public AudioClip AudioClip;
	public UnityEvent UnityEvent;
	public SwitchSpriteController LampSwitchSpriteController;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag.Equals("Human"))
		{
			Character character = other.GetComponent<Character>();
			character._action = true;
			// lamp activate
			if (LampSwitchSpriteController.index == 0)
			{
				UnityEvent.Invoke();
				SoundManager.Instance.PlaySoundSFX(AudioClip);
			}
			else
			{
				LevelManager.Instance.ChangeSceneTo(0);
			}
			
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag.Equals("Human"))
		{
			Debug.Log("command event");
			Character character = other.GetComponent<Character>();
			character._action = false;
		}
	}
}
