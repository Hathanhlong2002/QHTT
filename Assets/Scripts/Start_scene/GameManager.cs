using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject setting;
    void Start()
    {        
        setting.SetActive(false);
    }
    public void GamePlay()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void GameSetting()
    {
        setting.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void CloseSetting()
    {
        setting.SetActive(false);
    }
}
