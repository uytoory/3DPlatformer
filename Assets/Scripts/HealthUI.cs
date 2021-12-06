using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] GameObject _healthImagePrefab;
    [SerializeField] List<GameObject> _healthImages = new List<GameObject>();
 public void Setup(int maxHealth)
    {
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject newImages = Instantiate(_healthImagePrefab, transform);
            _healthImages.Add(newImages);
        }
    }

    public void DisplayHealth(int health)
    {
        for (int i = 0; i < _healthImages.Count; i++)
        {
            if(i< health)
            {
                _healthImages[i].SetActive(true);
            }
            else
            {
                _healthImages[i].SetActive(false);
            }
        }
    }
}
