using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MeleeMain : MonoBehaviour
{
    SpriteRenderer sr;
    [Tooltip("Spawn lokacija strele u relaciji od playera")]public float offset = 2f;
    Quaternion attackAngle;
    void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if(transform.rotation.w < 0.7){
            sr.flipY=true;
        }else sr.flipY=false;

        if (!PlayerMovement.playerInstance.animationLock){
            transform.rotation = AttackDirection();
        }
        //PlayerMovement.playerInstance.stepDirection = PlayerMovement.playerInstance.transform.InverseTransformPoint(transform.GetChild(0).position);
       
    }
    void FixedUpdate(){

    }


    public Quaternion AttackDirection(){
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; 
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; 
        return Quaternion.Euler(0f, 0f, rotation_z + offset);
    }
}
