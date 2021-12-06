using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    private FixedJoint _fixedJoint;
    public Rigidbody Rigidbody;
    [SerializeField] private RopeGun _ropegun; 

    [SerializeField] Collider _collider;
    [SerializeField] Collider _playerCollider;


    private void Start()
    {
        Physics.IgnoreCollision(_collider, _playerCollider);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(_fixedJoint == null)
        {
            _fixedJoint = gameObject.AddComponent<FixedJoint>();
            if (collision.rigidbody)
            {
                _fixedJoint.connectedBody = collision.rigidbody;
            }
            _ropegun.CreateSpring();
        }      
    }

    public void StopFix()
    {
        if(_fixedJoint)
        {
            Destroy(_fixedJoint);
        }
    }
}
