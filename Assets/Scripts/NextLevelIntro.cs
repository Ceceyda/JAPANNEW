using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelIntro : MonoBehaviour
{

    int sceneCount;
    int activeSceneIndex;
    private void Awake()
    {
        sceneCount = SceneManager.sceneCountInBuildSettings;
        activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public GameObject textPanel;

    
    IEnumerator Baslangic()
    {
        yield return new WaitForSeconds(4);
        textPanel.SetActive(true);
        yield return new WaitForSeconds(6);

        SceneManager.LoadScene(activeSceneIndex+1);
    }

    private void Start()
    {
        StartCoroutine("Baslangic");
    }
}
