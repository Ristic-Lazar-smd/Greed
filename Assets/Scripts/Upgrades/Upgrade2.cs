using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade2 : MonoBehaviour
{
    public GameObject player;

    public void AddUpgrade()
    {
        player.GetComponent<PlayerExp>().xpMultiplier += 2;
    }
}
