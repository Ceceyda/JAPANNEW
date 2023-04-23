using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Magara : MonoBehaviour
{
    public GameObject _panel;
    public Text _panelText;
    public GameObject _player;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Animator>().SetFloat("__isRun", 0);
            collision.gameObject.GetComponent<PlayerController>().enabled = false;
            _panel.SetActive(true);
            Invoke("den", 25);
        }
    }

    public void den()
    {
        _panel.SetActive(false);
        _player.GetComponent<PlayerController>().enabled = true;
        SceneManager.LoadScene(7);
    }
    

    public void text1()
    {
        _panelText.text = "Kana: W-what, what light";

    }


    private void Update()
    {
        
    }
}
