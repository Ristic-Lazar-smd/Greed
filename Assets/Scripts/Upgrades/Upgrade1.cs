using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade1 : MonoBehaviour
{
    public GameObject player;

    public void AddUpgrade()
    {
        player.GetComponent<DamageableCharacter>().maxHp *= 2;
        player.GetComponent<DamageableCharacter>()._health *= 2;
    }
}
