using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RepeatGames : MonoBehaviour
{
    public void repeat()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }
}
