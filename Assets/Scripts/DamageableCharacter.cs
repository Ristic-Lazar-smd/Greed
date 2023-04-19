using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class DamageableCharacter : MonoBehaviour
{
    //<-----NE DIRAJ KOMENTARISAN KOD POTREBAN MI JE KASNIJE----->//

    //public GameObject ui;
    public GameObject hpBar;
    Animator animator;
    Rigidbody2D rb;
    Collider2D phyCollider;
    ColoredFlash flash;

    public bool isPlayer = true;
    public bool canTurnInvincible = false;
    public bool disableSimulation = false;
    
    public float knockedBackTime = 0.25f;
    float knockedBackTimeElapsed = 0f;
    public float invincibilityTime = 0.25f;
    
    //bool invincible = false;
    //bool isDead = false;
    float invincibleTimeElapsed = 0f;

    public float _health = 3;
    public float maxHp;
    public bool _targetable = true;
    public bool _invincible = false;
    public bool _knockedBack = false;
    public bool KnockedBack{get{return _knockedBack;}
        set{
            _knockedBack=value;
            if(_knockedBack){
            knockedBackTimeElapsed=0f;
            }
        }
    }
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

        //ui.GetComponent<UiHpPlayer>().UiChangeHp((int)Health);

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        phyCollider = GetComponent<Collider2D>();

        //animator.SetBool("isAlive", true);
    }
    private void Update()
    {
        hpBar.GetComponent<Slider>().maxValue = maxHp;
        hpBar.GetComponent<Slider>().value = Health;
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
        if(KnockedBack){
            knockedBackTimeElapsed +=Time.deltaTime;
            if(knockedBackTimeElapsed > knockedBackTime) KnockedBack=false;
        }
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
    public void OnPlayerHit(float damage, Vector2 knockback)
    {
        if (!Invincible)
        {
            Health -= damage;
            if (canTurnInvincible)Invincible = true;
            if (Health <= 0) SceneManager.LoadScene("DeathScene");
            OnKnockback(knockback);
        }
    }
    public void OnKnockback(Vector2 knockback){
        rb.AddForce(knockback, ForceMode2D.Impulse);
        KnockedBack=true;
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
    void UiChangeHpPlayer(float hp)
    {
    }
}
