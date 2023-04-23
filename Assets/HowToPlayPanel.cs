using UnityEngine;
using System.Collections;

public class HowToPlayPanel : MonoBehaviour
{

    public GameObject panel;

    public void OpenPanel()
    {
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }
}