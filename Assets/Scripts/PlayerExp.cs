using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExp : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject lvlUpUi;
    public GameObject xpBar;

    
    public int XP = 0;
    public int[] xpThresholds;
    public int lvl = 0;

    void Awake()
    {
        lvlUpUi.SetActive(false);
    }

    private void Update()
    {
        xpBar.GetComponent<Slider>().maxValue = xpThresholds[lvl];
        xpBar.GetComponent<Slider>().value = XP;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("XP"))
        {
            XP = XP + collision.gameObject.GetComponent<XP>().xpGain;
            Destroy(collision.gameObject);

            if(XP >= xpThresholds[lvl]){
                xpBar.GetComponent<Slider>().value = 0;
                XP = 0;
                gameManager.PauseGame();
                lvl++;
                lvlUpUi.SetActive(true);
                gameManager.canBeUnPaused=false;
                
            }
        }
    }
}
