using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FromOverToMenu : MonoBehaviour
{
    public void menu1()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
}
