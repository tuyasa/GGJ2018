using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Lamp : MonoBehaviour
{
	public SwitchSpriteController SwitchSpriteController;

	public UnityEvent FreeButterfly;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CheckWindowOpen()
	{
		if (SwitchSpriteController.index == 0)
			SceneManager.LoadScene(1);
		else
		{
			FreeButterfly.Invoke();
		}
	}
}
