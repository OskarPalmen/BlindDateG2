using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickableImageToggle : MonoBehaviour
{
    private Image image;
    private bool isVisible = false;

    private void Start()
    {
        image = GetComponent<Image>();
        // Initially set the image transparent.
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
    }

    public void ToggleImageVisibility()
    {
        isVisible = !isVisible;
        // Toggle image visibility based on the isVisible flag.
        image.color = new Color(image.color.r, image.color.g, image.color.b, isVisible ? 1f : 0f);
    }
}
