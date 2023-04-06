using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackEffect : MonoBehaviour
{
    [SerializeField] float destroyTime = 3f;
    [SerializeField] float offsetUp = 0.2f;


    public void SetStack(){
        Destroy(gameObject, destroyTime);
        transform.localPosition += new Vector3(1/10+0.2f,offsetUp,10);
    }
}
