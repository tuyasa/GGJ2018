using Managers;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class Character : MonoBehaviour {
	public float xSpeed;
	public float ySpeed;
	public CharacterType type = CharacterType.Flyer;
	public float jumpForce;

	private bool _isHosting = false;
	private float _nextJump;
	private Controller2D _controller;
	public bool _inHostingRange;
	public Transform _bio;

	public bool grounded;
	private Vector2 velocity;

	private SpriteRenderer characterSprite;
	
	private Transform _transform;
	public Transform _bioPlacement;
	private float _normalizedHorizontalSpeed;
	private float _normalizedVerticalSpeed;
	public bool IsFacingRight;
	private float velocityXSmoothing;
	private float velocityYSmoothing;
	
	public bool CantMove;

	public bool _idle;
	public bool _walk;
	public bool _action;

	public bool HasIdle;
	public bool HasWalk;
	public bool HasAction;

	private Animator _animator;
	public AudioClip controlSFX;
	public AudioClip jumpSFX;

	private void Awake()
	{
		_controller = GetComponent<Controller2D>();
		_transform = GetComponent<Transform>();
		
		_bioPlacement = _transform.Find("BioSpot");
		Debug.Log(_bioPlacement);
//		IsFacingRight = false;
		_animator = GetComponent<Animator>();
		characterSprite = GetComponent<SpriteRenderer>();
	}

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		UpdateAnimator();
	}

	public void Jump()
	{
		if (_isHosting && type.Equals(CharacterType.Jumper) && _controller.State.below)
		{
			
			_controller.SetYVelocity(jumpForce);
			if (jumpSFX)
			{
				SoundManager.Instance.PlaySoundSFX(jumpSFX);
			}
		}
		
	}

	void UpdateAnimator()
	{
		if(HasIdle)
			_animator.SetBool("idle", _idle);
		if(HasWalk)
			_animator.SetBool("walk", _walk);
		if(HasAction)
			_animator.SetBool("action", _action);
	}

	public void SetInput(float hMove, float vMove)
	{
		if(!_isHosting || CantMove)
			return;
		HandleHorizontalMovement(hMove);
		if (!type.Equals(CharacterType.Jumper))
		{
			HandleVerticalMovement(vMove);
		}
	}

	public void HandleHorizontalMovement(float _horizontalMovement)
	{
		if (_horizontalMovement > 0.1f)
		{
			_normalizedHorizontalSpeed = _horizontalMovement;
			if (!IsFacingRight)
				Flip();
			_walk = true;
			_idle = false;
		}
		else if (_horizontalMovement < -0.1f)
		{
			_normalizedHorizontalSpeed = _horizontalMovement;
			if (IsFacingRight)
				Flip();
			_walk = true;
			_idle = false;
		}
		else
		{
			_normalizedHorizontalSpeed = 0;
			_idle = true;
			_walk = false;
		}
		
		float targetVelocityX = _normalizedHorizontalSpeed * xSpeed;
		float movementFactor = _controller.State.below
			? _controller.Parameters.AccelerationTimeGrounded
			: _controller.Parameters.AccelerationTimeAirborne;

		
		float newHorizontalForce =
			Mathf.SmoothDamp(_controller.Velocity.x, targetVelocityX, ref velocityXSmoothing, movementFactor);

		_controller.SetXVelocity(newHorizontalForce);

	}

	public void HandleVerticalMovement(float vMove)
	{
		if (vMove > 0.1f)
		{
			_normalizedVerticalSpeed = vMove;
		}
		else if (vMove < -0.1f)
		{
			_normalizedVerticalSpeed = vMove;
		}
		else
		{
			_normalizedVerticalSpeed = 0;
		}
		
		
		float targetVelocityY = _normalizedVerticalSpeed * ySpeed;
		float newVerticalForce =
			Mathf.SmoothDamp(_controller.Velocity.y, targetVelocityY, ref velocityYSmoothing, 0.3f);
		_controller.SetYVelocity(newVerticalForce);
	}

	public void Host()
	{
		if (_inHostingRange)
		{
			var oldCharacter = _bio.GetComponentInParent<Character>();
			
			if(oldCharacter)
			{
				oldCharacter.BioOut();
			}

			if (controlSFX)
			{
				SoundManager.Instance.PlaySoundSFX(controlSFX);
			}
			_bio.SetParent(_bioPlacement);
			_bio.transform.position = _bioPlacement.position;
			this._isHosting = true;
		}

	}

	private void BioOut()
	{
		this._isHosting = false;
		this.SetBio(null);
	}


	public void SetInHostingRange(bool isIn)
	{
		_inHostingRange = isIn;
	}

	public void SetBio(Transform bio)
	{
		_bio = bio;
	}

	public bool IsHosting()
	{
		return _isHosting;
	}

	public void Flip()
	{
		IsFacingRight = !IsFacingRight;
		characterSprite.flipX = IsFacingRight;
	}
}

public enum CharacterType
{
	Flyer,
	Jumper,
	NoJumper
}