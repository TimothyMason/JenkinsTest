using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void loadLevel()
    {
        SceneManager.LoadScene("Scene01");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
