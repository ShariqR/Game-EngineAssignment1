using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu manager;
    int sceneNumber;

    void Start()
    {
        sceneNumber = 0;
    }
    void Awake()
    {
        if (manager == null)
        {
            manager = this;
            DontDestroyOnLoad(this);
        }
        else if (manager != this)
        {
            Destroy(gameObject);
        }
    }
    public void LoadScene()
    {
        sceneNumber++;
        if (sceneNumber > 1)
        {
            sceneNumber = 0;
        }
        SceneManager.LoadSceneAsync(sceneNumber);
    }

}
