﻿using UnityEngine;

[System.Serializable]
public class ControllerState
{
    public bool above, below;
    public bool left, right;
    public bool wasGrounded;
    public bool justGotGrounded;

    public bool climbingSlope;
    public bool descendingSlope;
    public bool slidingDownMaxSlope;

    public float slopeAngle, slopeAngleOld;
    public Vector2 slopeNormal;
    public Vector2 moveAmountOld;
    public int faceDir;
    public bool fallingThroughPlatform;

    public void Reset()
    {
        above = below = false;
        left = right = false;
        justGotGrounded = false;
        climbingSlope = false;
        descendingSlope = false;
        slidingDownMaxSlope = false;
        slopeNormal = Vector2.zero;

        slopeAngleOld = slopeAngle;
        slopeAngle = 0;
    }
}