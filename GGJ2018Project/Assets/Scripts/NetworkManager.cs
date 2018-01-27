using Managers;
using UnityEngine;

public class NetworkManager : PersistentSingleton<NetworkManager>
{
	public NetworkNode currentNode;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		HandleNetworkInput();
	}
	void HandleNetworkInput()
	{
		if (Input.GetButtonDown("Up"))
		{
			currentNode.SwitchNodeUp();
		}else if (Input.GetButtonDown("Down"))
		{
			currentNode.SwitchNodeDown();
		}else if (Input.GetButtonDown("Left"))
		{
			currentNode.SwitchNodeLeft();
		}else if (Input.GetButtonDown("Right"))
		{
			currentNode.SwitchNodeRight();
		}
	}
	
}
