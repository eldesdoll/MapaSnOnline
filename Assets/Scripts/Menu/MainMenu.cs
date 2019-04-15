using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnClick_OpenGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnClick_CloseGame()
    {
        Application.Quit();
        Debug.Log("__________Se ha cerrado el juego__________");
    }
}
