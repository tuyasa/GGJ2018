using UnityEngine;

public class Character : MonoBehaviour {
	public float speed;
	public CharacterType type=CharacterType.Flyer;
	public float jumpForce;
	public bool host = true;
	private bool _isHosting = false;
	private float _nextJump;
	private Controller _controller;
	private bool _inHostingRange;
	private Transform _bio;
	
	private void Awake()
	{
		_controller = GetComponent<Controller>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Jump()
	{
		
		if (_isHosting && type.Equals(CharacterType.Jumper)&& _controller.IsGrounded() )
		{
			_controller.Jump(jumpForce*10);
		}
		
	}

	public void Move(float hMove, float vMove)
	{
		if (!_isHosting) return;
		if (type.Equals(CharacterType.Jumper))
		{
			vMove = 0;
		}

		Vector2 velocity = new Vector2(hMove * speed, vMove * speed);
		_controller.Move(velocity);
	}

	public void Host()
	{
		if (this._inHostingRange)
		{

			var oldCharacter = _bio.GetComponentInParent<Character>();
			
			if(oldCharacter)
			{
				oldCharacter.BioOut();
			}

			_controller.Host(_bio);
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
	
}

public enum CharacterType
{
	Flyer,
	Jumper
}