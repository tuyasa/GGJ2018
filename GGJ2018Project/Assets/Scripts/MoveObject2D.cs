using System.Collections;
using UnityEngine;

public class MoveObject2D : MonoBehaviour
{
	public Transform destination;
	public float time;

	public bool PingPong;
	// Use this for initialization
	private void Awake()
	{
//		Invoke("MoveAlongPath", 1f);
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MoveAlongPath()
	{
		StartCoroutine(MoveAlongPathCor(this.destination));
	}

	IEnumerator MoveAlongPathCor(Transform destination)
	{
		float t = 0f;
		Vector2 startPosition = transform.position;
		while (t <= time)
		{
			transform.position = Vector2.Lerp(startPosition, destination.position, t / time);
			t += Time.deltaTime;
			yield return null;
		}
		
	}
	
	public void MoveAlongPathPoint(Transform point)
	{
		StartCoroutine(MoveAlongPathCor(point));
	}
}
