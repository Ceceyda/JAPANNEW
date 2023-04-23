using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextButtonAltyazi_2 : MonoBehaviour
{
    public Text altyaziText; // Altyaz�y� i�eren Text componentine referans

    private string[] altyaziMetinleri; // Altyaz� metinlerini i�eren dizi
    private int suankiAltyaziIndex = 0; // �u anki altyaz� metni index'i
    [SerializeField] GameObject _player, text;
    void Start()
    {
        // Altyaz� metinlerini doldurun
        altyaziMetinleri = new string[] { "Amatsumara: Finally, you came.Why did it take so long?", "Kana: The journey was a bit rough",
            "Amatsumara: Anyway.Look, I'll be honest with you, I didn't ask you to come here and I don't have the time or patience to spare for you. I don't really care what happens in Skymeadow",
            "Kana: I just wanna do my best, I'm not begging for help. I just wanna be able to help someone who needs help.",
            "Amatsumara: ...",
            "Amatsumara: You are not like the people I know. The more terrible the gods, the more terrible people are. Remember this, don't trust everyone so easily. And be careful who you help.  ",
            "Amatsumara: And finally if you reach her tell her to look in the Mirror.",
            "Kana: Mirror?",
            "Amatsumara: Don't worry, she'll see." };
        // Ba�lang��ta ilk altyaz� metnini g�sterin
        altyaziText.text = altyaziMetinleri[suankiAltyaziIndex];
    }


    


















    public void AltyaziIlerlet()
    {

        // E�er altyaz� metinleri bitmediyse
        if (suankiAltyaziIndex < altyaziMetinleri.Length - 1)
        {
            // �u anki altyaz� metnini bir sonraki ile de�i�tirin
            suankiAltyaziIndex++;
            altyaziText.text = altyaziMetinleri[suankiAltyaziIndex];
        }
        else
        {
            _player.GetComponent<PlayerController>().enabled = true;

            // Altyaz� metinleri bitti�inde, altyaz�y� kapat�n
            text.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}

