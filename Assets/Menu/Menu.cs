using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject _menuButton;
    [SerializeField] GameObject _menuWindow;

    [SerializeField] MonoBehaviour[] _componentsToDisable;

    public void OpenMenuWindow()
    {
        _menuButton.SetActive(false);
        _menuWindow.SetActive(true);
        for (int i = 0; i < _componentsToDisable.Length; i++)
        {
            _componentsToDisable[i].enabled = false;
        }
        Time.timeScale = 0.01f;
    } 
    public void CloseMenuWindow()
    {
        _menuButton.SetActive(true);
        _menuWindow.SetActive(false);
        for (int i = 0; i < _componentsToDisable.Length; i++)
        {
            _componentsToDisable[i].enabled = true;
        }
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
