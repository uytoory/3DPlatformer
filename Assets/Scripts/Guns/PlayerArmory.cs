using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmory : MonoBehaviour
{
    [SerializeField] Gun[] _guns;
    [SerializeField] int _currentGunIndex;

    void Start()
    {
        TakeGunByIndex(_currentGunIndex);
    }

    public void TakeGunByIndex(int gunIndex)
    {
        _currentGunIndex = gunIndex;
        for (int i = 0; i < _guns.Length; i++)
        {
            if(i == gunIndex)
            {
                _guns[i].Activate();
            }
            else
            {
                _guns[i].Deactivate();
            }
        }
    }

    public void AddBullets(int gunIndex, int numberOfBullets)
    {
        _guns[gunIndex].AddBullets(numberOfBullets);
    }
}
