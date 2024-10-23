using UnityEngine;
public class SceneInvoker
{
    private ICommand command;

    public void SetCommand(ICommand command)
    {
        this.command = command;
    }
    public void ExecuteCommand()
    {
        command?.Execute();
    }
}
