using System.Collections.Generic;
using UnityEngine;

public class BulletPool : Singleton<BulletPool>
{
    BulletFactory bulletFactory;
    Queue<GameObject> bulletPool = new Queue<GameObject>();
    Queue<GameObject> largeBulletPool = new Queue<GameObject>();
    [SerializeField] int poolSize = 5;

    void Start()
    {
        bulletFactory = FindObjectOfType<BulletFactory>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = bulletFactory.CreateBullet(BulletType.Normal);
            GameObject largeBullet = bulletFactory.CreateBullet(BulletType.Large);

            bullet.SetActive(false);
            largeBullet.SetActive(false);

            bulletPool.Enqueue(bullet);
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
        }
    }

    public void ReturnBullets(List<GameObject> bullets, BulletType type)
    {
        Queue<GameObject> currentPool = GetBulletPool(type);

        foreach (GameObject bullet in bullets)
        {
            bullet.SetActive(false);
            currentPool.Enqueue(bullet);
        }
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