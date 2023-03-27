using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAfterImage : MonoBehaviour
{
    [SerializeField]
    private float activeTime = 0.1f;
    private float timeActivated;
    private float alpha;
    [SerializeField]
    private float alphaSet = 0.8f;
    private float alphaMultiplier = 0.85f;

    private Transform player;
    private SpriteRenderer SR;
    private SpriteRenderer playerSR;

    private Color color;

    private void OnEnable()
    {
        player = PlayerMovement.playerInstance.transform;
        SR = GetComponent<SpriteRenderer>();
        playerSR = player.GetComponent<SpriteRenderer>();

        alpha = alphaSet;
        SR.sprite = playerSR.sprite;

        if (player.GetComponent<PlayerMovement>().bodyVelocityXNormalized < 0)
        {
            SR.flipX= true;
        }
        else if (player.GetComponent<PlayerMovement>().bodyVelocityXNormalized > 0 /*|| Input.GetButtonDown("Fire1")*/)
        {
            SR.flipX = false;
        }

        transform.position = player.position;
        transform.rotation = player.rotation;
        transform.localScale = player.localScale;
        timeActivated = Time.time;
    }

    private void Update()
    {
        alpha *= alphaMultiplier;
        color = new Color(1.0f, 1.0f, 1.0f, alpha);
        SR.color = color;

        if(Time.time >= (timeActivated + activeTime))
        {
            PoolPlayerAfterImage.Instance.AddToPool(gameObject);
        }
    }
}
