using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Left,
    Right
}
public class Walker : MonoBehaviour
{
    [SerializeField] Transform _leftTarget;
    [SerializeField] Transform _rightTarget;
    [SerializeField] Transform _rayStart;

    [SerializeField] float _speed;

    [SerializeField] float _stopTime;

    public Direction CurrentDirection;
    RaycastHit _hit;
    private bool _isStopped;

    [SerializeField] UnityEvent _eventOnLeftTarget;
    [SerializeField] UnityEvent _eventOnRightTarget;

    private void Start()
    {
        _leftTarget.parent = null;
        _rightTarget.parent = null;
    }
    void Update()
    {
        if(_isStopped == true)
        {
            return;
        }

        if(CurrentDirection == Direction.Left)
        {
            transform.position -= new Vector3(Time.deltaTime * _speed, 0f, 0f);
            if (transform.position.x < _leftTarget.position.x)
            {
                CurrentDirection = Direction.Right;
                _isStopped = true;
                Invoke("ContinueWalk", _stopTime);
                _eventOnLeftTarget.Invoke();
            }    
        }
        else
        {
            transform.position += new Vector3(Time.deltaTime * _speed, 0f, 0f);
            if(transform.position.x > _rightTarget.position.x)
            {
                CurrentDirection = Direction.Left;
                _isStopped = true;
                Invoke("ContinueWalk", _stopTime);
                _eventOnRightTarget.Invoke();
            }
        }
        
        if(Physics.Raycast(_rayStart.position, Vector3.down, out _hit))
        {
            transform.position = _hit.point;
        }
    }

    void ContinueWalk()
    {
        _isStopped = false;
    }
}
