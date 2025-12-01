using UnityEngine;

public class ScoopTester : MonoBehaviour
{
    public SandSpawner spawner;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("SPACE PRESSED");

            if (spawner != null)
            {
                spawner.ScoopSand();
            }
            else
            {
                Debug.Log("NO SPAWNER ASSIGNED");
            }
        }
    }
}
