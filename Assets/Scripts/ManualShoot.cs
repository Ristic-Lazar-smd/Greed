using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
public class ManualShoot : MonoBehaviour
{
    public Transform bulletType;

    float countdown = 0;

    [Tooltip("Time between shots, aka rate of fire")]
    public float timeBetweenShots = 0.5f;
    public bool canShoot = true;

    int[] eW = new int[] { 0 };

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            for (int i = 0;i<eW.Length;i++)
            {
                switch (eW[i])
                {
                    case 0:
                        ShootFireball();
                        break;  
                }
            }
            canShoot = false;
        }

        if (!canShoot)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                countdown = timeBetweenShots;
                canShoot = true;
            }
        }
    }

    Vector3 GetDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 normalizedDirection = new Vector3((worldPosition - gameObject.transform.position).x, (worldPosition - gameObject.transform.position).y).normalized;
        return normalizedDirection;
    }

    //<-------Weapons call start------->//
    void ShootFireball()
    {
        Transform bullet = Instantiate(bulletType, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().Setup(GetDirection());
    }


}
