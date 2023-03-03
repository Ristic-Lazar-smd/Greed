using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShoot : MonoBehaviour
{   
    public Transform pfBullet;

    float countdown = 0;
    public float cooldown = 0.5f;
    public bool canShoot = true;

    private void Start()
    {
        countdown = cooldown;
    }

    void Update()
    {
        if (!canShoot)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                countdown = cooldown;
                canShoot = true;
            }
        }
    }

    public void Shooting()
    {
        if (canShoot)
        {
            Transform bullet = Instantiate(pfBullet, transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().Setup(GetComponent<EchoSearch>().shootDir.normalized);
            canShoot = false;
            Update();
        }
    }
}
