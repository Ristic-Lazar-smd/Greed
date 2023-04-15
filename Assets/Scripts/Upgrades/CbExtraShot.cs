using CameraShake;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CbExtraShot : MonoBehaviour
{
    private void Start()
    {
        this.GetComponent<ManualShoot>().extraShot = true;
    }

    public void AddUpgrade()
    {
        this.AddComponent<CbExtraShot>();
    }
}
