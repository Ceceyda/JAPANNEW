using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{

    public Slider volumeSlider; // Ses ayarý için kullanýlacak slider

    private void Start()
    {
        volumeSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); }); // Slider deðeri deðiþtiðinde ValueChangeCheck metodunu çaðýr
    }

    public void ValueChangeCheck()
    {
        AudioListener.volume = volumeSlider.value; // Ses ayarý deðiþtirilir
    }
}