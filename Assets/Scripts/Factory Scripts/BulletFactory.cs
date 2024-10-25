using UnityEngine;


//Bullet Enumerators
public enum BulletType
{
    Normal, 
    Large
}

public class BulletFactory : MonoBehaviour
{
    [SerializeField] GameObject normalBullet; //Normal bullet prefab
    [SerializeField] GameObject largeBullet; //Large bullet prefab

    //Creates the bullet based off of which bullet enumerator you choose
    public GameObject CreateBullet(Vector2 position, Quaternion rotation, BulletType bulletType)
    {
        GameObject bullet = null;

        switch (bulletType)
        {
            case BulletType.Normal:
                bullet = normalBullet;
                break;
            case BulletType.Large:
                bullet = largeBullet;
                break;
        }

        //Returns an instance of the bullet created
        return Instantiate(bullet, position, rotation);
    }
}