using UnityEngine;

public class SandSpawner : MonoBehaviour
{
    public GameObject sandPrefab;
    public Transform spawnPoint;
    public int sandAmount = 10;

    public void SpawnSand()
    {
        for (int i = 0; i < sandAmount; i++)
        {
            Vector3 offset = Random.insideUnitSphere * 0.03f;
            Instantiate(sandPrefab, spawnPoint.position + offset, Quaternion.identity);
        }
    }
}
