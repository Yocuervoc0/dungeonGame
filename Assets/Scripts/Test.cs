using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Transform player; 
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().transform;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            //Destroy(gameObject);
            //gameObject.transform.position = gameObject.transform.position + player.position.normalized;

        }


        
    }

}
