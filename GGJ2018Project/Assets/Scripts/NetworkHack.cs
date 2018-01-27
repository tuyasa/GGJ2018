using System;
using UnityEngine;

public class NetworkHack : MonoBehaviour
{
	public enum NetworkDirection
	{
		Up,
		Down,
		Left,
		Right
	}
	
	[Serializable]
	public class NetworkNodePair
	{
		public NetworkNode Source;
		public NetworkNode Destination;
		public NetworkDirection TargetNetworkDirection;
	}
	
	public NetworkNodePair pair;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A))
		{
			ActivateLink();
		}
	}

	public void ActivateLink()
	{
		switch (pair.TargetNetworkDirection)
		{
			case NetworkDirection.Up:
				pair.Source.TargetNodeUp = pair.Destination;
				break;
			case NetworkDirection.Down:
				pair.Source.TargetNodeDown = pair.Destination;
				break;
			case NetworkDirection.Left:
				pair.Source.TargetNodeLeft = pair.Destination;
				break;
			case NetworkDirection.Right:
				pair.Source.TargetNodeRight = pair.Destination;
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
		
	}
}
