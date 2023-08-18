using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEditorInternal;
using UnityEngine;

public class TestingGameManager : NetworkBehaviour
{
    public static TestingGameManager Instance { get; private set; }

    public event EventHandler OnLocalPlayerReadyChanged;

    private bool isLocalPlayerReady;
    private Dictionary<ulong, bool> playerReadyDictionary;




    private void Awake()
    {
        playerReadyDictionary = new Dictionary<ulong, bool>();
    }


    private void GameInput_OnInteractAction(object sender, EventArgs e)
    {
        isLocalPlayerReady = true;
        OnLocalPlayerReadyChanged?.Invoke(this, EventArgs.Empty);
    }


    public bool IsLocalPlayerReady()
    {
        return isLocalPlayerReady;
    }
}
