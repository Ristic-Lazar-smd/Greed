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
    private Vector3 spawnPosition;

    [SerializeField] private float noSpawnZoneAroundPlayer;
    private float randomXposition, randomYposition;
    private int whatToSpawn;

    void Awake(){
        player = GetComponent<GameManager>().player;
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







    private void SpawnExactEnemy(int enemyToSpawn){
        Reference enemy = (Instantiate(enemyPrefabs[enemyToSpawn], spawnPosition, Quaternion.identity)).GetComponent<Reference>();
        enemy.player = player; //Passing GameObject "Player" to newly instanced Prefab
    }
}