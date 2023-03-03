using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    UiScore uiKills;

    public Vector3 dir;
    public float bulletSpeed = 10;
    public int bulletDmg;


    private void Awake()
    {
        uiKills = GameObject.Find("Score").GetComponent<UiScore>();
    }

    public void Setup(Vector3 shootDir)
    {
        dir = shootDir;
        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(shootDir));
        Destroy(gameObject, 2f); //brise gameobject na kome je ova skripta posle 2s
        
    }

    void FixedUpdate()
    {
        transform.position += bulletSpeed * Time.deltaTime * dir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //collision.GetComponent<XpDrop>().Drop();
            //uiKills.ChangeScore(collision.gameObject.GetComponent<XpDrop>().scoreWorth);
            Destroy(this.gameObject);
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

