using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class death : MonoBehaviour
{
    [SerializeField] GameObject deathMenu;
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        deathMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
