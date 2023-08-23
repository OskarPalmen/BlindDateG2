using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    // add stuff to make the visual for the character

    [SerializeField] private MeshRenderer hatMeshRenderer;
    [SerializeField] private MeshRenderer hairMeshRenderer;
    [SerializeField] private MeshRenderer faceMeshRenderer;
    [SerializeField] private MeshRenderer mouthMeshRenderer;

    private Material material;

    private void Awake()
    {
        material = new Material(hatMeshRenderer.material);
        hatMeshRenderer.material = material;
        hairMeshRenderer.material = material;
        faceMeshRenderer.material = material;
        mouthMeshRenderer.material = material;
    }

    public void SetPlayerColor(Color color)
    {
        material.color = color;
    }

}
