using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    [SerializeField] Vector3 _eulerRight;
    [SerializeField] Vector3 _eulerLeft;

    [SerializeField] float _rotationSpeed = 5;

    private Transform _playerTransform;
    private Vector3 _targetEuler;
    void Start()
    {
        _playerTransform = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < _playerTransform.position.x)
        {
            _targetEuler = _eulerRight;
            //поворот вправо
        }
        else
        {
            _targetEuler = _eulerLeft;
            //поворот влево
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_targetEuler), Time.deltaTime * _rotationSpeed);

    }
}
