using UnityEngine;

public class SandSpawner : MonoBehaviour
{
    public GameObject sandPrefab;   // The SandChunk prefab
    public Transform spawnPoint;    // Where sand appears in the bucket
    public int sandAmount = 10;     // How much sand to spawn

    public void ScoopSand()
    {
        Debug.Log("SCOOPING!");

        for (int i = 0; i < sandAmount; i++)
        {
            Vector3 rand = Random.insideUnitSphere * 0.05f;
            Instantiate(sandPrefab, spawnPoint.position + rand, Quaternion.identity);
        }
    }
}
