using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Time_and_Level : MonoBehaviour
{

    private void Start()
    {
    }

    public void TimeScale(int timeScale)
    {
        Time.timeScale = timeScale;
    }
    public void RestartLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
