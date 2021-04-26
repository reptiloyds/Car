using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _distanceToCube;
    private CubeState _state;
    private void Awake()
    {
        _distanceToCube = 12;
        _state = CubeState.OnRoad;
    }
    private void Update()
    {
        if (transform.position.y < -1 && _state == CubeState.OnRoad)
        {
            CubeCountUpdater.Instance.OnCountUpdate();
            _state = CubeState.ThrownOut;
        }
    }
    private void OnMouseDrag()
    {
        var distanceToCar = (Car.Instance.transform.position - transform.position).magnitude;
        if (distanceToCar <= 20f)
        {
            var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _distanceToCube);
            var objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objectPosition;
        }
    }
}
enum CubeState
{
    OnRoad,
    ThrownOut
}
