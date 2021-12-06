using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] GameObject _effectPrefab;

    private void Start()
    {
        Destroy(gameObject, 4f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(_effectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


    public void Die()
    {
        Instantiate(_effectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
