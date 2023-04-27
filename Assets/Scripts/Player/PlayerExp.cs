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
    public GameObject tabToLvlUp;
    Slider slider;
    public GameObject xpOrb;
    private XP canBePickedUp;
    private CircleCollider2D collider;
    private bool tab;
    private ListOfXpOrbs listOfXpOrbs;

    public float xpMultiplier = 1;
    public float XP = 0;
    public int[] xpThresholds;
    public int lvl = 0;

    void Awake()
    {
        lvlUpUi.SetActive(false);
        slider = xpBar.GetComponent<Slider>();
        canBePickedUp = xpOrb.GetComponent<XP>();
        collider = xpOrb.GetComponent<CircleCollider2D>();
        listOfXpOrbs = gameManager.GetComponent<ListOfXpOrbs>();
    }
    void Start()
    {
        slider.maxValue = xpThresholds[lvl];
        slider.value = XP;
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Tab)) && tab == true)
        {
            canBePickedUp.canBePickedUp = true;
            tabToLvlUp.SetActive(false);
            collider.enabled = true;
            tab = false;

            XP = 0;
            gameManager.PauseGame();
            lvl++;
            lvlUpUi.SetActive(true);
            this.GetComponent<UpgradePicker>().Pick();
            gameManager.canBeUnPaused = false;
            slider.maxValue = xpThresholds[lvl];
            //slider.value = XP;
            slider.value = 0;


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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("XP"))
        {
            XP = XP + collision.gameObject.GetComponent<XP>().xpGain * xpMultiplier;
            listOfXpOrbs.xpOrbs.Remove(collision.gameObject);
            Destroy(collision.gameObject);
            slider.value = XP;

            if (XP >= xpThresholds[lvl])
            {
                foreach(GameObject orb in listOfXpOrbs.xpOrbs)
                {
                    orb.GetComponent<XP>().canBePickedUp = false;
                    orb.GetComponent<CircleCollider2D>().enabled = false;
                }
                canBePickedUp.canBePickedUp = false;
                tabToLvlUp.SetActive(true);
                collider.enabled = false;
                tab = true;

                //XP = 0;
                //gameManager.PauseGame();
                //lvl++;
                //lvlUpUi.SetActive(true);
                //this.GetComponent<UpgradePicker>().Pick();
                //gameManager.canBeUnPaused = false;
                //slider.maxValue = xpThresholds[lvl];
                ////slider.value = XP;
                //slider.value = 0;


                //switch (lvl)
                //{
                //    case 1: { hpXpMaskAnimator.CrossFade("xplvl1", 0, 0); } return;
                //    case 2: { hpXpMaskAnimator.CrossFade("xplvl2", 0, 0); } return;
                //    case 3: { hpXpMaskAnimator.CrossFade("xplvl3", 0, 0); } return;
                //    case 4: { hpXpMaskAnimator.CrossFade("xplvl4", 0, 0); } return;
                //    case 5: { hpXpMaskAnimator.CrossFade("xplvl5", 0, 0); } return;


                //}

            }
        }
    }
}
