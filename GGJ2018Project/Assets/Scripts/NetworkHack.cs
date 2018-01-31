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
	public GameObject LinkToRepair;

    public SwitchSpriteController SwitchSpriteController;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void ReActivateLink()
	{
        SwitchSpriteController.SwitchSprite();

        switch (pair.TargetNetworkDirection)
		{
			case NetworkDirection.Up:
				pair.Source.TargetNodeUp = pair.Destination;
				pair.Destination.TargetNodeDown = pair.Source;
				LinkToRepair.SetActive(false);
				break;
			case NetworkDirection.Down:
				pair.Source.TargetNodeDown = pair.Destination;
				pair.Destination.TargetNodeUp = pair.Source;
				LinkToRepair.SetActive(false);
				break;
			case NetworkDirection.Left:
				pair.Source.TargetNodeLeft = pair.Destination;
				pair.Destination.TargetNodeRight = pair.Source;
				LinkToRepair.SetActive(false);
				break;
			case NetworkDirection.Right:
				pair.Source.TargetNodeRight = pair.Destination;
				pair.Destination.TargetNodeLeft = pair.Source;
				LinkToRepair.SetActive(false);
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
		
	}
}
