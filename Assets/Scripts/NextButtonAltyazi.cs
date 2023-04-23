using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextButtonAltyazi : MonoBehaviour
{
    public Text altyaziText; // Altyazýyý içeren Text componentine referans

    private string[] altyaziMetinleri; // Altyazý metinlerini içeren dizi
    private int suankiAltyaziIndex = 0; // Þu anki altyazý metni index'i
    [SerializeField] GameObject _player,text;
    void Start()
    {
        // Altyazý metinlerini doldurun
        altyaziMetinleri = new string[] { "Kuebiko:  Do you know where the Light is?", "Kana: W-what, what light?", "Kuebiko: Do you know where should you go?", "Kana: Kuebiko is that you? How did you came here?",
            "Kuebiko: Kid, don't underestimate me never again","Kuebiko: And now, tell me where are you going, what do you wanna find?","Kana: To be honest i dont know everything that i had is wiped out with my city, I have no choice but to run away.and even Amaterasu is dead too.",
            "Kuebiko: She is alive.In a cave outside the city. You can find her with a little help.","Kana: W-what? is she alive? and...What can I do even if I reach her",
            "Kuebiko: The gods are not as strong as you think. The power of the gods comes from the fact that people see us as gods.You are much more than you think, but first go to the forest, find and talk to an old friend of mine.",
            "Kana: Do you really believe that I can find him?","Kuebiko: No more talk.go away, NOW","Kuebiko: I hope she would've the right to choose" };
        // Baþlangýçta ilk altyazý metnini gösterin
        altyaziText.text = altyaziMetinleri[suankiAltyaziIndex];
    }



    public void AltyaziIlerlet()
    {
        Debug.Log("çalýþtý");
        // Eðer altyazý metinleri bitmediyse
        if (suankiAltyaziIndex < altyaziMetinleri.Length-1)
        {
            // Þu anki altyazý metnini bir sonraki ile deðiþtirin
            suankiAltyaziIndex++;
            altyaziText.text = altyaziMetinleri[suankiAltyaziIndex];

           
        }
        else
        {
            _player.GetComponent<PlayerController>().enabled = true;

            // Altyazý metinleri bittiðinde, altyazýyý kapatýn
            text.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
