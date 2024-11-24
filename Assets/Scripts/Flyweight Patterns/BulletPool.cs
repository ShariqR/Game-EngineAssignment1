using System.Collections.Generic;
using UnityEngine;

public class BulletPool : Singleton<BulletPool>
{
    //[SerializeField] GameObject bulletPrefab;
    BulletFactory bulletFactory;
    Queue<GameObject> bulletPool = new Queue<GameObject>();
    Queue<GameObject> largeBulletPool = new Queue<GameObject>();
    public int poolSize = 5;

    void Start()
    {
        bulletFactory = FindObjectOfType<BulletFactory>();

        for (int i = 0; i < poolSize; i++)
        {
            //GameObject bullet = Instantiate(bulletPrefab);
            GameObject bullet = bulletFactory.CreateBullet(BulletType.Normal);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);

            GameObject largeBullet = bulletFactory.CreateBullet(BulletType.Large);
            largeBullet.SetActive(false);
            largeBulletPool.Enqueue(largeBullet);
        }
    }

    public GameObject GetBullet(BulletType bulletType)
    {
        Queue<GameObject> currentPool = GetBulletPool(bulletType);
        if (currentPool.Count > 0)
        {
            GameObject bullet = currentPool.Dequeue();
            bullet.SetActive(true);
            return bullet;
        }
        else
        {
            Debug.Log("No Bullets!");
            return null;
            //return Instantiate(bulletPrefab);
        }
    }

    public void ReturnBullet(GameObject bullet, BulletType type)
    {
        bullet.SetActive(false);
        GetBulletPool(type).Enqueue(bullet);
    }

    Queue<GameObject> GetBulletPool(BulletType type)
    {
        switch (type)
        {
            case BulletType.Normal:
                return bulletPool;
            case BulletType.Large:
                return largeBulletPool;
            default:
                throw new System.ArgumentException("Invalid BulletType");
        }
    }
}