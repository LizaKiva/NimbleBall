using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void start()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }
}
