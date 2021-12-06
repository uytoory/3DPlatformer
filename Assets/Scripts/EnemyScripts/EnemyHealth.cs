using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int _health = 1;
    [SerializeField] UnityEvent EventOnTakeDamage;
    [SerializeField] UnityEvent EventOnDie;

    public void TakeDamage(int damageValue)
    {
        _health -= damageValue;
        if (_health <= 0)
        {
            Die();      
        }
        else
        {
            EventOnTakeDamage.Invoke();
        }

    }

    public void Die()
    {
        Destroy(gameObject);
        EventOnDie.Invoke();
    }
    
}
