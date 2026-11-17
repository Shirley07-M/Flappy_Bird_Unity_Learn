using Unity.VisualScripting;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float spawnTimer = 3f;
    private float spawnRange;
    private float currentTime = 0f;

    private void Start()
    {
        SpawnPipe();
    }
    private void SpawnPipe()
    {
        spawnRange = Random.Range(-0.29f, 0.85f);
        Vector3 spawnPos = new Vector3(transform.position.x, spawnRange, transform.position.z);
        GameObject currentPipe = Instantiate(pipePrefab, spawnPos, Quaternion.identity);
        Destroy(currentPipe, 10f);
    }

    private void Update()
    {
        if (currentTime >= spawnTimer)
        {
            SpawnPipe();
            currentTime = 0f;
        }
        else currentTime += Time.deltaTime;
    }
}
