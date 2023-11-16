using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RataGato : Enemy
{
    public ManagerCoins managerCoins;
    public int amount;
    public float speed;

    void Update()
    {
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "rata")
        {

            managerCoins.PayCoins(amount);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "perro")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }

    }
 
}
