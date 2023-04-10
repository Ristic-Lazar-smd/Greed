using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpOrb : MonoBehaviour
{
    private DamageableCharacter damageableCharacter;
    public GameObject hpBar;
    private Slider slider;


    private void Awake()
    {
        damageableCharacter = this.GetComponent<DamageableCharacter>();
        slider = hpBar.GetComponent<Slider>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HpOrb"))
        {
            //if(this.gameObject.GetComponent<DamageableCharacter>().Health != this.gameObject.GetComponent<DamageableCharacter>().maxHp)
            //{
            //    //this.gameObject.GetComponent<DamageableCharacter>().Health = this.gameObject.GetComponent<DamageableCharacter>().Health + collision.gameObject.GetComponent<HpOrb>().hpGain;
            //    this.gameObject.GetComponent<DamageableCharacter>().Health = this.gameObject.GetComponent<DamageableCharacter>().Health + (this.gameObject.GetComponent<DamageableCharacter>().maxHp / (collision.gameObject.GetComponent<HpOrb>().percentageOfMaxHpGained/10));



            //    hpBar.GetComponent<Slider>().maxValue = maxHp;
            //    hpBar.GetComponent<Slider>().value = _health;
            //    Destroy(collision.gameObject);
            //}         

            if (damageableCharacter.Health != damageableCharacter.maxHp)
            {
                //this.gameObject.GetComponent<DamageableCharacter>().Health = this.gameObject.GetComponent<DamageableCharacter>().Health + collision.gameObject.GetComponent<HpOrb>().hpGain;
                damageableCharacter.Health = damageableCharacter.Health + (damageableCharacter.maxHp / (collision.gameObject.GetComponent<HpOrb>().percentageOfMaxHpGained / 10));

                if(damageableCharacter.Health > damageableCharacter.maxHp)
                {
                    damageableCharacter.Health = damageableCharacter.maxHp;
                }

                //slider.maxValue = damageableCharacter.maxHp;
                //slider.value = damageableCharacter.Health;
                Destroy(collision.gameObject);
            }
        }
    }
}
