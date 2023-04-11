using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    UiScore uiKills;
    Vector3 dir;
    HitEffect hitEffect;

    [Tooltip("Kolicina offseta, sto veći broj to je dalje od playera i bliže mišu")][SerializeField]float spawnOffset;
    [SerializeField]float bulletSpeed = 10;
    public int bulletDmg;
    [HideInInspector]public bool pierce=false;


    private void Awake()
    {
        uiKills = GameObject.Find("Score").GetComponent<UiScore>();
        hitEffect = PlayerMovement.playerInstance.GetComponentInChildren<HitEffect>();

    }

    public void Setup(Vector3 shootDir)
    {
        dir = shootDir;
        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(shootDir));
        Destroy(gameObject, 2f); //brise gameobject na kome je ova skripta posle 2s
        transform.position += dir * spawnOffset;
    }

    void FixedUpdate()
    {
        transform.position += bulletSpeed * Time.deltaTime * dir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!pierce)Destroy(this.gameObject);
            if (hitEffect.shouldStack)hitEffect.OnHit(collision.gameObject);

        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }

    }



    //<----------------NEBITNA STVAR, KORISTIM SAMO DA PREVEDEM UGAO---------------->//
    public float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }

}

