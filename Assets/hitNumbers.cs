using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitNumbers : MonoBehaviour
{
    [SerializeField] float destroyTime = 3f;
    //[SerializeField]Vector3 offset = new Vector3 (0,2,0);
    [SerializeField] float offsetUp = 0.2f;
    [SerializeField] float textLeftToRightOffset=0.15f;
    void Start()
    {
        Destroy(gameObject, destroyTime);
        
        transform.localPosition += new Vector3(Random.Range(-textLeftToRightOffset,textLeftToRightOffset),Random.Range(offsetUp-0.05f,offsetUp+0.05f),10);
    }

    void Update()
    {
        
    }
}
