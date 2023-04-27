using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using CameraShake;
public class ManualShoot : MonoBehaviour
{
    [SerializeField]BounceShake.Params shakeParams;
    public Transform bulletType;

    public bool canShoot = true;
    bool shootCooldown = false;
    float countdown = 0.5f;

    [Tooltip("Time between shots, aka rate of fire")]public float timeBetweenShots = 0.5f;
    [HideInInspector]public bool extraShot = false;
    
    int[] eW = new int[] { 0 };

    void Start(){
        countdown = timeBetweenShots;
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !shootCooldown && canShoot)
        {
            for (int i = 0;i<eW.Length;i++)
            {
                switch (eW[i])
                {
                    case 0:
                        ShootFireball();
                        CameraShaker.Shake(new BounceShake(shakeParams));
                        if(extraShot)
                        {
                            StartCoroutine(ExampleCoroutine());
                        }
                        break;  
                }
            }
            //canShoot = false;
            shootCooldown = true;
        }

        if (shootCooldown)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                countdown = timeBetweenShots;

                //canShoot = true;
                shootCooldown = false;
            }
        }
    }


 
    public Vector3 GetDirection()
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

    IEnumerator ExampleCoroutine()
    {    
        yield return new WaitForSeconds(0.15f);
        ShootFireball();
        CameraShaker.Shake(new BounceShake(shakeParams));
    }

}
