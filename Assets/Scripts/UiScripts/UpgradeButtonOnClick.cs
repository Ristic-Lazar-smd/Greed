using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonOnClick : MonoBehaviour
{
    public GameObject player;
    public GameObject lvlup;

     public GameObject firstUpgrade;
     public GameObject secondUpgrade;
     public GameObject thirdUpgrade;

     public int first;
     public int second;
     public int third;

    private ListOfXpOrbs listOfXpOrbs;


    private void Awake()
    {
        listOfXpOrbs = GetComponent<ListOfXpOrbs>();
    }
    public void Set()
    {

        firstUpgrade.GetComponent<Button>().onClick.AddListener(delegate { TaskOnClick(first); });
        secondUpgrade.GetComponent<Button>().onClick.AddListener(delegate { TaskOnClick(second); });
        thirdUpgrade.GetComponent<Button>().onClick.AddListener(delegate { TaskOnClick(third); });
    }

    void TaskOnClick(int i)
    {
        Destroy(firstUpgrade);
        Destroy(secondUpgrade);
        Destroy(thirdUpgrade);

        switch(i)
        {
            case 0:
                {
                    player.AddComponent<Upgrade1>();
                    this.GetComponent<GameManager>().ResumeGame();
                    lvlup.GetComponent<LvlUpUi>().HideLvlUpUi();
                    foreach (GameObject orb in listOfXpOrbs.xpOrbs)
                    {
                        orb.GetComponent<XP>().canBePickedUp = true;
                        orb.GetComponent<CircleCollider2D>().enabled = true;
                    }
                }
                break;
            case 1:
                {
                    player.AddComponent<Upgrade2>();
                    this.GetComponent<GameManager>().ResumeGame();
                    lvlup.GetComponent<LvlUpUi>().HideLvlUpUi();
                    foreach (GameObject orb in listOfXpOrbs.xpOrbs)
                    {
                        orb.GetComponent<XP>().canBePickedUp = true;
                        orb.GetComponent<CircleCollider2D>().enabled = true;
                    }
                }
                break;
            case 2:
                {
                    player.AddComponent<Upgrade3>();
                    this.GetComponent<GameManager>().ResumeGame();
                    lvlup.GetComponent<LvlUpUi>().HideLvlUpUi();
                    foreach (GameObject orb in listOfXpOrbs.xpOrbs)
                    {
                        orb.GetComponent<XP>().canBePickedUp = true;
                        orb.GetComponent<CircleCollider2D>().enabled = true;
                    }
                }
                break;
            case 3:
                {
                    player.AddComponent<CbExtraShot>();
                    this.GetComponent<GameManager>().ResumeGame();
                    lvlup.GetComponent<LvlUpUi>().HideLvlUpUi();
                    foreach (GameObject orb in listOfXpOrbs.xpOrbs)
                    {
                        orb.GetComponent<XP>().canBePickedUp = true;
                        orb.GetComponent<CircleCollider2D>().enabled = true;
                    }
                }
                break;
            case 4:
                {
                    player.AddComponent<ExplosionUpgrade>();
                    this.GetComponent<GameManager>().ResumeGame();
                    lvlup.GetComponent<LvlUpUi>().HideLvlUpUi();
                    foreach (GameObject orb in listOfXpOrbs.xpOrbs)
                    {
                        orb.GetComponent<XP>().canBePickedUp = true;
                        orb.GetComponent<CircleCollider2D>().enabled = true;
                    }
                }
                break;
            case 5:
                {
                    player.AddComponent<ArrowWallBounce>();
                    this.GetComponent<GameManager>().ResumeGame();
                    lvlup.GetComponent<LvlUpUi>().HideLvlUpUi();
                    foreach (GameObject orb in listOfXpOrbs.xpOrbs)
                    {
                        orb.GetComponent<XP>().canBePickedUp = true;
                        orb.GetComponent<CircleCollider2D>().enabled = true;
                    }
                }
                break;
        }
    }
}
