using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class MoveObject2D : MonoBehaviour
{
	public Transform destination;
	public float time;
	// Use this for initialization
	private void Awake()
	{
		Invoke("MoveAlongPath", 1f);
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MoveAlongPath()
	{
		StartCoroutine(MoveAlongPathCor());
	}

	IEnumerator MoveAlongPathCor()
	{
		float t = 0f;
		Vector2 startPosition = transform.position;
		while (t <= time)
		{
			transform.position = Vector2.Lerp(startPosition, destination.position, t);
			t += Time.deltaTime;
			yield return null;
		}
	}
}
