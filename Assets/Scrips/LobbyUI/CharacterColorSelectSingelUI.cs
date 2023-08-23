using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterColorSelectSingelUI : MonoBehaviour
{
    [SerializeField] private int colorId;
    [SerializeField] private Image image;
    [SerializeField] private GameObject selectedGameObject;



    private void Start()
    {
        image.color = TestingGameManager.Instance.GetPlayerColor(colorId);
        UpdatedIsSelected();
    }

    private void UpdatedIsSelected()
    {
        if(TestingGameManager.Instance.GetPlayerData().colorId == colorId)
        {
            selectedGameObject.SetActive(true);
        }
        else 
        { 
            selectedGameObject.SetActive(false); 
        }
    }
}
