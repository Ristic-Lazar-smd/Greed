using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExplosionUpgrade : MonoBehaviour
{
    private GameObject[] allEnemies;
    // Start is called before the first frame update
    void Start()
    {
        allEnemies = this.GetComponent<PlayerExp>().gameManager.GetComponent<SpawnEnemy>().enemyPrefabs;
        foreach(GameObject enemy in allEnemies)
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
