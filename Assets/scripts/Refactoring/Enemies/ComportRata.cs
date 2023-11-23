using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportRata : MonoBehaviour
{
    public float speed;
    public int direccion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x-speed*Time.deltaTime,transform.position.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "perro")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
