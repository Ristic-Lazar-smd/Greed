using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlUpUi : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject mcamera;
    
    void Start()
    {

        transform.position=new Vector3(mcamera.transform.position.x,mcamera.transform.position.y,1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HideLvlUpUi(){
        gameObject.SetActive(false);
        gameManager.canBeUnPaused=true;
    }

}
