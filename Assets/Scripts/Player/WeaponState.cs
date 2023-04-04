using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponState : MonoBehaviour
{
    public static WeaponState instance;
    public GameObject crossbow;
    StateMachine stateMachine;
    ComboCharacter comboCharacter;
    ManualShoot manualShoot;
    AutoShoot autoShoot;
    public bool weaponStateIsMelee;
    
    void Awake(){
        stateMachine = GetComponent<StateMachine>();
        comboCharacter = GetComponent<ComboCharacter>();
        manualShoot = GetComponent<ManualShoot>();
        autoShoot = GetComponentInChildren<AutoShoot>();
        instance=this;
    }
    void Start()
    {
        weaponStateIsMelee = false;
        SwitchWeaponState();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && autoShoot.enabled)
        {
            autoShoot.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.E) && !autoShoot.enabled)
        {
            autoShoot.enabled = true;
        }
    }

    public void SwitchWeaponState(){
        weaponStateIsMelee = !weaponStateIsMelee;

        if (weaponStateIsMelee){
            stateMachine.enabled=true;
            comboCharacter.enabled=true;

            manualShoot.enabled = false;
            crossbow.SetActive(false);
        }else{
            manualShoot.enabled = true;
            crossbow.SetActive(true);

            stateMachine.enabled=false;
            comboCharacter.enabled=false;
        }
    }
}
