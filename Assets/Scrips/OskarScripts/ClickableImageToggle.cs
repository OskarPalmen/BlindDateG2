using UnityEngine;
using UnityEngine.UI;

public class ClickableImageToggle : MonoBehaviour
{
    private Image image;
    private bool isChecked = false;

    public bool IsChecked => isChecked;

    private GameManager gameManager;

    private void Start()
    {
        image = GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);

        gameManager = FindObjectOfType<GameManager>();
    }

    public void OnCharacterClicked()
    {
        if (gameManager.IsGuessMode)
        {
            gameManager.CharacterClicked(this);
        }
        else
        {
            ToggleImageVisibility();
        }
    }

    public void ToggleImageVisibility()
    {
        isChecked = !isChecked;
        image.color = new Color(image.color.r, image.color.g, image.color.b, isChecked ? 1f : 0f);

        gameManager.UpdateGuessButton();
    }
}