using Managers;
using UnityEngine;

public class NetworkManager : PersistentSingleton<NetworkManager>
{
	public NetworkNode currentNode;
	public Volt Volt;
	public Sprite UpSprite;

	public Sprite DownSprite;

	public Sprite LeftSprite;

	public Sprite RightSprite;

	public bool IsFree = false;

	public PlasmaBowl PlasmaBowl;

    public AudioClip ZapSound;
    public AudioClip PlasmaBallSound;

    private void Awake()
	{
		Volt.transform.position = currentNode.VoltPlaceHolder.transform.position;

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (IsFree)
        {
            HandleNetworkInput();
        }
			
    }
	
	void HandleNetworkInput()
	{
		if (Input.GetButtonDown("VoltUp"))
		{
			currentNode.SwitchNodeUp();
            playZapSound();
        }

        else if (Input.GetButtonDown("VoltDown"))
		{
			currentNode.SwitchNodeDown();
            playZapSound();
        }

        else if (Input.GetButtonDown("VoltLeft"))
		{
			currentNode.SwitchNodeLeft();
            playZapSound();
        }

        else if (Input.GetButtonDown("VoltRight"))
		{
			currentNode.SwitchNodeRight();
            playZapSound();
        }

		if (Input.GetButtonDown("VoltActivate"))
		{
			currentNode.ActivePower();
        }
    }

	public void FreeVolt()
	{
		Volt.GetComponent<SpriteRenderer>().enabled = true;
		currentNode.SwitchNodeDown();
		IsFree = true;
		PlasmaBowl.Disable();
    }

    public void playZapSound()
    {
        if (ZapSound)
        {
            SoundManager.Instance.PlaySoundSFX(ZapSound);
        }
    }
}
