using System.Collections;
using System.Windows.Input;
using UnityEditor;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class FireCommand : Command
{
    Rigidbody2D rb;
    int bulletSpeed;
    Vector2 direction;
    BulletType bulletType;

    public FireCommand(Rigidbody2D rb, int bulletSpeed, Vector2 direction, BulletType bulletType)
    {
        this.rb = rb;
        this.bulletSpeed = bulletSpeed;
        this.direction = direction;
        this.bulletType = bulletType;
    }

    public override void Execute()
    {
        GameObject bulletInstance = BulletPool.Instance.GetBullet(bulletType);
        bulletInstance.transform.position = rb.transform.position;

        Rigidbody2D bulletRb = bulletInstance.GetComponent<Rigidbody2D>();

        if (direction == Vector2.zero)
        {
            bulletRb.linearVelocity = Vector2.right * bulletSpeed;
        }
        else
            bulletRb.linearVelocity = direction * bulletSpeed;

        
        bulletInstance.GetComponent<Bullet>().StartCoroutine(ReturnFiredBullet(bulletInstance, bulletType, 0.75f));

        //Destroys Bullet after a second
        //UnityEngine.Object.Destroy(bulletInstance, 0.75f);
    }

    public override void Undo()
    {
        //nothing
    }

    private IEnumerator ReturnFiredBullet(GameObject bullet, BulletType type, float delay)
    {
        yield return new WaitForSeconds(delay);
        BulletPool.Instance.ReturnBullet(bullet, type);
    }
}