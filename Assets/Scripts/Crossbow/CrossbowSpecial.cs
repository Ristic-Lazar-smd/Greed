using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CameraShake;
using UnityEngine.UI;

public class CrossbowSpecial : MonoBehaviour
{


    public Transform bulletType;
    ManualShoot manualShoot;

    public bool canFireSpecial = true;
    bool checkPassed = false;
    float timer;
    public float specialCooldown;
    [HideInInspector]public bool chargeSpecial = false;
    float charge;
    int chargeDamage;
    public int chargeDamageStage0;
    public int chargeDamageStage1;
    public int chargeDamageStage2;
    public int chargeDamageStage3;
    [Tooltip("In seconds")] public float stage1Threshold;
    [Tooltip("In seconds")] public float stage2Threshold;
    [Tooltip("In seconds")] public float stage3Threshold;

    [SerializeField] PerlinShake.Params shakeParams1;
    [SerializeField] PerlinShake.Params shakeParams2;
    [SerializeField] PerlinShake.Params shakeParams3;

    public GameObject chargeBar;
    public Slider chargeSlider;
    public Image chargeBarImage;
    private Color chargeColor;
    public Image crossbowSpecialImage;


    void Awake()
    {
        chargeSlider = chargeBar.GetComponent<Slider>();
        manualShoot = transform.parent.gameObject.GetComponent<ManualShoot>();
        chargeBar.SetActive(false); 
        
    }
    void Start(){
        timer = specialCooldown;
    }

    void Update()
    {
        //special fire cooldown
        if (!canFireSpecial)
        {
            if (timer > 0) timer -= Time.deltaTime;
            else
            {
                canFireSpecial = true;
                timer = specialCooldown;
                var tempColor = crossbowSpecialImage.color;
                tempColor.a = 1f;
                crossbowSpecialImage.color = tempColor;
            }
        }

        if (chargeSpecial)
        {
            chargeSlider.maxValue = stage3Threshold;
            chargeBar.SetActive(true);
            charge += Time.deltaTime;
            chargeSlider.value = charge;
            if (charge > stage3Threshold)
            {
                chargeDamage = chargeDamageStage3;
                CameraShaker.Shake(new PerlinShake(shakeParams3));
                chargeColor = chargeBarImage.color;
                chargeColor.g = 0;
                chargeBarImage.color = chargeColor;
            }
            else
            if (charge > stage2Threshold)
            {
                chargeDamage = chargeDamageStage2;
                CameraShaker.Shake(new PerlinShake(shakeParams2));
            }
            else
            if (charge > stage1Threshold)
            {
                chargeDamage = chargeDamageStage1;
                CameraShaker.Shake(new PerlinShake(shakeParams1));
            }
        }


        if (Input.GetButtonDown("Fire2") && canFireSpecial)
        {
            charge = 0;
            chargeSlider.value = charge;
            chargeDamage = chargeDamageStage0;
            chargeSpecial = true;
            checkPassed = true;
            manualShoot.canShoot = false;



        }
        if (Input.GetButtonUp("Fire2") && checkPassed)
        {
            Transform tbullet = Instantiate(bulletType, transform.position, Quaternion.identity);
            Bullet bullet = tbullet.GetComponent<Bullet>();
            bullet.Setup(manualShoot.GetDirection());
            bullet.bulletDmg = chargeDamage;
            bullet.pierce = true;
            canFireSpecial = false;
            chargeSpecial = false;
            checkPassed = false;
            manualShoot.canShoot = true;

            //Charge bar and ui
            charge = 0;
            chargeSlider.value = charge;
            chargeColor.g = 255;
            chargeBarImage.color = chargeColor;
            chargeBar.SetActive(false);
            var tempColor = crossbowSpecialImage.color;
            tempColor.a = 0f;
            crossbowSpecialImage.color = tempColor;

        }
    }
}
