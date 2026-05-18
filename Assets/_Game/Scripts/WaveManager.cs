using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject[] wavePrefabs;

    public Transform spawnPoint;

    public float spawnInterval = 3f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnWave), 1f, spawnInterval);
    }

    void SpawnWave()
    {
        int randomIndex = Random.Range(0, wavePrefabs.Length);

        Instantiate(
            wavePrefabs[randomIndex],
            spawnPoint.position,
            Quaternion.identity
        );
    }
}