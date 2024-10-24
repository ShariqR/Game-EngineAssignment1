using System.Windows.Input;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class FireCommand : Command
{
    BulletFactory bullet;
    Rigidbody2D rb;
    int bulletSpeed;
    Vector2 direction;
    BulletType bulletType;

    public FireCommand(BulletFactory bullet, Rigidbody2D rb, int bulletSpeed, Vector2 direction, BulletType bulletType)
    {
        this.bullet = bullet;
        this.rb = rb;
        this.bulletSpeed = bulletSpeed;
        this.direction = direction;
        this.bulletType = bulletType;
    }

    public override void Execute()
    {
        GameObject bulletInstance = bullet.CreateBullet(rb.transform.position, rb.transform.rotation, bulletType);

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