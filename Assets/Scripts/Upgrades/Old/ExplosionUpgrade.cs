using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExplosionUpgrade : MonoBehaviour
{
    private GameObject[] allEnemyPrefabs;
    private ListOfEnemies listOfEnemies;
    // Start is called before the first frame update
    void Start()
    {
        listOfEnemies = GameManager.instance.GetComponent<ListOfEnemies>();
        allEnemyPrefabs = this.GetComponent<PlayerExp>().gameManager.GetComponent<SpawnEnemy>().enemyPrefabs;
        foreach(GameObject enemy in allEnemyPrefabs)
        {
            enemy.GetComponent<EnemyDmgTaken>().canExplode = true;
        }
        foreach(GameObject enemy in listOfEnemies.enemies)
        {
            enemy.GetComponent<EnemyDmgTaken>().canExplode = true;
        }
    }

    // Update is called once per frame
    public void AddUpgrade()
    {
        this.AddComponent<ExplosionUpgrade>();
    }
}
