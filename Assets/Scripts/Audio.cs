using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex > 3)
        {
            Destroy(this.gameObject);
        }
    }
}