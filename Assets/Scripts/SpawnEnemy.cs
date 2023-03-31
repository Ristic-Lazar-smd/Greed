using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float[] spawnInterval;
    public bool stopEnumRotation;
    private GameObject player;
    [SerializeField]private PlayerExp playerLvl;
    private Vector3 spawnPosition;

    [SerializeField] private float noSpawnZoneAroundPlayer;
    private float randomXposition, randomYposition;
    private int whatToSpawn;

    void Awake(){
        player = GetComponent<GameManager>().player;
        playerLvl = player.GetComponent<PlayerExp>();
    }
    void Start(){
        
    }
    public void SpawnRandom()
    {
        StartNewEnumRotation();
    }
     public void StartNewEnumRotation(){
        StopAllCoroutines();
        for(int i = 0; i<enemyPrefabs.Length; i++){
            //StopCoroutine(spawnEnemy(spawnInterval[i],enemyPrefabs[i]));
            StartCoroutine(spawnEnemy(spawnInterval[i],enemyPrefabs[i]));
        }
    }
    private IEnumerator spawnEnemy(float interval, GameObject enemyPrefabs){
        yield return new WaitForSeconds(interval);
        GenerateRandomPos();
        Reference enemy = (Instantiate(enemyPrefabs, spawnPosition, Quaternion.identity)).GetComponent<Reference>();
        enemy.player = player; //Passing GameObject "Player" to newly instanced Prefab  
        StartCoroutine(spawnEnemy(interval,enemyPrefabs));
    }

    private void GenerateRandomPos(){
        do{
            randomXposition = Random.Range(-8f, 8.20f);
            randomYposition = Random.Range(-4.40f, 4.10f);
            spawnPosition = new Vector3(randomXposition, randomYposition, 0f);
        }while (Vector3.Distance(spawnPosition, player.transform.position) < noSpawnZoneAroundPlayer );
    }



    private void Update()
    {
        switch(playerLvl.lvl)
        {
            case 1:
                {
                    spawnInterval[0] = 0.7f;
                    spawnInterval[1] = 10f;
                    spawnInterval[2] = 8f;
                }
                break;
            case 2:
                {
                    spawnInterval[0] = 0.5f;
                    spawnInterval[1] = 8f;
                    spawnInterval[2] = 6f;
                }
                break;
            case 3:
                {
                    spawnInterval[0] = 0.3f;
                    spawnInterval[1] = 6f;
                    spawnInterval[2] = 4f;
                }
                break;
            case 4:
                {
                    spawnInterval[0] = 0.2f;
                    spawnInterval[1] = 4f;
                    spawnInterval[2] = 2f;
                }
                break;
            case 5:
                {
                    spawnInterval[1] = 3f;
                }
                break;
        }
    }



    private void SpawnExactEnemy(int enemyToSpawn){
        Reference enemy = (Instantiate(enemyPrefabs[enemyToSpawn], spawnPosition, Quaternion.identity)).GetComponent<Reference>();
        enemy.player = player; //Passing GameObject "Player" to newly instanced Prefab
    }
}