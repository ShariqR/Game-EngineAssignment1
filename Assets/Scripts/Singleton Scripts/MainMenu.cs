using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu manager;
    private int sceneNumber;
    private SceneInvoker sceneInvoker;

    void Start()
    {
        sceneNumber = 0;
        sceneInvoker = new SceneInvoker();
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
        if (sceneNumber > 3)
        {
            sceneNumber = 0;
        }
        Command loadSceneCommand = new LoadSceneCommand(sceneNumber);

        sceneInvoker.SetCommand(loadSceneCommand);
        sceneInvoker.ExecuteCommand();
    }
}
