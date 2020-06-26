using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Lvl 1 basement");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
