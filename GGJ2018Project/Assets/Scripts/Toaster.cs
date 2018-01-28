using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toaster : MonoBehaviour
{
	public GameObject toasterSmoke;
	public GameObject toasterHeat;

	public SwitchSpriteController SwitchSpriteController;
	public MoveObject2D human;
	public int state = 0;
	// Use this for initialization

	private void Awake()
	{
		toasterHeat.SetActive(false);
		toasterSmoke.SetActive(false);
	}

	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Activate()
	{
		state++;
		if (state == 1)
		{
			StateOne();
		}else if (state == 2)
		{
			StateTwo();
		}else if (state == 0)
		{
			
		}
	}

	public void StateOne()
	{
		toasterHeat.SetActive(true);
		SwitchSpriteController.SwitchSprite();
	}

	public void StateTwo()
	{
		toasterSmoke.SetActive(true);
		SwitchSpriteController.SwitchSprite();
		
	}

	public void StateZero()
	{
		toasterHeat.SetActive(false);
		toasterSmoke.SetActive(false);
	}
	
	
}
