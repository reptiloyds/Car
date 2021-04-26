using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCountUpdater : MonoBehaviour
{
    public static CubeCountUpdater Instance { get; private set; }
    public event Action CountUpdate;
    private void Awake()
    {
        Instance = this;
    }
    public void OnCountUpdate()
    {
        CountUpdate?.Invoke();
    }
}
