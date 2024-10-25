using System.Windows.Input;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class FireCommand : Command
{
    BulletFactory bullet; //bullet being fired
    Rigidbody2D rb; //rigid body attached (used for player right now, could be used for enemies)
    int bulletSpeed; //speed the bullet 
    Vector2 direction; //direction the player or enemy is facing
    BulletType bulletType; //type of bullet being fired

    //constructor - initializes variables
    public FireCommand(BulletFactory bullet, Rigidbody2D rb, int bulletSpeed, Vector2 direction, BulletType bulletType)
    {
        this.bullet = bullet;
        this.rb = rb;
        this.bulletSpeed = bulletSpeed;
        this.direction = direction;
        this.bulletType = bulletType;
    }


    //execute function
    public override void Execute()
    {
        GameObject bulletInstance = bullet.CreateBullet(rb.transform.position, rb.transform.rotation, bulletType); // creates instance of the bullet prefab

        Rigidbody2D bulletRb = bulletInstance.GetComponent<Rigidbody2D>(); //gets the rigid body

        
        //fires bullet based off of the bullet speed and direction the game object is facing - if just spawned, it shoots right by default
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