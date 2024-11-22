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
        if (direction == Vector2.zero)
        {
            rb.AddForce(Vector2.right * dashSpeed, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(direction * dashSpeed, ForceMode2D.Impulse);
        }
        
        Debug.Log("Performing Dash");
    }

    public override void Undo()
    {

        if (direction == Vector2.zero)
        {
            rb.AddForce(Vector2.left * dashSpeed, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(-direction * dashSpeed, ForceMode2D.Impulse);
        }
        
        Debug.Log("Performing Reverse Dash");
    }
}