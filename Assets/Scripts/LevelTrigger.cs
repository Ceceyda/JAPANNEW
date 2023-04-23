using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelTrigger : MonoBehaviour
{
    int sceneCount;
    int activeSceneIndex;
    private void Awake()
    {
        sceneCount = SceneManager.sceneCountInBuildSettings;
        activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(sceneCount);
        Debug.Log(activeSceneIndex);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            KarartmaEfektiBaslat();
            collision.gameObject.GetComponent<Animator>().SetFloat("__isRun", 0);

            collision.gameObject.GetComponent<PlayerController>().enabled = false;
        } 
    }

    public void LoadScene()
    {
        if (sceneCount>activeSceneIndex)
        {
            SceneManager.LoadScene(activeSceneIndex + 1);
            Debug.Log("deneme");
        }

    }
    public GameObject panel;

    // Karartma efekti için kullanýlacak Image bileþeni
    public Image karartmaGoruntu;

    // Karartma efekti süresi (saniye)
    public float karartmaSure = 1f;

    // Karartma efekti gecikme süresi (saniye)
    public float karartmaGecikme = 0.5f;

    // Karartma efekti animasyonu
    private IEnumerator KarartmaEfekti()
    {
        // Gecikme süresi kadar bekleyin
        yield return new WaitForSeconds(karartmaGecikme);

        // Panel objesini görünür hale getirin
        panel.SetActive(true);

        // Karartma efekti animasyonu
        float baslangicAlfa = 0f;
        float bitisAlfa = 1f;
        float gecenSure = 0f;

        while (gecenSure < karartmaSure)
        {
            gecenSure += Time.deltaTime;
            float gecenSureYuzdesi = gecenSure / karartmaSure;
            karartmaGoruntu.color = new Color(0f, 0f, 0f, Mathf.Lerp(baslangicAlfa, bitisAlfa, gecenSureYuzdesi));
            yield return null;
        }
        //yield return new WaitForSeconds(2);
        LoadScene();

    }

    // Karartma efektini tetikleyen fonksiyon
    public void KarartmaEfektiBaslat()
    {
        StartCoroutine(KarartmaEfekti());
    }

}
