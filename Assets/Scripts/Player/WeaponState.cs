using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponState : MonoBehaviour
{
    public static WeaponState instance;
    [SerializeField] GameObject crossbow;
    [SerializeField] MeleeMain meleeMain;
    StateMachine stateMachine;
    ComboCharacter comboCharacter;
    ManualShoot manualShoot;
    AutoShoot autoShoot;
    CrossbowSpecial crossbowSpecial;
    SwordSpecial swordSpecial;
    [Tooltip("Pass MeleeFloat gameobject")]
    Animator meleeAnimator;
    public bool weaponStateIsMelee;
    
    void Awake(){
        stateMachine = GetComponent<StateMachine>();
        comboCharacter = GetComponent<ComboCharacter>();
        manualShoot = GetComponent<ManualShoot>();
        autoShoot = GetComponentInChildren<AutoShoot>();
        crossbowSpecial = GetComponentInChildren<CrossbowSpecial>();
        swordSpecial = GetComponentInChildren<SwordSpecial>();
        meleeAnimator = meleeMain.GetComponentInChildren<Animator>();

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

    public bool CanSwitch(){
        if (!meleeAnimator.GetCurrentAnimatorStateInfo(0).IsName("MeleeIdle") || crossbowSpecial.chargeSpecial || swordSpecial.isSpinning) return false;

        else return true;
    }

    public void SwitchWeaponState(){
        if(!CanSwitch()) return;

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
