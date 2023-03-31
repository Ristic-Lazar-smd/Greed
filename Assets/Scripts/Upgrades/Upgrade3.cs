using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade3 : MonoBehaviour
{
    public GameObject player;

    public void AddUpgrade()
    {
        player.GetComponentInChildren<ManualShoot>(true).timeBetweenShots -= 0.1f;
    }
}
