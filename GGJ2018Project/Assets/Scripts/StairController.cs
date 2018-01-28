using UnityEngine;

public class StairController : MonoBehaviour
{

	public NetworkNode toasterNode;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool CheckEndLevel1Conditions(Collider2D other)
	{
		if (other.tag.Equals("Human") && NetworkManager.Instance.currentNode.Equals(toasterNode))
			return true;
		return false;
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (CheckEndLevel1Conditions(other))
		{
			LevelManager.Instance.ChangeSceneTo(1);
		}
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if (CheckEndLevel1Conditions(other))
		{
			LevelManager.Instance.ChangeSceneTo(1);
		}
	}
}
