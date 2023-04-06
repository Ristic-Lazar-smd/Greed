using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Upgrade1 : MonoBehaviour
{
    public void Start()
    {
        this.GetComponent<DamageableCharacter>().maxHp *= 2;
        this.GetComponent<DamageableCharacter>()._health *= 2;
    }
    public void AddUpgrade()
    {
        this.AddComponent<Upgrade1>();
    }
}
