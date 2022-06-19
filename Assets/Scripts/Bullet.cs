using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float speedBullet = 15;
    int bulletDamage = 1;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speedBullet;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().Damage(bulletDamage);
            print("damege");
            Destroy(gameObject);
        
        

        }
        if (collision.CompareTag("wall") || collision.CompareTag("box"))
        {
            Destroy(gameObject);


        }
            


    }
}
