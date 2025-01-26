using UnityEngine;

public class EnemyExplosionUpgrade : UpgradeBase
{
    private GameObject[] allEnemyPrefabs;
    private ListOfEnemies listOfEnemies;

    public override void AddUpgrade()
    {
        listOfEnemies = GameManager.instance.GetComponent<ListOfEnemies>();
        allEnemyPrefabs = PlayerMovement.playerInstance.GetComponent<PlayerExp>().gameManager.GetComponent<SpawnEnemy>().enemyPrefabs;
        foreach (GameObject enemy in allEnemyPrefabs)
        {
            enemy.GetComponent<EnemyDmgTaken>().canExplode = true;
        }
        foreach (GameObject enemy in listOfEnemies.enemies)
        {
            enemy.GetComponent<EnemyDmgTaken>().canExplode = true;
        }
    }
}

