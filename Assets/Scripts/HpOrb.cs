using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpOrb : MonoBehaviour
{
    [HideInInspector] public GameObject player;
    private Rigidbody2D thisRigidBody;

    public float range;
    public float speed;
    private float distance;
    public int percentageOfMaxHpGained;

    private void Awake()
    {
        Physics2D.IgnoreLayerCollision(8, 6, true); //ignore enemy
        Physics2D.IgnoreLayerCollision(8, 7, true); //ignore echosearch

        //player = GameObject.Find("Player");
        thisRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
    }

    void FixedUpdate()
    {
        if (distance <= range && (player.GetComponent<DamageableCharacter>()._health < player.GetComponent<DamageableCharacter>().maxHp))
        {
            thisRigidBody.drag = 0;
            thisRigidBody.velocity = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y).normalized * speed;
        }
        else if (distance > range)
        {
            thisRigidBody.drag = 100;
        }
    }

}
