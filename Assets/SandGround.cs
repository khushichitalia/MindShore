using UnityEngine;

public class SandGround : MonoBehaviour
{
    public int requiredSand = 50;   // how much sand needed to build a castle
    public GameObject castlePrefab; // your sandcastle model

    private int count = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sand"))
        {
            count++;
            Destroy(other.gameObject);

            if (count >= requiredSand)
            {
                Instantiate(castlePrefab, transform.position, transform.rotation);
            }
        }
    }
}
