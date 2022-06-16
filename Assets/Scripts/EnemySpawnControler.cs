using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnControler : MonoBehaviour
{
    [SerializeField]
    List<GameObject> enemyPrefrab = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(3/GameManager.instance.spawnRate);
            int position = Random.Range(0, enemyPrefrab.Count);
            Instantiate(enemyPrefrab[position]);
        }
    }
}
