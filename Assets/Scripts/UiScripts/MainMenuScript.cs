using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    //public List<Button> buttons = new List<Button>();

    //private bool selected = false;
    //private int selectedIndex = 6;

    public void PlayGame()
    {
        SceneManager.LoadScene("CombatTest");   
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void FixedUpdate()
    {
        //if(Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    if(selectedIndex == 10)
        //    {
        //        buttons[0].Select();
        //        selectedIndex = 0;
        //    }
        //    else if(selectedIndex == 5)
        //    {
        //        buttons[0].Select();
        //        selectedIndex = 0;
        //    }
        //    else
        //    {
        //        selectedIndex++;
        //        buttons[selectedIndex].Select();
        //    }
        //}

        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    if (selectedIndex == 10)
        //    {
        //        buttons[0].Select();
        //        selectedIndex = 0;
        //    }
        //    else if (selectedIndex == 0)
        //    {
        //        buttons[5].Select();
        //        selectedIndex = 5;
        //    }
        //    else
        //    {
        //        selectedIndex--;
        //        buttons[selectedIndex].Select();
        //    }
        //}



        //if(Input.GetKey(KeyCode.DownArrow))
        //{
        //    switch(selectedIndex)
        //    {
        //        case 0:
        //            {
        //                buttons[1].Select();
        //            }break;
        //        case 1:
        //            {
        //                buttons[2].Select();
        //            }
        //            break;
        //        case 2:
        //            {
        //                buttons[3].Select();
        //            }
        //            break;
        //        case 3:
        //            {
        //                buttons[4].Select();
        //            }
        //            break;
        //        case 4:
        //            {
        //                buttons[5].Select();
        //            }
        //            break;
        //        case 5:
        //            {
        //                buttons[0].Select();
        //            }
        //            break;
        //        case 6:
        //            {
        //                buttons[0].Select();
        //            }
        //            break;
        //    }
        //}
        //else if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    switch (selectedIndex)
        //    {
        //        case 0:
        //            {
        //                buttons[5].Select();
        //            }
        //            break;
        //        case 1:
        //            {
        //                buttons[0].Select();
        //            }
        //            break;
        //        case 2:
        //            {
        //                buttons[1].Select();
        //            }
        //            break;
        //        case 3:
        //            {
        //                buttons[2].Select();
        //            }
        //            break;
        //        case 4:
        //            {
        //                buttons[3].Select();
        //            }
        //            break;
        //        case 5:
        //            {
        //                buttons[4].Select();
        //            }
        //            break;
        //        case 6:
        //            {
        //                buttons[0].Select();
        //            }break;
        //    }
        //}
    }
}
