using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowMain : MonoBehaviour
{
    SpriteRenderer sr;
    [Tooltip("Spawn lokacija strele u relaciji od playera")]public float offset = 2f;
    void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        
        if(transform.rotation.w < 0.7){
            sr.flipY=true;
        }else sr.flipY=false;
    }
    void FixedUpdate(){
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; 
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; 
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);
    }
}
