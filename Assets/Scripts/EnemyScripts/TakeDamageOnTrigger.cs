using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{
    [SerializeField] EnemyHealth _enemyHealth;
    [SerializeField] bool DieAnyCollision;

    private void OnTriggerEnter(Collider other)
    {
        Bullet Bullet = other.GetComponent<Bullet>();
        if (Bullet)
        {

            Bullet.Die();
            _enemyHealth.TakeDamage(1);
        }

        if(DieAnyCollision == true)
        {
            if(other.isTrigger == false)
            _enemyHealth.TakeDamage(10000);
        }
    }
}
