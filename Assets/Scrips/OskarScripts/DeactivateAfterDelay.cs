using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateAfterDelay : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("DeactivateObject", 1f);
    }

    private void DeactivateObject()
    {
        gameObject.SetActive(false);
    }
}