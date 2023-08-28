using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParent : MonoBehaviour
{
    public static PlayerParent Instance;

    private void Awake()
    {
        Instance = this;

        
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
