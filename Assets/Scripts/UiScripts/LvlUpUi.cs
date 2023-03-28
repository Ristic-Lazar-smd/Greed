using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlUpUi : MonoBehaviour
{
    public GameManager gameManager;
    
    void Start()
    {

        this.gameObject.SetActive(true);
    }

    // Update is called once per frame

    public void HideLvlUpUi(){
        gameObject.SetActive(false);
        gameManager.canBeUnPaused=true;
    }

}
