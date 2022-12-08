using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action<int> OnDirectionPressed;
    public static event Action OnKeyCollected;

    public static bool IsKeyCollected { get; private set; }

    [SerializeField] private GameObject _key;

    // Start is called before the first frame update
    void Start()
    {
        IsKeyCollected = false;
    }

    public static void PickUpKey(GameObject key)
    {
        OnKeyCollected?.Invoke();
        IsKeyCollected = true;
        Destroy(key);
    }
}
