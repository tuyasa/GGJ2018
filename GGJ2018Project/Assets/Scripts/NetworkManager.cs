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
		if (Input.GetButtonDown("VoltUp"))
		{
			currentNode.SwitchNodeUp();
		}else if (Input.GetButtonDown("VoltDown"))
		{
			currentNode.SwitchNodeDown();
		}else if (Input.GetButtonDown("VoltLeft"))
		{
			currentNode.SwitchNodeLeft();
		}else if (Input.GetButtonDown("VoltRight"))
		{
			currentNode.SwitchNodeRight();
		}
	}
	
}
