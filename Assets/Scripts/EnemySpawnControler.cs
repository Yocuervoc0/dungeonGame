using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnControler : MonoBehaviour
{
    [SerializeField]
    List<GameObject> enemyPrefrab = new List<GameObject>();
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
        player = FindObjectOfType<Player>().transform;
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(3/GameManager.instance.spawnRate);
            int position = Random.Range(0, enemyPrefrab.Count);
            //Vector2 randomPositionSpwanEnemy = (Vector2)player.position + Random.insideUnitCircle * 5;
            Vector2 randomDirection = ((Vector2)player.position + Random.insideUnitCircle).normalized;
            int  randomDistance = Random.Range(2, 10);
            Vector2 spawnPoint = (Vector2)player.position + randomDirection * randomDistance;
            Instantiate(enemyPrefrab[position], spawnPoint, Quaternion.identity);
        }
    }
}
