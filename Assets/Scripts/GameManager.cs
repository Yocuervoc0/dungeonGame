using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    [SerializeField]
    [Range(1, 10)]
    int time = 30;
    public float spawnRate = 1;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    IEnumerator CountDownRoutine()
    {
        while(time > 0)
        {
            yield return new WaitForSeconds(1);
            time--;
            if(time == 0)
            {
                time = 30;
                spawnRate += 0.5f;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDownRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
