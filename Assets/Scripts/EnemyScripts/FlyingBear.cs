using UnityEngine;
using UnityEngine.Events;


public class FlyingBear : MonoBehaviour
{
    [SerializeField] Transform _leftTarget;
    [SerializeField] Transform _rightTarget;

    [SerializeField] float _speed;

    [SerializeField] float _stopTime;

    public Direction CurrentDirection;
    private bool _isStopped;



    private void Start()
    {
        _leftTarget.parent = null;
        _rightTarget.parent = null;
    }
    void Update()
    {
        if (_isStopped == true)
        {
            return;
        }

        if (CurrentDirection == Direction.Left)
        {
            transform.position -= new Vector3(Time.deltaTime * _speed, 0f, 0f);
            if (transform.position.x < _leftTarget.position.x)
            {
                CurrentDirection = Direction.Right;
                _isStopped = true;
                Invoke("ContinueWalk", _stopTime);
            }
        }
        else
        {
            transform.position += new Vector3(Time.deltaTime * _speed, 0f, 0f);
            if (transform.position.x > _rightTarget.position.x)
            {
                CurrentDirection = Direction.Left;
                _isStopped = true;
                Invoke("ContinueWalk", _stopTime);
            }
        }


    }

    void ContinueWalk()
    {
        _isStopped = false;
    }
}

