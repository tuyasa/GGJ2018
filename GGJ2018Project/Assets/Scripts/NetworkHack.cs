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
		
	}

	public void ActivateLink()
	{
		switch (pair.TargetNetworkDirection)
		{
			case NetworkDirection.Up:
				pair.Source.TargetNodeUp = pair.Destination;
				pair.Destination.TargetNodeDown = pair.Source;
				break;
			case NetworkDirection.Down:
				pair.Source.TargetNodeDown = pair.Destination;
				pair.Destination.TargetNodeUp = pair.Source;
				break;
			case NetworkDirection.Left:
				pair.Source.TargetNodeLeft = pair.Destination;
				pair.Destination.TargetNodeRight = pair.Source;
				break;
			case NetworkDirection.Right:
				pair.Source.TargetNodeRight = pair.Destination;
				pair.Destination.TargetNodeLeft = pair.Source;
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
		
	}
}
