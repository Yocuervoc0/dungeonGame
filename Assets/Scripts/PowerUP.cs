using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUP : MonoBehaviour
{
    public PowerUpType powerUpType;
    int autoDestuctionTime = 7;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(AutoDestructionItemCorutine());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /// maybe let this on Player class
        //if (collision.CompareTag("Player")) 
        //{

        //    Destroy(gameObject);
        //}
    }

    IEnumerator AutoDestructionItemCorutine()
    {
        yield return new WaitForSeconds(autoDestuctionTime);
        Destroy(gameObject);
    }

}
public enum PowerUpType //this should be children class? 
{
    fireRateIncrese,
    powerShot,
    healthtUp,
    KaBoom,
    invulnerability
}