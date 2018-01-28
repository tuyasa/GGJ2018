using UnityEngine;
using UnityEngine.Events;

public class SwitchController : MonoBehaviour
{
	public UnityEvent triggerEvent;
	public bool Activable = false;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(!Activable)
			return;
		Character character = other.gameObject.GetComponent<Character>();
		if (character && character.IsHosting()) 
		{
			triggerEvent.Invoke();
		}
	}

	public void Activate()
	{
		Activable = true;
	}

}
