using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    const int BASIC_DAMAGE  = 20;
    [SerializeField]
    int health = 1;
    [SerializeField]
    float speedEnemy = 2;

    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        //GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        //int randomSpawnPoint = Random.Range(0, spawnPoints.Length);
        //this.transform.position = spawnPoints[randomSpawnPoint].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direccion = player.position - this.transform.position;
        this.transform.position += (Vector3)direccion.normalized * Time.deltaTime * speedEnemy;
    }

    public void Damage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().GetDamage(BASIC_DAMAGE);
        }
    }
}
