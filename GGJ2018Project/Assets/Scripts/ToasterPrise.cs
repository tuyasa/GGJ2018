using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.Events;

public class ToasterPrise : MonoBehaviour
{
	public GameObject PriseEtat1;
	public GameObject PriseEtat2;
	public UnityEvent triggerEvent;

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.GetComponent<Character> () != null) {
			print ("yolo");
			PriseEtat1.SetActive (false);
			PriseEtat2.SetActive (true);
		}

	}
}
