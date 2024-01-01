using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] Bullet bulletPrefab;
    Queue<Bullet> bulletQueue = new Queue<Bullet>();

    public void GetBullet()
    {
        if (bulletQueue.Count > 0)
        {
            Bullet oldBullet = bulletQueue.Dequeue();
            oldBullet.gameObject.SetActive(true);
            oldBullet.Shoot();
        }
        else
        {
            Bullet bullet = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity) as Bullet;
            bullet.BulletPool = this;
            bullet.Shoot();
        }
    }

    public void AddBulletToPool(Bullet bullet)
    {
        bulletQueue.Enqueue(bullet);
    }
}
