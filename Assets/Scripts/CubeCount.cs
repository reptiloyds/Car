using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CubeCount : MonoBehaviour
{
    private TextMeshProUGUI _textMesh;
    private int _value;
    private void Start()
    {
        _textMesh = GetComponent<TextMeshProUGUI>();
        _value = 0;
        _textMesh.text = _value.ToString();
        CubeCountUpdater.Instance.CountUpdate += OnCountUpdate;
    }

    private void OnCountUpdate()
    {
        _value++;
        _textMesh.text = _value.ToString();
    }
    private void OnDestroy()
    {
        CubeCountUpdater.Instance.CountUpdate -= OnCountUpdate;
    }
}
