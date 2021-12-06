using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGun : MonoBehaviour
{
    [SerializeField] Rigidbody _playerRigidbody;
    [SerializeField] float _speed;
    [SerializeField] Transform _spawn;
    [SerializeField] AudioSource _soundActivate;
    [SerializeField] GameObject _hen;

    [SerializeField] float _maxCharge = 3f;
    [SerializeField] float _currentCharge = 0f;
    [SerializeField] bool _isCharged;

    [SerializeField] ChargeIcon ChargeIcon;

    private void Update()
    {

        if(_isCharged)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _playerRigidbody.AddForce(-_spawn.forward * _speed, ForceMode.VelocityChange);
                _soundActivate.Play();
                var newHen = Instantiate(_hen, _spawn.position, Quaternion.identity);
                newHen.transform.parent = null;
                _currentCharge = 0f;
                _isCharged = false;
                ChargeIcon.StartCharge();
            }
        }
        else
        {
            _currentCharge += Time.unscaledDeltaTime;
            ChargeIcon.SetChargeValue(_currentCharge, _maxCharge);
            if (_currentCharge >= _maxCharge)
            {
                _isCharged = true;
                ChargeIcon.StopCharge();
            }
        }
    }
}
