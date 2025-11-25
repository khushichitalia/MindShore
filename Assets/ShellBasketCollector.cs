using UnityEngine;

public class ShellBasketCollector : MonoBehaviour
{
    [Header("Effects")]
    public AudioClip collectSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shell"))
        {
            // Effects
            if (collectSound)
                audioSource.PlayOneShot(collectSound);

            // Add to counter
            ShellCounter.instance.AddShell();

            // Free the spawn point and spawn a new shell
            ShellSpawnManager.instance.FreeSpawnPoint(other.transform);

            // Delete collected shell
            Destroy(other.gameObject);
        }
    }
}
