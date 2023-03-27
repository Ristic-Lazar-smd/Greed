using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    float _xpMultiplier;
    float _runSpeed;
    float _stepSpeed;
    float _invincibilityTime;
    int _maxHp;
    float _timeBetweenShots;
    float _dashDuration;
    float _dashSpeed;
    float _dashCooldown;
    int _swordDmg;
    float _hitStunDuration;
    int _echoExpandRadius;
    float _timeBetweenAutoShots;

    public float XpMultiplier {get{return _xpMultiplier;}
        set{
        _xpMultiplier = value;
        if (TryGetComponent(out PlayerExp playerExp)) {
            playerExp.xpMultiplier=_xpMultiplier;
            }
        }
    }    
    public float RunSpeed {get{return _runSpeed;}
        set{
        _runSpeed = value;
        if (TryGetComponent(out PlayerMovement playerMovement)) {
            playerMovement.runSpeed=_runSpeed;
            }
        }
    }
    public float StepSpeed {get{return _stepSpeed;}
        set{
        _stepSpeed = value;
        if (TryGetComponent(out PlayerMovement playerMovement)) {
            playerMovement.stepSpeed=_stepSpeed;
            }
        }
    }
    public float InvincibilityTime {get{return _invincibilityTime;}
        set{
        _invincibilityTime = value;
        if (TryGetComponent(out DamageableCharacter damageableCharacter)) {
            damageableCharacter.invincibilityTime = _invincibilityTime;
            }
        }
    }
    public int MaxHp {get{return _maxHp;}
        set{
        _maxHp = value;
        if (TryGetComponent(out DamageableCharacter damageableCharacter)) {
            damageableCharacter.maxHp = _maxHp;
            }
        }
    }
    public float TimeBetweenShots {get{return _timeBetweenShots;}
        set{
        _timeBetweenShots = value;
        if (TryGetComponent(out ManualShoot manualShoot)) {
            manualShoot.timeBetweenShots = _timeBetweenShots;
            }
        }
    }
    public float DashDuration {get{return _dashDuration;}
        set{
        _dashDuration = value;
        if (TryGetComponent(out PlayerDash playerDash)) {
            playerDash.dashDuration = _dashDuration;
            }
        }
    }
    public float DashSpeed {get{return _dashSpeed;}
        set{
        _dashSpeed = value;
        if (TryGetComponent(out PlayerDash playerDash)) {
            playerDash.dashSpeed = _dashSpeed;
            }
        }
    }
    public float DashCooldown {get{return _dashCooldown;}
        set{
        _dashCooldown = value;
        if (TryGetComponent(out PlayerDash playerDash)) {
            playerDash.dashCooldown = _dashCooldown;
            }
        }
    }
    public int SwordDmg {get{return _swordDmg;}
        set{
        _swordDmg = value;
        GetComponentInChildren<Sword>().swordDmg = _swordDmg;
        }
    }
    public float HitStunDuration {get{return _hitStunDuration;}
        set{
        _hitStunDuration = value;
        GetComponentInChildren<Sword>().hitStunDuration = _hitStunDuration;
        }
    }
    public int EchoExpandRadius {get{return _echoExpandRadius;}
        set{
        _echoExpandRadius = value;
        GetComponentInChildren<EchoSearch>().echoExpandRadius = _echoExpandRadius;
        }
    }
    public float TimeBetweenAutoShots {get{return _timeBetweenAutoShots;}
        set{
        _timeBetweenAutoShots = value;
        GetComponentInChildren<AutoShoot>().timeBetweenAutoShots = _timeBetweenAutoShots;
        }
    }
    
    void Awake(){
        instance = this;
    }
}
