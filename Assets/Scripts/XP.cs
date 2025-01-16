using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class XP : MonoBehaviour
{
    [HideInInspector]public GameObject player;
    private Rigidbody2D thisRigidBody;

    public float range;
    public float speed;
    private float distance;
    public int xpGain;
    public bool canBePickedUp = true;

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
    void FixedUpdate(){
        if ((distance <= range) && (canBePickedUp==true))
        {
            thisRigidBody.linearDamping = 0;
            thisRigidBody.linearVelocity=new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y).normalized * speed;
        }
        else if(distance > range)
        {
            thisRigidBody.linearDamping = 10;
        }
    }
}
