using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTriggerEveryNSeconds : MonoBehaviour
{
    [SerializeField] float _period = 7f;
    [SerializeField] Animator _animator;
    private float _timer;

    [SerializeField] string TriggerName = "Attack";

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer > _period)
        {
            _timer = 0;
            _animator.SetTrigger(TriggerName);
        }
    }
}
