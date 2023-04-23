using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{

    public Slider volumeSlider; // Ses ayar� i�in kullan�lacak slider

    private void Start()
    {
        volumeSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); }); // Slider de�eri de�i�ti�inde ValueChangeCheck metodunu �a��r
    }

    public void ValueChangeCheck()
    {
        AudioListener.volume = volumeSlider.value; // Ses ayar� de�i�tirilir
    }
}