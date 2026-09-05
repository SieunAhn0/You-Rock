using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("References")]
    public GameObject[] gameObjects;

    public float minX = -10f;
    public float maxX = 10f;

    public float spawnrate = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("Spawn", spawnrate);
    }

    void Spawn() {
        GameObject randomObject = gameObjects[Random.Range(0, gameObjects.Length)];

        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0f);

        Instantiate(randomObject, spawnPosition, Quaternion.identity);
        Invoke("Spawn", spawnrate);
    }
}
