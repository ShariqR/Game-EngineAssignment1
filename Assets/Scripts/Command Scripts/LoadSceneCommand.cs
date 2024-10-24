using UnityEngine.SceneManagement;

public class LoadSceneCommand : Command
{
    private int sceneNumber;

    public LoadSceneCommand(int sceneNumber)
    {
        this.sceneNumber = sceneNumber;
    }

    public override void Execute()
    {
        SceneManager.LoadSceneAsync(sceneNumber);
    }

    public override void Undo()
    {
        //empty as there is no undo for this command
    }
}
