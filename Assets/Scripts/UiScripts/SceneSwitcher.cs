using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
        if ( Input.GetKeyDown(KeyCode.Alpha1)){
            SceneManager.LoadScene("StartMenu");
        }
        if ( Input.GetKeyDown(KeyCode.Alpha2)){
            SceneManager.LoadScene("CombatTest");
        }
        if ( Input.GetKeyDown(KeyCode.Alpha3)){
            SceneManager.LoadScene("SampleScene");
        }
        if ( Input.GetKeyDown(KeyCode.Alpha4)){
            SceneManager.LoadScene("DeathScene");
        }

    }
}
