using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExp : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject lvlUpUi;
    public GameObject xpBar;
    Slider slider;

    public float xpMultiplier = 1;
    public int XP = 0;
    public int[] xpThresholds;
    public int lvl = 0;

    void Awake()
    {
        lvlUpUi.SetActive(false);
        slider = xpBar.GetComponent<Slider>();
    }
    void Start(){
        slider.maxValue = xpThresholds[lvl];
        slider.value = XP;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("XP"))
        {
            XP = XP + collision.gameObject.GetComponent<XP>().xpGain;
            Destroy(collision.gameObject);
            slider.value = XP * xpMultiplier;

            if(XP >= xpThresholds[lvl]){
                slider.value = 0;
                XP = 0;
                gameManager.PauseGame();
                lvl++;
                lvlUpUi.SetActive(true);
                gameManager.canBeUnPaused=false;

                slider.maxValue = xpThresholds[lvl];
                slider.value = XP;
            }
        }
    }
}
