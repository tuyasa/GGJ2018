using UnityEngine;

public class NetworkNode : MonoBehaviour
{
    public NetworkNode TargetNodeLeft;
    public NetworkNode TargetNodeRight;
    public NetworkNode TargetNodeUp;
    public NetworkNode TargetNodeDown;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SwitchNodeLeft()
    {
        if (TargetNodeLeft)
            NetworkManager.Instance.currentNode = TargetNodeLeft;
    }

    public void SwitchNodeRight()
    {
        if (TargetNodeRight)
            NetworkManager.Instance.currentNode = TargetNodeRight;
    }

    public void SwitchNodeUp()
    {
        if (TargetNodeUp)
            NetworkManager.Instance.currentNode = TargetNodeUp;
    }

    public void SwitchNodeDown()
    {
        if (TargetNodeDown)
            NetworkManager.Instance.currentNode = TargetNodeDown;
    }
}