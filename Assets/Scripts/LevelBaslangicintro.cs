using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBaslangicintro : MonoBehaviour
{
    

    private void Awake()
    {

        KarartmaEfektiBaslat();
       

    }
    public GameObject panel;

    // Karartma efekti i�in kullan�lacak Image bile�eni
    public Image karartmaGoruntu;

    // Karartma efekti s�resi (saniye)
    public float karartmaSure = 1f;

    // Karartma efekti gecikme s�resi (saniye)
    public float karartmaGecikme = 0.5f;

    // Karartma efekti animasyonu
    private IEnumerator KarartmaEfekti()
    {
        // Gecikme s�resi kadar bekleyin
        yield return new WaitForSeconds(karartmaGecikme);

        // Panel objesini g�r�n�r hale getirin
        //panel.SetActive(true);

        // Karartma efekti animasyonu
        float baslangicAlfa = 1f;
        float bitisAlfa = 0f;
        float gecenSure = 0f;

        while (gecenSure < karartmaSure)
        {
            gecenSure += Time.deltaTime;
            float gecenSureYuzdesi = gecenSure / karartmaSure;
            karartmaGoruntu.color = new Color(0f, 0f, 0f, Mathf.Lerp(baslangicAlfa, bitisAlfa, gecenSureYuzdesi));
            //panel.SetActive(false);
            yield return null;
        }
        

        panel.SetActive(false);
        
        

    }

    // Karartma efektini tetikleyen fonksiyon
    public void KarartmaEfektiBaslat()
    {
        StartCoroutine(KarartmaEfekti());
    }
}
