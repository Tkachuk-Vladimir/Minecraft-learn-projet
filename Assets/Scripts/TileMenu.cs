using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TileMenu : MonoBehaviour
{

    public void StartGame()
    {
        // загрузка сцены "main"
        SceneManager.LoadScene("main", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        // выход из игры
        Application.Quit();
    }
}
