using UnityEngine;
using System.Collections;

public class PanelController : MonoBehaviour {

    public GameObject panel;

    public void OpenPanel() {
        panel.SetActive(true);
    }

    public void ClosePanel() {
        panel.SetActive(false);
    }
}