using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Upgrade2 : MonoBehaviour
{
    public void Start()
    {
        this.GetComponent<PlayerExp>().xpMultiplier += 2;
    }
    public void AddUpgrade()
    {
        this.AddComponent<Upgrade2>();
    }
}
