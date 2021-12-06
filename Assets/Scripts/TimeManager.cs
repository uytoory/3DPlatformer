using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] float _timeScale = 0.3f;
    private float _startFixedDeltaTime;

    private void Start()
    {
        _startFixedDeltaTime = Time.fixedDeltaTime;
    }
    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            Time.timeScale = _timeScale;
        }
        else
        {
            Time.timeScale = 1f;
        }
        Time.fixedDeltaTime = _startFixedDeltaTime * Time.timeScale;
    }

    private void OnDestroy()
    {
        Time.fixedDeltaTime = _startFixedDeltaTime;
    }
}
