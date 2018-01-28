using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public GameObject Cat;
    private Character _character;
    private SwitchSpriteController _switch;
    private void Awake()
    {
        _character = GetComponent<Character>();
        _switch = GetComponent<SwitchSpriteController>();
    }

    public void Capture()
    {
        _character.Host();
        _switch.SwitchSprite();
        Destroy(Cat);
    }
}
