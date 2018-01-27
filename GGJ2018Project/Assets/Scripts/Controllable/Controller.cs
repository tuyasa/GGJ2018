using UnityEngine;

public class Controller : MonoBehaviour
{
	//true if the controlled element is a jumper
	private Rigidbody2D _rgbd;
	public LayerMask ground_layers;
	private Transform _transform;
	private Transform _bioPlacement;
	public float margin;
	

	private void Awake()
	{
		_transform = GetComponent<Transform>();
		_rgbd = GetComponent<Rigidbody2D>();
		_bioPlacement = _transform.Find("BioSpot");
	}
	public bool IsGrounded()
	{
		Collider2D _collider = GetComponent<Collider2D>();
		RaycastHit2D hit = Physics2D.Raycast(_transform.position+Vector3.down*_collider.bounds.extents.y, Vector2.down, margin,ground_layers);
		
		return hit.collider!=null;

	}

	public void Jump(float force)
	{
		_rgbd.AddForce(Vector2.up * force);
	}

	public void Move(Vector2 mouvement)
	{
		_rgbd.velocity = mouvement;
	}


	public void Host(Transform bio)
	{
		bio.SetParent(_bioPlacement);
		bio.transform.position = _bioPlacement.position;
	}

	
	
}
