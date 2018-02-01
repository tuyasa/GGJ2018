using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class Toaster : MonoBehaviour
{
	public GameObject toasterSmoke;
	public GameObject toasterHeat;

	public SwitchSpriteController SwitchSpriteController;
	public MoveObject2D human;
	public int state = 0;
	
	public AudioClip toasting;
    public AudioClip poppingBread;
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
			
			SoundManager.Instance.PlaySoundSFX(poppingBread);
			StateOne();
		}else if (state == 2)
		{
            SoundManager.Instance.PlaySoundSFX(toasting);
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
        toasterHeat.SetActive(false);
        toasterSmoke.SetActive(true);
		SwitchSpriteController.SwitchSprite();
		human.MoveAlongPath();
		Character character = human.GetComponent<Character>();
		character._walk = true;
		Invoke("ResetStateAction", human.time);
	}

	public void StateZero()
	{
		toasterHeat.SetActive(false);
		toasterSmoke.SetActive(false);
	}

	public void ResetStateAction()
	{
		Character character = human.GetComponent<Character>();
		character._walk = true;
	}
	
	
	
}
