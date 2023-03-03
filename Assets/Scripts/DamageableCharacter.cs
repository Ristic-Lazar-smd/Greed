using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageableCharacter : MonoBehaviour
{
    //<-----NE DIRAJ KOMENTARISAN KOD POTREBAN MI JE KASNIJE----->//

    public GameObject ui;
    public GameObject hpBar;
    Animator animator;
    Rigidbody2D rb;
    Collider2D phyCollider;
    ColoredFlash flash;

    public bool isPlayer = true;
    public bool canTurnInvincible = false;
    public bool disableSimulation = false;
    public float invincibilityTime = 0.25f;
    
    //bool invincible = false;
    //bool isDead = false;
    float invincibleTimeElapsed = 0f;

    public float _health = 3;
    public int maxHp;
    public bool _targetable = true;
    public bool _invincible = false;
    public float Health { get { return _health; }
        set
        {
            _health = value;

            if (_health <= 0)
            {
                //animator.SetBool("isAlive", false);
                Targetable = false;
            }           
        } 
    }

    public bool Targetable { get { return _targetable; }
        set
        {
            _targetable = value;

            if (disableSimulation)
            {
                rb.simulated = false;
            }
            phyCollider.enabled = false;
        }
    }

    public bool Invincible { get { return _invincible; }
        set
        {
            _invincible = value;

            if (_invincible)
            {
                invincibleTimeElapsed = 0f;
                
                flash.duration = invincibilityTime;
                flash.FlashMultiple(Color.white);         
            }
        }
    }
    void Start()
    {
        if(TryGetComponent<ColoredFlash>(out ColoredFlash _flash)){
            flash= _flash;
        }

        ui.GetComponent<UiHpPlayer>().UiChangeHp((int)Health);

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        phyCollider = GetComponent<Collider2D>();

        //animator.SetBool("isAlive", true);
    }
 
    public void OnHit(float damage)
    {
        if (!Invincible)
        {
            Health -= damage;

            if (canTurnInvincible)
            {
                Invincible = true;
            }
        }
    }
    public void OnPlayerHit(float damage)
    {
        if (!Invincible)
        {
            Health -= damage;
            ui.GetComponent<UiHpPlayer>().UiChangeHp((int)Health);

            if (canTurnInvincible)
            {
                Invincible = true;
            }
        }
    }
    public void OnHit(float damage, Vector2 knockback)
    {
        if (!Invincible)
        {
            Health -= damage;
            rb.AddForce(knockback, ForceMode2D.Impulse);

            if (canTurnInvincible)
            {
                Invincible = true;
            }
        }
    }

    public void OnObjectDestroyed()
    {
        Destroy(gameObject);
    }

    public void FixedUpdate()
    {
        if (Invincible)
        {

            invincibleTimeElapsed += Time.deltaTime;
            if(invincibleTimeElapsed > invincibilityTime)
            {
                Invincible = false;
            }
        }
    }

    private void Update()
    {
        hpBar.GetComponent<Slider>().maxValue = maxHp;
        hpBar.GetComponent<Slider>().value = _health;
    }

    void UiChangeHpPlayer(float hp)
    {

    }


}
