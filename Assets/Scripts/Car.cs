using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _direction;
    private CarState _state;
    [SerializeField]
    private float _speed;
    public static Car Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        _rigidbody = GetComponent<Rigidbody>();
        _state = CarState.Drived;
        _direction = -Vector3.right * _speed * Time.deltaTime;
    }
    private void Start()
    {
        EventAggregattor.Instance.Finish += OnFinish;
    }

    private void OnFinish()
    {
        _state = CarState.Stopped;
    }

    private void FixedUpdate()
    {
        if(_state == CarState.Drived)
        {
            _rigidbody.velocity = _direction;
        }
        else
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Cube>() != null)
        {
            _state = CarState.Stopped;
        }
    }
    private void OnDestroy()
    {
        EventAggregattor.Instance.Finish -= OnFinish;
    }
}
enum CarState
{
    Drived,
    Stopped
}
