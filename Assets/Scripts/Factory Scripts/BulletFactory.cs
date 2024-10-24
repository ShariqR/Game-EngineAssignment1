using UnityEngine;

public enum BulletType
{
    Normal, 
    Large
}

public class BulletFactory : MonoBehaviour
{
    [SerializeField] GameObject normalBullet;
    [SerializeField] GameObject largeBullet;
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

        return Instantiate(bullet, position, rotation);
    }
}