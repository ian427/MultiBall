using UnityEngine;

public class Spawnballs : MonoBehaviour
{
    [SerializeField] private GameObject Ball;
    [SerializeField] private float spawnCountdown = 0;
    [SerializeField] private int MaxSpawn, CurrentSpawned = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnBall();

    }
    private void SpawnBall ()
    {
        if(CurrentSpawned < MaxSpawn)
        {
            StartCoroutine(SpawnCounter());
        }
    }

    System.Collections.IEnumerator SpawnCounter ()
    {
        Instantiate(Ball, transform.position, transform.rotation);
        CurrentSpawned++;
        yield return new WaitForSeconds(spawnCountdown);
        SpawnBall();
    }
}
