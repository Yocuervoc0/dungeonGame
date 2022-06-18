using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject checkPointPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawCheckpointCorutine());
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
}
