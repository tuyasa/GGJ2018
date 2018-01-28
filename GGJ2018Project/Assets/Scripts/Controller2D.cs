using UnityEngine;
using System.Collections;

public class Controller2D : RaycastController
{
    public ControllerParameters DefaultParameters;

    public ControllerParameters Parameters
    {
        get { return _overrideParameters ?? DefaultParameters; }
    }


    public float maxSlopeAngle = 80;

    public ControllerState State;
    public Vector2 PlayerInput;

    private Vector2 _velocity;

    public Vector2 Velocity
    {
        get { return _velocity; }
    }

    private bool _gravityActive = true;
    private ControllerParameters _overrideParameters;

    public void AddHorizontalSpeed(float speed)
    {
        _velocity.x += speed;
    }

    public void AddVerticalSpeed(float speed)
    {
        _velocity.y += speed;
    }

    public void SetXVelocity(float x)
    {
        _velocity.x = x;
    }

    public void SetYVelocity(float y)
    {
        _velocity.y = y;
    }

    public void SetForce(Vector2 force)
    {
        _velocity = force;
    }

    void Update()
    {
        ApplyGravity();
        Move(_velocity * Time.deltaTime);

        if (State.above || State.below)
        {
            if (State.slidingDownMaxSlope)
            {
                _velocity.y += State.slopeNormal.y * -Parameters.Gravity * Time.deltaTime;
            }
            else
            {
                _velocity.y = 0;
            }
        }
    }

    public void GravityActive(bool active)
    {
        _gravityActive = active;
    }

    void ApplyGravity()
    {
        if (_gravityActive)
            _velocity.y += Parameters.Gravity * Time.deltaTime;
    }

    public override void Awake()
    {
        base.Awake();
        State = new ControllerState();
    }

    public override void Start()
    {
        base.Start();
        State.faceDir = 1;
    }

    public void Move(Vector2 moveAmount, bool standingOnPlatform = false)
    {
        State.wasGrounded = State.below;
        UpdateRaycastOrigins();

        State.Reset();
        State.moveAmountOld = moveAmount;

        if (moveAmount.y < 0)
        {
            DescendSlope(ref moveAmount);
        }

        if (moveAmount.x != 0)
        {
            State.faceDir = (int) Mathf.Sign(moveAmount.x);
        }

        HorizontalCollisions(ref moveAmount);
        if (moveAmount.y != 0)
        {
            VerticalCollisions(ref moveAmount);
        }

        transform.Translate(moveAmount, Space.World);

        if (standingOnPlatform)
        {
            State.below = true;
        }

        State.justGotGrounded = State.below && !State.wasGrounded;
    }

