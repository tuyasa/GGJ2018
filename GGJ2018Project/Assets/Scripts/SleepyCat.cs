using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepyCat : MonoBehaviour
{
	private Character _character;
	private MoveObject2D _mover;
	private Controller2D _controller2;
	private void Awake()
	{
		_character = GetComponent<Character>();
		_mover = GetComponent<MoveObject2D>();
		_controller2 = GetComponent<Controller2D>();
		Invoke("sleep",_mover.time);
		_mover.MoveAlongPath();
		_character._walk = true;
	}

	void sleep()
	{
		_character.fallAsleep();
		_controller2.enabled = false;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
