using UnityEngine;

[System.Serializable]
public class ControllerParameters
{
    public float AccelerationTimeAirborne = .2f;

    public float AccelerationTimeGrounded = .1f;

    // class responsible for all the physics stuff that happenned to our player
    public float Gravity = -50f;

    public Vector2 MaxVelocity = new Vector2(100f, 100f);

    public float MaximumeSlopeAngle = 60f;
}