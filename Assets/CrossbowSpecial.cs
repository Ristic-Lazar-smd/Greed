using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowSpecial : MonoBehaviour
{
    public Transform bulletType;
    ManualShoot manualShoot;

    public bool canFireSpecial=true;
    float timer;
    public float specialCooldown;
    bool chargeSpecial=false;
    float charge;
    int chargeDamage;
    public int chargeDamageStage0;
    public int chargeDamageStage1;
    public int chargeDamageStage2;
    public int chargeDamageStage3;
    [Tooltip("In seconds")]public float stage1Threshold;
    [Tooltip("In seconds")]public float stage2Threshold;
    [Tooltip("In seconds")]public float stage3Threshold;


    void Awake()
    {
        manualShoot = transform.parent.gameObject.GetComponent<ManualShoot>();
    }

    void Update()
    {
        //special fire cooldown
        if (!canFireSpecial){
            if (timer > 0) timer -= Time.deltaTime;
            else {
                canFireSpecial=true;
                timer = specialCooldown;
            }
        }

        if(chargeSpecial){
            charge += Time.deltaTime;
            if (charge>stage3Threshold){
                chargeDamage = chargeDamageStage3;
            }else
            if (charge>stage2Threshold){
                chargeDamage = chargeDamageStage2;
            }else
            if (charge>stage1Threshold){
                chargeDamage = chargeDamageStage1;
            }
        }


        if (Input.GetButtonDown("Fire2") && canFireSpecial){
            charge=0;
            chargeDamage = chargeDamageStage0;
            chargeSpecial=true;
        }
        if (Input.GetButtonUp("Fire2") && canFireSpecial){
            Transform tbullet = Instantiate(bulletType, transform.position, Quaternion.identity);
            Bullet bullet = tbullet.GetComponent<Bullet>();
            bullet.Setup(manualShoot.GetDirection());
            bullet.bulletDmg=chargeDamage;
            bullet.pierce = true;
            canFireSpecial = false;
            chargeSpecial = false;
        }
    }
}
