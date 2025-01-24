using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


public class Bullet : MonoBehaviour
{
    UiScore uiKills;
    Vector3 dir;
    Vector2 reflectDir;
    Vector2 pointOfContact;
    HitEffect hitEffect;

    [Tooltip("Kolicina offseta, sto veći broj to je dalje od playera i bliže mišu")][SerializeField]float spawnOffset;
    [SerializeField]float bulletSpeed = 10;
    public int bulletDmg;
    [HideInInspector]public bool pierce=false;
    public bool bounce;
    private Rigidbody2D rb;
    private Vector3 lastVelocity;

    private Transform playerTransform;


    private void Awake()
    {
        uiKills = GameObject.Find("Score").GetComponent<UiScore>();
        hitEffect = PlayerMovement.playerInstance.GetComponentInChildren<HitEffect>();
        rb = this.GetComponent<Rigidbody2D>();
        playerTransform = PlayerMovement.playerInstance.GetComponent<Transform>();
    }

    public void Setup(Vector3 shootDir)
    {
        dir = shootDir;
        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(dir));
        Destroy(gameObject, 2f); //brise gameobject na kome je ova skripta posle 2s
        transform.position += dir * spawnOffset;

        if(bounce){
            CastRay();
        }
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
            if(bounce==false)
            {
                Destroy(this.gameObject);
            }
            else
            {
                dir = reflectDir;
                transform.position=pointOfContact; // zato sto vrh strele udari u zid a strela se rotira oko centra mase pa se odbija pod pogresnim uglom
                transform.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(dir));
                bounce = false;
            }
        }
    }

   void CastRay(){
    /*Castujem ray i uz pomoc njega racunam izlazni ugao i tacku udarca, ray moze da pogodi samo zid zbog maske*/
        LayerMask mask = LayerMask.GetMask("Wall");
        RaycastHit2D hit = Physics2D.Raycast(transform.position,dir,100,mask);
        reflectDir = (Vector2.Reflect(dir,hit.normal)).normalized;
        pointOfContact=hit.point;

        //Debug.DrawRay(transform.position,dir*100,Color.red,5,false);
        //Debug.DrawRay(hit.point,reflectDir*100,Color.blue,5,false);
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

