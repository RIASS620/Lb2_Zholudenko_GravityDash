using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnRate = 2f;
    public float heightOffset = 2.5f;
    private float timer = 0;

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnObstacle();
            timer = 0;
        }
    }

    void SpawnObstacle()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Vector3 spawnPos = new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0);

        Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
    }
}