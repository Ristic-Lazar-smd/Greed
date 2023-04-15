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
                    Debug.Log("HP!");
                    player.AddComponent<Upgrade1>();
                    this.GetComponent<GameManager>().ResumeGame();
                    lvlup.GetComponent<LvlUpUi>().HideLvlUpUi();
                }break;
            case 1:
                {
                    Debug.Log("XP!");
                    player.AddComponent<Upgrade2>();
                    this.GetComponent<GameManager>().ResumeGame();
                    lvlup.GetComponent<LvlUpUi>().HideLvlUpUi();
                }
                break;
            case 2:
                {
                    Debug.Log("AS!");
                    player.AddComponent<Upgrade3>();
                    this.GetComponent<GameManager>().ResumeGame();
                    lvlup.GetComponent<LvlUpUi>().HideLvlUpUi();
                }
                break;
            case 3:
                {
                    Debug.Log("EXTRA SHOT");
                    player.AddComponent<CbExtraShot>();
                    this.GetComponent<GameManager>().ResumeGame();
                    lvlup.GetComponent<LvlUpUi>().HideLvlUpUi();
                }
                break;
            case 4:
                {
                    Debug.Log("EXPLOSION");
                    player.AddComponent<ExplosionUpgrade>();
                    this.GetComponent<GameManager>().ResumeGame();
                    lvlup.GetComponent<LvlUpUi>().HideLvlUpUi();
                }
                break;
        }
    }
}
