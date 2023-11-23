using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Perro : Enemy
{

   public  ManagerCoins managerCoins;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "perro")
        {


            managerCoins.Invest();
            Destroy(collision.gameObject);
        }
    }
}
