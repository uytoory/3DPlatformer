using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTargetEuler : MonoBehaviour
{
    [SerializeField] float _rotationSpeed;

    [SerializeField] Vector3 _leftEuler;
    [SerializeField] Vector3 _rightEuler;

    private Vector3 _targetEuler;


    void Update()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(_targetEuler), Time.deltaTime * _rotationSpeed);
    }

    public void RotateLeft()
    {
        _targetEuler = _leftEuler;
    }   
    
    public void RotateRight()
    {
        _targetEuler = _rightEuler;
    }
}
