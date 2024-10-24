using UnityEngine;

public class DashCommand : Command
{
    Rigidbody2D rb;
    Vector2 direction;
    int dashSpeed;
    public DashCommand(Rigidbody2D rb, Vector2 direction, int dashSpeed)
    {
        this.rb = rb; 
        this.direction = direction;   
        this.dashSpeed = dashSpeed; 

    }
    public override void Execute()
    {
        rb.AddForce(direction * dashSpeed, ForceMode2D.Impulse);
        Debug.Log("Performing Dash");
    }

    public override void Undo()
    {
        rb.AddForce(-direction * dashSpeed, ForceMode2D.Impulse);
        Debug.Log("Performing Reverse Dash");
    }
}