using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RopeState
{
    Disabled,
    Fly,
    Active
}

public class RopeGun : MonoBehaviour
{
    public Hook Hook;
    public Transform _spawn;

    [SerializeField] float _speed;
    [SerializeField] SpringJoint SpringJoint;
    [SerializeField] Transform _ropeStart;    
    [SerializeField] RopeRenderer _ropeRenderer;
    [SerializeField] RopeState _currentRopeState;
    [SerializeField] Player _playerScript;

    private float _length;

    void Update()
    {
        if(Input.GetMouseButtonDown(2))
        {
            Shot();
        }
        if(_currentRopeState == RopeState.Fly)
        {
            float distance = Vector3.Distance(_ropeStart.position, Hook.transform.position);
            if(distance > 20f)
            {
                Hook.gameObject.SetActive(false);
                _currentRopeState = RopeState.Disabled;
                _ropeRenderer.Hide();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(_currentRopeState == RopeState.Active)
            {
                if(_playerScript.Grounded == false)
                {
                    _playerScript.Jump();
                }
            }
            DestroySpring();
        }
        if (_currentRopeState == RopeState.Fly || _currentRopeState == RopeState.Active)
        {
            _ropeRenderer.Draw(_ropeStart.position, Hook.transform.position, _length);
        }

    }

    void Shot()
    {
        _length = 1f;

        if(SpringJoint)
        {
            Destroy(SpringJoint);
        }

        Hook.gameObject.SetActive(true);

        Hook.StopFix();
        Hook.transform.position = _spawn.position;
        Hook.transform.rotation = _spawn.rotation;
        Hook.Rigidbody.velocity = _spawn.forward * _speed;

        _currentRopeState = RopeState.Fly;
    }

    public void CreateSpring()
    {
        if (SpringJoint == null)
        {
            SpringJoint = gameObject.AddComponent<SpringJoint>();
            SpringJoint.connectedBody = Hook.Rigidbody;
            SpringJoint.anchor = _ropeStart.localPosition;
            SpringJoint.autoConfigureConnectedAnchor = false;
            SpringJoint.connectedAnchor = Vector3.zero;
            SpringJoint.spring = 100f;
            SpringJoint.damper = 5f;

            _length = Vector3.Distance(_ropeStart.position, Hook.transform.position);
            SpringJoint.maxDistance = _length;

            _currentRopeState = RopeState.Active;
        }
        
    }

    public void DestroySpring()
    {
        if(SpringJoint)
        {
            Destroy(SpringJoint);
            _currentRopeState = RopeState.Disabled;
            Hook.gameObject.SetActive(false);
            _ropeRenderer.Hide();
        }
    }
}
