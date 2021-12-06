using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    [SerializeField] Vector3 Velocity;

    [SerializeField] float _maxRotationSpeed = 10f;

    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Velocity, ForceMode.VelocityChange);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(
            Random.Range(-_maxRotationSpeed, _maxRotationSpeed),
            Random.Range(-_maxRotationSpeed, _maxRotationSpeed),
            Random.Range(-_maxRotationSpeed, _maxRotationSpeed));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
