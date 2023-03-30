using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("CombatTest");
    }
}
