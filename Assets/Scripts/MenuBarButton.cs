using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBarButton : MonoBehaviour
{
    [SerializeField]
    private Button button;

    private Sprite pressed;
    private Sprite unpressed;

    private void Start()
    {
        pressed = button.spriteState.pressedSprite;
        unpressed = button.image.sprite;
    }

    public void ToggleButtonPressed()
    {
        button.image.sprite = pressed;
    }

    public void ToggleButtonUnpressed()
    {
        button.image.sprite = unpressed;
    }
}
