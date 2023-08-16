using UnityEngine;
using UnityEngine.UI;

public class ClickableImageToggle : MonoBehaviour
{
    private Image image;
    private bool isChecked = false;

    private GameManager gameManager;

    private void Start()
    {
        image = GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);

        gameManager = FindObjectOfType<GameManager>();
    }

    public void ToggleImageVisibility()
    {
        isChecked = !isChecked;
        image.color = new Color(image.color.r, image.color.g, image.color.b, isChecked ? 1f : 0f);

        // Notify the GameManager about the character's toggle state
        gameManager.CharacterToggled(isChecked);
    }
}