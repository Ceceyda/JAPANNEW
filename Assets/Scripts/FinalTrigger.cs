using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Animator>().Play("Player_death");

            collision.gameObject.GetComponent<PlayerController>().enabled = false;

            Invoke("bekle2", 3);

        }
    }

    void bekle()
    {
        Time.timeScale = 0;
    }
    void bekle2()
    {
        SceneManager.LoadScene(7);
    }
}
