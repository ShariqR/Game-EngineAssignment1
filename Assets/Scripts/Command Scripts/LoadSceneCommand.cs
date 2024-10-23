using UnityEngine.SceneManagement;

public class LoadSceneCommand : ICommand
{
    private int sceneNumber;

    public LoadSceneCommand(int sceneNumber)
    {
        this.sceneNumber = sceneNumber;
    }

    public void Execute()
    {
        SceneManager.LoadSceneAsync(sceneNumber);
    }
}
