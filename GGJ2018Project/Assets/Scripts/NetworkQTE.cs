using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkQTE : MonoBehaviour
{
	public List<NetworkHack.NetworkDirection> qte;
	public Sprite DisplayQTE;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Sprite ConvertQTEToSprite(NetworkHack.NetworkDirection direction)
	{
		switch (direction)
		{
			case NetworkHack.NetworkDirection.Up:
				return NetworkManager.Instance.UpSprite;
			case NetworkHack.NetworkDirection.Down:
				return NetworkManager.Instance.DownSprite;
			case NetworkHack.NetworkDirection.Left:
				return NetworkManager.Instance.LeftSprite;
			case NetworkHack.NetworkDirection.Right:
				return NetworkManager.Instance.RightSprite;
			default:
				return null;
		}
	}

	IEnumerator QTETime()
	{
		
		yield return null;
	}
	
	
}
