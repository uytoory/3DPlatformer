using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _spawn;
    [SerializeField] float _bulletSpeed = 15f;
    [SerializeField] float _shotPeriod = 0.2f;

    [SerializeField] AudioSource _shotSound;
    [SerializeField] GameObject _flash;

    [SerializeField] ParticleSystem _shotEffect;

    private float _timer;

    void Update()
    {
        _timer += Time.unscaledDeltaTime;
        if(_timer > _shotPeriod)
        {
            if(Input.GetMouseButton(0))
            {
                if(!EventSystem.current.IsPointerOverGameObject())
                {
                    _timer = 0f;
                    Shot();
                }
            }
        }
    }

    public virtual void Shot()
    {
        GameObject newBullet = Instantiate(_bulletPrefab, _spawn.position, _spawn.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = _spawn.forward * _bulletSpeed;
        _shotSound.Play();
        _flash.SetActive(true);
        Invoke("HideFlash", 0.10f);
        _shotEffect.Play();
    }

    public void HideFlash()
    {
        _flash.SetActive(false);
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }
    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }
    public virtual void AddBullets(int numberOfBullets)
    {

    }
}
