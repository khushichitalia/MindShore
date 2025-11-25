using System.Collections.Generic;
using UnityEngine;

public class ShellSpawnManager : MonoBehaviour
{
    public static ShellSpawnManager instance;

    [Header("Settings")]
    public int shellCount = 10;
    public GameObject shellPrefab;

    [Header("Spawn Points")]
    public Transform[] spawnPoints;

    private List<int> usedPoints = new List<int>();

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SpawnInitialShells();
    }

    private void SpawnInitialShells()
    {
        usedPoints.Clear();
        for (int i = 0; i < shellCount; i++)
        {
            SpawnShell();
        }
    }

    public void SpawnShell()
    {
        if (usedPoints.Count >= spawnPoints.Length)
            return;

        int index;
        do
        {
            index = Random.Range(0, spawnPoints.Length);
        }
        while (usedPoints.Contains(index));

        usedPoints.Add(index);

        Transform spawn = spawnPoints[index];

        Instantiate(shellPrefab, spawn.position, spawn.rotation, spawn);
    }

    public void FreeSpawnPoint(Transform shellTransform)
    {
        Transform spawnParent = shellTransform.parent;
        int index = System.Array.IndexOf(spawnPoints, spawnParent);

        if (index >= 0)
            usedPoints.Remove(index);

        SpawnShell();
    }
}
