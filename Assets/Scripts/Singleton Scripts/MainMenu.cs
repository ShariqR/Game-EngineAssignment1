using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : Singleton<MainMenu>
{
    private int sceneNumber;
    private SceneInvoker sceneInvoker;

    void Start()
    {
        sceneNumber = 0;
        sceneInvoker = new SceneInvoker();
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
