using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRate = 1f;
    public float maxSpawn;
    
    [SerializeField] private GameObject[] enemeyPrefabs;
    [SerializeField] private bool canSpawn = true;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(Spawner());
    }
    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        while (canSpawn)
        {
            yield return wait;
            int random = Random.Range(0, enemeyPrefabs.Length);
            GameObject enemeyToSpawn = enemeyPrefabs[random];
            Instantiate(enemeyToSpawn, transform.position, Quaternion.identity);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
