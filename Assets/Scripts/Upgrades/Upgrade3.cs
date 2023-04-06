using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Upgrade3 : MonoBehaviour
{
    public void Start()
    {
        this.GetComponentInChildren<ManualShoot>(true).timeBetweenShots -= 0.1f;
    }
    public void AddUpgrade()
    {
        this.AddComponent<Upgrade3>();
    }
}
