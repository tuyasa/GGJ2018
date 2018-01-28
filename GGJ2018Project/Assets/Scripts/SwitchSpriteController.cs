using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SwitchSpriteController : MonoBehaviour
{
	public Sprite []newSprites;
	private SpriteRenderer _spriteRenderer;
	public int index;

	private void Awake()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SwitchSprite()
	{
		if (index < newSprites.Length)
		{
			_spriteRenderer.sprite = newSprites[index];
			index++;
			Debug.Log("switch sprite");
		}
		
		
	}
}
