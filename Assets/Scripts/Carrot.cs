using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float _speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        transform.rotation = Quaternion.identity;
        Transform playerTransform = FindObjectOfType<Player>().transform;
        Vector3 toPlayer = (playerTransform.position - transform.position).normalized;
        rb.velocity = toPlayer * _speed;
        Invoke("DestroyCarrot", 10f);
    } 


    void DestroyCarrot()
    {
        Destroy(gameObject);
    }


}
