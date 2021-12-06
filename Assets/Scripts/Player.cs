using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 3f;
    [SerializeField] float _jumpSpeed = 20f;
    [SerializeField] float _friction = 0.6f;
    [SerializeField] float _maxSpeed = 5f;

    public bool Grounded;

    [SerializeField] Transform _colliderTransform;
    [SerializeField] Rigidbody _rb;

    private int _jumpFrameCounter;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Grounded)
            {
                Jump();
            }
        }

        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || Grounded == false)
        {
            _colliderTransform.localScale = Vector3.Lerp(_colliderTransform.localScale, new Vector3(1f, 0.5f, 1f), Time.deltaTime * 30f);
        }
        else 
        { 
            _colliderTransform.localScale = Vector3.Lerp(_colliderTransform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 30f);
        }

    }

    public void Jump()
    {
        _rb.AddForce(0, _jumpSpeed, 0, ForceMode.VelocityChange);
        _jumpFrameCounter = 0;

    }

    private void FixedUpdate()
    {
        float speedMultipilier = 1f;
        if(Grounded == false)
        {
            speedMultipilier = 0.3f;
            if (_rb.velocity.x > _maxSpeed && Input.GetAxis("Horizontal") > 0)
            {
                speedMultipilier = 0;
            }
            if (_rb.velocity.x < -_maxSpeed && Input.GetAxis("Horizontal") < 0)
            {
                speedMultipilier = 0;
            }
        }

        _rb.AddForce(Input.GetAxis("Horizontal") * _moveSpeed * speedMultipilier, 0f, 0f, ForceMode.VelocityChange);
        if (Grounded)
        {
            _rb.AddForce(-_rb.velocity.x * _friction, 0f, 0f, ForceMode.VelocityChange);

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 15f);
        }

        _jumpFrameCounter += 1;
        if(_jumpFrameCounter == 2)
        {
            _rb.freezeRotation = false;
            _rb.AddRelativeTorque(0f, 0f, 10f, ForceMode.VelocityChange);
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        float angle;
        for (int i = 0; i < collision.contactCount; i++)
        {
            angle = Vector3.Angle(collision.contacts[i].normal, Vector3.up);
            if (angle < 45f)
            {
                Grounded = true;
                _rb.freezeRotation = true;
            }
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        Grounded = false;
    }
}
