using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] AudioSource _playDeadSound;

    [SerializeField] float _speed = 1f;
    [SerializeField] float _rotationSpeed = 1f;

    private Transform _playerTransform;

    void Start()
    {
        _playerTransform = FindObjectOfType<Player>().transform;

    }


    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * _speed;
        Vector3 ToPlayer = _playerTransform.position - transform.position;
        Quaternion TargetRotation = Quaternion.LookRotation(ToPlayer, Vector3.forward);

        transform.rotation = Quaternion.Lerp(transform.rotation, TargetRotation, Time.deltaTime * _rotationSpeed);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
    }
}
