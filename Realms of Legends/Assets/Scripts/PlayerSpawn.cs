using Unity.VisualScripting;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject playerPrefab; 

    private GameObject currentPlayer; 

    private RoomGenerator roomGenerator;
        
    /*private void Start()
    {
        roomGenerator = FindObjectOfType<RoomGenerator>();
        SpawnPlayer();
    }*/

    public void SpawnPlayer()
    {
        if (currentPlayer != null)
        {
            Debug.LogWarning("Player is already spawned.");
            return;
        }

        roomGenerator = FindObjectOfType<RoomGenerator>();

        GameObject spawnRoom = roomGenerator.spawnRoom;


        if (spawnRoom != null)
        {
            Transform roomSpawnPoint = spawnRoom.transform.Find("SpawnPoint");

            if (roomSpawnPoint != null)
            {
                currentPlayer = Instantiate(playerPrefab, roomSpawnPoint.position, roomSpawnPoint.rotation);
            }
            else
            {
                Debug.LogWarning("SpawnPoint not found in the spawn room.");
            }
        }
        else
        {
            Debug.LogWarning("Spawn room not found.");
        }

        if (currentPlayer == null || spawnRoom == null)
        {
            Debug.Log("An error occurred while spawning the player");
        }

        gameObject.SetActive(false);
    }

    public void DespawnPlayer()
    {
        if (currentPlayer != null)
        {
            Destroy(currentPlayer);
            currentPlayer = null;
        }
    }
}