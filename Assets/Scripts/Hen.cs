using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hen : MonoBehaviour
{
    private Rigidbody _rb;
    private Transform _playerTransform;
    private Vector3 _toPlayer;
    private Vector3 _force;

    [SerializeField] float _speed = 3f;
    [SerializeField] float _timeToReachSpeed = 0.5f;
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();

    }
    private void Start()
    {
        _playerTransform = FindObjectOfType<Player>().transform;
    }

    void FixedUpdate()
    {
        _toPlayer = (_playerTransform.position - transform.position).normalized;
        _force = _rb.mass * (_toPlayer * _speed - _rb.velocity) / _timeToReachSpeed;

        _rb.AddForce(_force);
    }

}
