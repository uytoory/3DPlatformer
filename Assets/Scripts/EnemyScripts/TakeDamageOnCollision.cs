using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] EnemyHealth _enemyHealth;
    [SerializeField] private bool _dieOnAnyCollision;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.GetComponent<Bullet>())
            {
                _enemyHealth.TakeDamage(1);
            }
        }
        if(_dieOnAnyCollision == true)
        {
            _enemyHealth.TakeDamage(10000);
        }
    }
    

}
