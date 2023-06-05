using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class RoomGenerator : MonoBehaviour
{
    public GameObject roomPrefab;
    public GameObject doorPrefab; 

    public int numberOfRooms; 
    public float roomSize = 10f; 

    public List<GameObject> generatedRooms; 
    private List<GameObject> generatedDoors; 

    public GameObject spawnRoom;

    private void Start()
    {
        generatedRooms = new List<GameObject>();
        generatedDoors = new List<GameObject>();

        GenerateRooms();
    }

    private void GenerateRooms()
    {
        GameObject initialRoom = Instantiate(roomPrefab, transform.position, Quaternion.identity);
        initialRoom.name = "Entrance";
        spawnRoom = initialRoom;

        PlayerSpawn playerSpawn = FindObjectOfType<PlayerSpawn>();
        playerSpawn.SpawnPlayer();

        generatedRooms.Add(initialRoom);

        for (int i = 1; i < numberOfRooms; i++)
        {
            bool roomSpawned = false;
            int attempts = 0;

            while (!roomSpawned && attempts < 100)
            {
                GameObject randomRoom = generatedRooms[Random.Range(0, generatedRooms.Count)];

                Vector3 newPosition = GetRandomAdjacentPosition(randomRoom.transform.position);

                bool overlap = false;
                foreach (GameObject room in generatedRooms)
                {
                    if (Vector3.Distance(newPosition, room.transform.position) < roomSize)
                    {
                        overlap = true;
                        break;
                    }
                }

                if (!overlap)
                {
                    Vector3 direction = (newPosition - randomRoom.transform.position).normalized;

                    Vector3 doorPosition = randomRoom.transform.position + direction * (roomSize / 2f);
                    Quaternion doorRotation = Quaternion.LookRotation(direction);
                    doorPosition += direction * 1f;

                    switch (doorRotation.eulerAngles.y)
                    {
                        case 180:
                            //doorPosition += direction * 4f;
                            doorPosition += new Vector3(0f, 0f, 3.8f);
                            break;
                        case 0:
                            //doorPosition -= direction * 4f;
                            doorPosition -= new Vector3(0f, 0f, 3.9f);
                            break;
                        case 270:
                            doorPosition += new Vector3(3.69f, 0f, 0f);
                            break;
                        case 90:
                            doorPosition -= new Vector3(3.95f, 0f, 0f);
                            break;
                    }
                    doorPosition += new Vector3(0f, 1f, 0f);

                    GameObject newDoor = Instantiate(doorPrefab, doorPosition, doorRotation);
                    newDoor.name = "Door " + i;
                    newDoor.tag = "door";

                    Vector3 roomPosition = newPosition - direction * (roomSize / 2f);
                    GameObject newRoom = Instantiate(roomPrefab, roomPosition, Quaternion.identity);
                    newRoom.name = "Room " + i;
                    newRoom.tag = "room";

                    //generatedDoors.Add(newDoor);
                    generatedRooms.Add(newRoom);

                    EnemySpawn enemySpawn= FindObjectOfType<EnemySpawn>();
                    enemySpawn.SpawnEnemy(newRoom);

                    roomSpawned = true;
                }

                attempts++;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "door")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }

    public static Mesh RemoveTriangles(Mesh mesh, Bounds bounds)
    {
        Vector3[] vertices = mesh.vertices;
        int[] triangles = mesh.triangles;

        List<int> newTriangles = new List<int>();
        for (int i = 0; i < triangles.Length; i += 3)
        {
            Vector3 v1 = vertices[triangles[i]];
            Vector3 v2 = vertices[triangles[i + 1]];
            Vector3 v3 = vertices[triangles[i + 2]];
            if (!bounds.Contains(v1) && !bounds.Contains(v2) && !bounds.Contains(v3))
            {
                newTriangles.Add(triangles[i]);
                newTriangles.Add(triangles[i + 1]);
                newTriangles.Add(triangles[i + 2]);
            }
        }

        Mesh newMesh = new Mesh();
        newMesh.vertices = vertices;
        newMesh.triangles = newTriangles.ToArray();
        newMesh.RecalculateNormals();
        newMesh.RecalculateBounds();

        return newMesh;
    }

    private Vector3 GetRandomAdjacentPosition(Vector3 position)
    {
        Vector3[] directions = { Vector3.left, Vector3.right, Vector3.back, Vector3.forward };

        Vector3 randomDirection = directions[Random.Range(0, directions.Length)];

        Vector3 newPosition = position + randomDirection * roomSize;

        return newPosition;
    }
}
