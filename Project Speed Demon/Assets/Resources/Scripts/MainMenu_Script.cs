using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Script : MonoBehaviour
{
    public bool targetFrameRate60;

    private void Start()
    {
        if (targetFrameRate60) Application.targetFrameRate = 60;
    }
    public void LevelSelector(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
