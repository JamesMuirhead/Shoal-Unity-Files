using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicMenu : MonoBehaviour
{
    public void quitToOS()
    {
        Application.Quit();
    }

    public void quitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
