using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public static GameManager instance;

    public bool gameIsPaused = false;
    [HideInInspector]public bool canBeUnPaused = true;
    public int targetFrameRate = 60;
    public float spawntime;
    public float countdown = 3;

    private void Awake()
    {
        SpawnEnemy();
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
    }

    void Update()
    {   
        //Enemy spawn on timer START//
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            
            if (spawntime > 0.5) { 
                spawntime = (float)(spawntime * 0.9); 
            }
            countdown = spawntime;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1)){
            gameObject.GetComponent<SpawnEnemy>().spawnInterval[0]=10;
            gameObject.GetComponent<SpawnEnemy>().spawnInterval[1]=1;
            gameObject.GetComponent<SpawnEnemy>().spawnInterval[2]=1;
            gameObject.GetComponent<SpawnEnemy>().StartNewEnumRotation();
        }
        //Enemy spawn on timer END//

        //Play/Pause manager START//
        if(Input.GetKeyDown(KeyCode.Escape) && gameIsPaused && canBeUnPaused){
            ResumeGame();  
        } 
        else if (Input.GetKeyDown(KeyCode.Escape) && !gameIsPaused){
            PauseGame();
        }
        //Play/Pause manager END//
    }

    public void SpawnEnemy()
    {
        gameObject.GetComponent<SpawnEnemy>().SpawnRandom();
    }

    public void PauseGame ()
    {
        Time.timeScale = 0;
        gameIsPaused = true;
        player.GetComponent<ManualShoot>().canShoot=false;
    }
    public void ResumeGame ()
    {
        Time.timeScale = 1;
        gameIsPaused = false;
        player.GetComponent<ManualShoot>().canShoot=true;
    }
}
