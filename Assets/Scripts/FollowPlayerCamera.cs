using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float _lerpRate = 5f;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position, Time.deltaTime * _lerpRate);
    }
}
