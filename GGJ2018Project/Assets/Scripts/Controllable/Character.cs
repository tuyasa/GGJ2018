using UnityEngine;

public class Character : MonoBehaviour {
	public float speed;
	public CharacterType type=CharacterType.Flyer;
	public float jumpForce;
	
	private float _nextJump;
	private Controller _controller;

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
		if (type.Equals(CharacterType.Jumper)&& _controller.IsGrounded())
		{
			_controller.Jump(jumpForce*10);
		}
		
	}

	public void Move(float hMove, float vMove)
	{
		if (type.Equals(CharacterType.Jumper))
		{
			vMove = 0;
		}

		Vector2 velocity = new Vector2(hMove * speed, vMove * speed);
		_controller.Move(velocity);
	}
}

public enum CharacterType
{
	Flyer,
	Jumper
}