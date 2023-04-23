using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mentor1Trigger : MonoBehaviour
{
    public GameObject _panel,buton;
    
    public GameObject _player;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Animator>().SetFloat("__isRun", 0);
            collision.gameObject.GetComponent<PlayerController>().enabled = false;
            _panel.SetActive(true);
            buton.SetActive(true);
              
        }
    }

    public void den()
    {
        _panel.SetActive(false);
        _player.GetComponent<PlayerController>().enabled = true;
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            

        }
    }
    

    
    
}
