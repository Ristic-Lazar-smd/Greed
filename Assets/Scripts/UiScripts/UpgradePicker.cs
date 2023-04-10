using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePicker : MonoBehaviour
{
    public List<GameObject> upgrades = new List<GameObject>();
    public GameObject canvas;
    public GameObject Manager;
    private UpgradeButtonOnClick updateManager;

    private int random;
    private GameObject firstPrefab;
    private GameObject secondPrefab;
    private GameObject thirdPrefab;

    private GameObject first;
    private GameObject second;
    private GameObject third;

    private int temp1;
    private int temp2;
    private int temp3;

    //public UpgradeButtonOnClick upgrade;

    public void Pick()
    {
        random = Random.Range(0, upgrades.Count);
        firstPrefab = upgrades[random];
        temp1 = random;

        random = Random.Range(0, upgrades.Count);
        secondPrefab = upgrades[random];
        temp2 = random;

        random = Random.Range(0, upgrades.Count);
        thirdPrefab = upgrades[random];
        temp3 = random;
  

        first = Instantiate(firstPrefab, canvas.transform);
        second = Instantiate(secondPrefab, canvas.transform);
        third = Instantiate(thirdPrefab, canvas.transform);


        first.GetComponent<RectTransform>().localPosition = new Vector3(-596.0f,0,0);
        second.GetComponent<RectTransform>().localPosition = new Vector3(14.0f, 0, 0);
        third.GetComponent<RectTransform>().localPosition = new Vector3(596.0f, 0, 0);

        SendUpgrades();
    }
    public void SendUpgrades()
    {
        updateManager = Manager.GetComponent<UpgradeButtonOnClick>();

        updateManager.firstUpgrade = first;
        updateManager.secondUpgrade = second;
        updateManager.thirdUpgrade = third;
        updateManager.first = temp1;
        updateManager.second = temp2;
        updateManager.third = temp3;

        updateManager.Set();
    }
}
