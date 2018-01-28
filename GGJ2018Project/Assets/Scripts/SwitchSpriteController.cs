using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SwitchSpriteController : MonoBehaviour
{
	public Sprite []newSprites;
	public SpriteRenderer _spriteRenderer;
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
		Debug.Log(newSprites.Length);
		
		Debug.Log("switch sprite");
		_spriteRenderer.sprite = newSprites[index];
		index++;
	}
}
