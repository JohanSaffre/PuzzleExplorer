using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [NonSerialized] private Renderer _renderer;

    [SerializeField] private Material _closedMaterial;
    [SerializeField] private Material _openMaterial;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        GameManager.OnKeyCollected += Activate;
    }

    private void Activate()
    {
        _renderer.sharedMaterial = _openMaterial;
    }
}