    void HorizontalCollisions(ref Vector2 moveAmount)
    {
        float directionX = State.faceDir;
        float rayLength = Mathf.Abs(moveAmount.x) + skinWidth;

        if (Mathf.Abs(moveAmount.x) < skinWidth)
        {
            rayLength = 2 * skinWidth;
        }

        for (int i = 0; i < horizontalRayCount; i++)
        {
            Vector2 rayOrigin = (directionX == -1) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
            rayOrigin += Vector2.up * (horizontalRaySpacing * i);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, collisionMask);

            Debug.DrawRay(rayOrigin, Vector2.right * directionX, Color.red);

            if (hit)
            {
                if (hit.distance == 0)
                {
                    continue;
                }

                float slopeAngle = Vector2.Angle(hit.normal, Vector2.up);

                if (i == 0 && slopeAngle <= maxSlopeAngle)
                {
                    if (State.descendingSlope)
                    {
                        State.descendingSlope = false;
                        moveAmount = State.moveAmountOld;
                    }

                    float distanceToSlopeStart = 0;
                    if (slopeAngle != State.slopeAngleOld)
                    {
                        distanceToSlopeStart = hit.distance - skinWidth;
                        moveAmount.x -= distanceToSlopeStart * directionX;
                    }

                    ClimbSlope(ref moveAmount, slopeAngle, hit.normal);
                    moveAmount.x += distanceToSlopeStart * directionX;
                }

                if (!State.climbingSlope || slopeAngle > maxSlopeAngle)
                {
                    moveAmount.x = (hit.distance - skinWidth) * directionX;
                    rayLength = hit.distance;

                    if (State.climbingSlope)
                    {
                        moveAmount.y = Mathf.Tan(State.slopeAngle * Mathf.Deg2Rad) * Mathf.Abs(moveAmount.x);
                    }

                    State.left = directionX == -1;
                    State.right = directionX == 1;
                }
            }
        }
    }

    void VerticalCollisions(ref Vector2 moveAmount)
    {
        float directionY = Mathf.Sign(moveAmount.y);
        float rayLength = Mathf.Abs(moveAmount.y) + skinWidth;

        for (int i = 0; i < verticalRayCount; i++)
        {
            Vector2 rayOrigin = (directionY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
            rayOrigin += Vector2.right * (verticalRaySpacing * i + moveAmount.x);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, collisionMask);

            Debug.DrawRay(rayOrigin, Vector2.up * directionY, Color.red);

            if (hit)
            {
                if (hit.collider.tag == "Through")
                {
                    if (directionY == 1 || hit.distance == 0)
                    {
                        continue;
                    }

                    if (State.fallingThroughPlatform)
                    {
                        continue;
                    }

                    if (PlayerInput.y == -1)
                    {
                        State.fallingThroughPlatform = true;
                        Invoke("ResetFallingThroughPlatform", .5f);
                        continue;
                    }
                }

                moveAmount.y = (hit.distance - skinWidth) * directionY;
                rayLength = hit.distance;

                if (State.climbingSlope)
                {
                    moveAmount.x = moveAmount.y / Mathf.Tan(State.slopeAngle * Mathf.Deg2Rad) *
                                   Mathf.Sign(moveAmount.x);
                }

                State.below = directionY == -1;
                State.above = directionY == 1;
            }
        }

        if (State.climbingSlope)
        {
            float directionX = Mathf.Sign(moveAmount.x);
            rayLength = Mathf.Abs(moveAmount.x) + skinWidth;
            Vector2 rayOrigin = ((directionX == -1) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight) +
                                Vector2.up * moveAmount.y;
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, collisionMask);

            if (hit)
            {
                float slopeAngle = Vector2.Angle(hit.normal, Vector2.up);
                if (slopeAngle != State.slopeAngle)
                {
                    moveAmount.x = (hit.distance - skinWidth) * directionX;
                    State.slopeAngle = slopeAngle;
                    State.slopeNormal = hit.normal;
                }
            }
        }
    }

    void ClimbSlope(ref Vector2 moveAmount, float slopeAngle, Vector2 slopeNormal)
    {
        float moveDistance = Mathf.Abs(moveAmount.x);
        float climbmoveAmountY = Mathf.Sin(slopeAngle * Mathf.Deg2Rad) * moveDistance;

        if (moveAmount.y <= climbmoveAmountY)
        {
            moveAmount.y = climbmoveAmountY;
            moveAmount.x = Mathf.Cos(slopeAngle * Mathf.Deg2Rad) * moveDistance * Mathf.Sign(moveAmount.x);
            State.below = true;
            State.climbingSlope = true;
            State.slopeAngle = slopeAngle;
            State.slopeNormal = slopeNormal;
        }
    }

    void DescendSlope(ref Vector2 moveAmount)
    {
        RaycastHit2D maxSlopeHitLeft = Physics2D.Raycast(raycastOrigins.bottomLeft, Vector2.down,
            Mathf.Abs(moveAmount.y) + skinWidth, collisionMask);
        RaycastHit2D maxSlopeHitRight = Physics2D.Raycast(raycastOrigins.bottomRight, Vector2.down,
            Mathf.Abs(moveAmount.y) + skinWidth, collisionMask);
        if (maxSlopeHitLeft ^ maxSlopeHitRight)
        {
            SlideDownMaxSlope(maxSlopeHitLeft, ref moveAmount);
            SlideDownMaxSlope(maxSlopeHitRight, ref moveAmount);
        }

        if (!State.slidingDownMaxSlope)
        {
            float directionX = Mathf.Sign(moveAmount.x);
            Vector2 rayOrigin = (directionX == -1) ? raycastOrigins.bottomRight : raycastOrigins.bottomLeft;
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, -Vector2.up, Mathf.Infinity, collisionMask);

            if (hit)
            {
                float slopeAngle = Vector2.Angle(hit.normal, Vector2.up);
                if (slopeAngle != 0 && slopeAngle <= maxSlopeAngle)
                {
                    if (Mathf.Sign(hit.normal.x) == directionX)
                    {
                        if (hit.distance - skinWidth <= Mathf.Tan(slopeAngle * Mathf.Deg2Rad) * Mathf.Abs(moveAmount.x))
                        {
                            float moveDistance = Mathf.Abs(moveAmount.x);
                            float descendmoveAmountY = Mathf.Sin(slopeAngle * Mathf.Deg2Rad) * moveDistance;
                            moveAmount.x = Mathf.Cos(slopeAngle * Mathf.Deg2Rad) * moveDistance *
                                           Mathf.Sign(moveAmount.x);
                            moveAmount.y -= descendmoveAmountY;

                            State.slopeAngle = slopeAngle;
                            State.descendingSlope = true;
                            State.below = true;
                            State.slopeNormal = hit.normal;
                        }
                    }
                }
            }
        }
    }

    void SlideDownMaxSlope(RaycastHit2D hit, ref Vector2 moveAmount)
    {
        if (hit)
        {
            float slopeAngle = Vector2.Angle(hit.normal, Vector2.up);
            if (slopeAngle > maxSlopeAngle)
            {
                moveAmount.x = Mathf.Sign(hit.normal.x) * (Mathf.Abs(moveAmount.y) - hit.distance) /
                               Mathf.Tan(slopeAngle * Mathf.Deg2Rad);

                State.slopeAngle = slopeAngle;
                State.slidingDownMaxSlope = true;
                State.slopeNormal = hit.normal;
            }
        }
    }

    void ResetFallingThroughPlatform()
    {
        State.fallingThroughPlatform = false;
    }
}