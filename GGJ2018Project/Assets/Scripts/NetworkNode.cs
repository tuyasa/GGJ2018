﻿using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

public class NetworkNode : MonoBehaviour
{
    public NetworkNode TargetNodeLeft;
    public NetworkNode TargetNodeRight;
    public NetworkNode TargetNodeUp;
    public NetworkNode TargetNodeDown;
    public GameObject VoltPlaceHolder;
    public UnityEvent ActivePowerEvent;

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
        {
            NetworkManager.Instance.currentNode = TargetNodeLeft;
            MoveVolt(TargetNodeLeft);
        }           
    }

    public void SwitchNodeRight()
    {
        if (TargetNodeRight)
        {
            NetworkManager.Instance.currentNode = TargetNodeRight;
            MoveVolt(TargetNodeRight);
        }    
    }

    public void SwitchNodeUp()
    {
        if (TargetNodeUp)
        {
            NetworkManager.Instance.currentNode = TargetNodeUp;
            MoveVolt(TargetNodeUp);
        }            
    }

    public void SwitchNodeDown()
    {
        if (TargetNodeDown)
        {
            NetworkManager.Instance.currentNode = TargetNodeDown;
            MoveVolt(TargetNodeDown);
        }   
    }

    public void MoveVolt(NetworkNode node)
    {
        NetworkManager.Instance.Volt.transform.position = node.VoltPlaceHolder.transform.position;
    }

    public void ActivePower()
    {
        ActivePowerEvent.Invoke();
    }
    
    // activate other node avec qte
    // activate fonctionnalité avec qte
    
}