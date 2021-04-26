using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventAggregattor : MonoBehaviour
{
    public event Action Finish;
    public static EventAggregattor Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    public void OnFinish()
    {
        Finish?.Invoke();
    }
}
