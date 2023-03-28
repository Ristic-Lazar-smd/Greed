using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHpOrb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HpOrb"))
        {
            if(this.gameObject.GetComponent<DamageableCharacter>().Health != this.gameObject.GetComponent<DamageableCharacter>().maxHp)
            {
                this.gameObject.GetComponent<DamageableCharacter>().Health = this.gameObject.GetComponent<DamageableCharacter>().Health + collision.gameObject.GetComponent<HpOrb>().hpGain;
                Destroy(collision.gameObject);
            }         
        }
    }
}
