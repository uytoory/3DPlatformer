using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int _health = 5;
    [SerializeField] int _maxHealth = 8;

    private bool _invulnerable = false;

    [SerializeField] AudioSource _addHeatlhSound;
    [SerializeField] HealthUI _healthUI;
    [SerializeField] UnityEvent _EvenOnTakeDamage;

    private void Start()
    {
        _healthUI.Setup(_maxHealth);
        _healthUI.DisplayHealth(_health);
    }
    public void TakeDamage(int damageValue)
    {
        if(_invulnerable == false)
        {
            _health -= damageValue;
            if (_health <= 0)
            {
                _health = 0;
                Die();
            }
            _invulnerable = true;
            Invoke("StopInvulnerable", 2f);
            _healthUI.DisplayHealth(_health);
        }
        _EvenOnTakeDamage.Invoke();
    }

    void StopInvulnerable()
    {
        _invulnerable = false;
    }

    public void AddHealth(int healthValue)
    {
        _health += healthValue;
        if(_health > _maxHealth)
        {
            _health = _maxHealth;
        }
        _addHeatlhSound.Play();
        _healthUI.DisplayHealth(_health);
    }
    void Die()
    {
        Debug.Log("Died");
    }
}
