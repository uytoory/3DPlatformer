using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    [SerializeField] Transform _target;
    void Update()
    {
        transform.position = _target.position;
    }
}
