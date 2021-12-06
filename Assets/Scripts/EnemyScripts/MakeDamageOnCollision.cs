using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] int _damageValue = 1;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.rigidbody)
        {
            if (collision.rigidbody.GetComponent<PlayerHealth>())
            {
                collision.rigidbody.GetComponent<PlayerHealth>().TakeDamage(_damageValue);
            }
        }
    }
}
