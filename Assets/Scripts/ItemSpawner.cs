using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject checkPointPrefab;
    [SerializeField]
    GameObject[] powerUpPrefab;
    int powerUpDelay = 10;
    void Start()
    {
        StartCoroutine(SpawCheckpointCorutine());
        StartCoroutine(SpawnPowerUPCorutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawCheckpointCorutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(40);
            Vector2 randomPosition = Random.insideUnitCircle * 5;
            Instantiate(checkPointPrefab, randomPosition, Quaternion.identity);
        }
    }

    IEnumerator SpawnPowerUPCorutine()
    {
        while(true){
            yield return new WaitForSeconds(powerUpDelay);
            Vector2 randomPosition = Random.insideUnitCircle * 5;
            int randonItem = Random.Range(0, powerUpPrefab.Length);
            Instantiate(powerUpPrefab[randonItem], randomPosition, Quaternion.identity);
        }
    }
}
