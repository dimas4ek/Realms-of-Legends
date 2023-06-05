using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;

    GameObject enemy1;
    GameObject enemy2;

    public static int enemyCount;

    public void SpawnEnemy(GameObject room)
    {
        if (enemy1 != null && enemy2 != null)
        {
            Debug.LogWarning("Player is already spawned.");
            return;
        }

        //List<GameObject> rooms = roomGenerator.generatedRooms;

        Transform roomEnemySpawnPoint1 = room.transform.Find("EnemySpawnPoint");
        Transform roomEnemySpawnPoint2 = room.transform.Find("EnemySpawnPoint2");
        enemy1 = Instantiate(enemyPrefab, roomEnemySpawnPoint1.position, roomEnemySpawnPoint1.rotation);
        enemy2 = Instantiate(enemyPrefab, roomEnemySpawnPoint2.position, roomEnemySpawnPoint2.rotation);

        enemyCount += 2;

        gameObject.SetActive(false);
    }

    public void DespawnPlayer()
    {
        if (enemy1 != null && enemy2 != null)
        {
            Destroy(enemy1);
            //Destroy(enemy2);
            enemy1 = null;
            //enemy2 = null;
        }
    }
}