using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExp : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject lvlUpUi;
    public GameObject xpBar;
    public Animator hpXpMaskAnimator;
    Slider slider;

    public float xpMultiplier = 1;
    public float XP = 0;
    public int[] xpThresholds;
    public int lvl = 0;

    void Awake()
    {
        lvlUpUi.SetActive(false);
        slider = xpBar.GetComponent<Slider>();
    }
    void Start()
    {
        slider.maxValue = xpThresholds[lvl];
        slider.value = XP;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("XP"))
        {
            XP = XP + collision.gameObject.GetComponent<XP>().xpGain * xpMultiplier;
            Destroy(collision.gameObject);
            slider.value = XP * xpMultiplier;

            if (XP >= xpThresholds[lvl])
            {
                slider.value = 0;
                XP = 0;
                gameManager.PauseGame();
                lvl++;
                lvlUpUi.SetActive(true);
                this.GetComponent<UpgradePicker>().Pick();
                gameManager.canBeUnPaused = false;
                slider.maxValue = xpThresholds[lvl];
                slider.value = XP;


                switch (lvl)
                {
                    case 1: { hpXpMaskAnimator.CrossFade("xplvl1", 0, 0); } return;
                    case 2: { hpXpMaskAnimator.CrossFade("xplvl2", 0, 0); } return;
                    case 3: { hpXpMaskAnimator.CrossFade("xplvl3", 0, 0); } return;
                    case 4: { hpXpMaskAnimator.CrossFade("xplvl4", 0, 0); } return;
                    case 5: { hpXpMaskAnimator.CrossFade("xplvl5", 0, 0); } return;


                }

            }
        }
    }
}
