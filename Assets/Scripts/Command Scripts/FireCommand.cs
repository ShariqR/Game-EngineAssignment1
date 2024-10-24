using System.Windows.Input;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class FireCommand : Command
{
    private GameObject bullet;
    Rigidbody2D rb;
    private float bulletSpeed;
    Vector2 direction;

    public FireCommand(GameObject bullet, Rigidbody2D rb, float bulletSpeed, Vector2 direction)
    {
        this.bullet = bullet;
        this.rb = rb;
        this.bulletSpeed = bulletSpeed;
        this.direction = direction;
    }

    public override void Execute()
    {
        GameObject bulletInstance = Object.Instantiate(bullet, rb.transform.position, rb.transform.rotation);

        Rigidbody2D bulletRb = bulletInstance.GetComponent<Rigidbody2D>();

        if (direction == Vector2.zero)
        {
            bulletRb.linearVelocity = Vector2.right * bulletSpeed;
        }
        else
            bulletRb.linearVelocity = direction * bulletSpeed;

    }

    public override void Undo()
    {
        //nothing
    }
}