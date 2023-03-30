using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponState : MonoBehaviour
{
    StateMachine stateMachine;
    ComboCharacter comboCharacter;
    ManualShoot manualShoot;
    AutoShoot autoShoot;
    bool weaponStateIsMelee;
    /*public bool WeaponStateIsMelee {get{return _weaponStateIsMelee;}
        set{
            _weaponStateIsMelee = value;
            if(_weaponStateIsMelee){
                stateMachine.enabled=true;
                comboCharacter.enabled=true;

                manualShoot.enabled = false;
            } else{
                manualShoot.enabled = true;

                stateMachine.enabled=false;
                comboCharacter.enabled=false;
            }
        }
    }*/
    
    void Awake(){
        stateMachine = GetComponent<StateMachine>();
        comboCharacter = GetComponent<ComboCharacter>();
        manualShoot = GetComponent<ManualShoot>();
        autoShoot = GetComponentInChildren<AutoShoot>();
    }
    void Start()
    {
        weaponStateIsMelee = false;
        SwitchWeaponState();
    }

    void Update()
    {
        
    }

    public void SwitchWeaponState(){
        weaponStateIsMelee = !weaponStateIsMelee;

        if (weaponStateIsMelee){
            stateMachine.enabled=true;
            comboCharacter.enabled=true;

            manualShoot.enabled = false;
        }else{
            manualShoot.enabled = true;

            stateMachine.enabled=false;
            comboCharacter.enabled=false;
        }
    }
}
