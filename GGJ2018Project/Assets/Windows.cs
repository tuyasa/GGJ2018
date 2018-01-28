using Managers;
using UnityEngine;
using UnityEngine.Events;

public class Windows : MonoBehaviour
{
	public AudioClip AudioClip;
	public UnityEvent UnityEvent;
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
			Debug.Log("command event");
			UnityEvent.Invoke();
			SoundManager.Instance.PlaySoundSFX(AudioClip);
		}
	}
}
