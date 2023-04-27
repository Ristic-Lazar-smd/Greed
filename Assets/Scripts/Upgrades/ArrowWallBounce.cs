using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowWallBounce : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<ManualShoot>().bulletType.gameObject.GetComponent<Bullet>().bounce = true;
    }

    public void AddUpgrade()
    {
        this.AddComponent<ArrowWallBounce>();
    }
}
