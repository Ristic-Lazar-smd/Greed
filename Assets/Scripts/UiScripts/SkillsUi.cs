using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsUi : MonoBehaviour
{
    public Image spaceUi;
    public Sprite pressedSpaceUiImage;
    Sprite notPressedSpaceUiImage;

    public Image leftClickUi;
    public Sprite pressedLeftClickUiImage;
    Sprite notPressedLeftClickUiImage;

    public Image rightClickUi;
    public Sprite pressedRightClickUiImage;
    Sprite notPressedRightClickUiImage;

    public Image qUi;
    public Sprite pressedQUiImage;
    Sprite notPressedQUiImage;

    public WeaponState weaponSwitch;

    public Sprite[] weaponImageList;
    int imageTracker=0;

    void Start()
    {
        notPressedSpaceUiImage = spaceUi.sprite;
        notPressedLeftClickUiImage = leftClickUi.sprite;
        notPressedRightClickUiImage = rightClickUi.sprite;
        notPressedQUiImage = qUi.sprite;
    }

    void Update()
    {
        //SPACE//
        if (Input.GetKeyDown(KeyCode.Space)){
            spaceUi.sprite = pressedSpaceUiImage;
        }else if (Input.GetKeyUp(KeyCode.Space)){
                spaceUi.sprite = notPressedSpaceUiImage;
        }
        //LEFT CLICK//
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            leftClickUi.sprite = pressedLeftClickUiImage;
        }else if (Input.GetKeyUp(KeyCode.Mouse0)){
                leftClickUi.sprite = notPressedLeftClickUiImage;
        }
        //RIGHT CLICK//
        if (Input.GetKeyDown(KeyCode.Mouse1)){
            rightClickUi.sprite = pressedRightClickUiImage;
        }else if (Input.GetKeyUp(KeyCode.Mouse1)){
                rightClickUi.sprite = notPressedRightClickUiImage;
        }
        //Q CLICK//
        if (Input.GetKeyDown(KeyCode.Q)){
            qUi.sprite = pressedQUiImage;
            weaponSwitch.SwitchWeaponState();
            //menjam weapon icon//ovo M O R A M da optimizujem wtf je ovaj spaghetti code bato //
            leftClickUi.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = weaponImageList[imageTracker%2];
            imageTracker++;
        }else if (Input.GetKeyUp(KeyCode.Q)){
                qUi.sprite = notPressedQUiImage;     
        }

    }
}
