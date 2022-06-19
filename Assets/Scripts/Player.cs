using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    const int MAX_HEALTH = 100;
    const int INITEIAL_HEALTH = 70;

    [SerializeField]
    int healthPlayer = INITEIAL_HEALTH;
    [SerializeField]
    bool isAlive = true;

    float horizontalDirection;
    float verticalDirection;
    Vector3 moveDirtection;
    [SerializeField]
    float speed = 3f;
    [SerializeField]
    Transform aim;
    [SerializeField]
    Camera mainCamera;
    Vector2 facingDirection;

    [SerializeField]
    Transform Bullet;
    bool gunLoaded = true;

    float fireRate = 2;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        horizontalDirection = Input.GetAxis("Horizontal");
        verticalDirection = Input.GetAxis("Vertical");
        moveDirtection.x = horizontalDirection;
        moveDirtection.y = verticalDirection;
        transform.position += moveDirtection * Time.deltaTime * speed;

        //aim
        facingDirection = mainCamera.ScreenToWorldPoint(Input.mousePosition) 
            - this.transform.position;
        aim.position = transform.position + (Vector3)facingDirection.normalized;

        if (Input.GetMouseButton(0) && gunLoaded)
        {
            gunLoaded = false;
            float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;

            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Instantiate(Bullet, transform.position, targetRotation);
            StartCoroutine(ReloadGun());
        }
    }

    IEnumerator ReloadGun()
    {
        yield return new WaitForSeconds(1/ fireRate);
        gunLoaded = true;
    }

    public void GetDamage(int damage)
    {
        this.healthPlayer -= damage;
        if(this.healthPlayer <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        isAlive = false;
    }

}
