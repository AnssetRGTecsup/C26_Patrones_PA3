using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class playerBarrera : MonoBehaviour
{
    public ManagerScene pause;
    public MovimientoPlayer modificarPowers;
    public int precio;
    public int monedasRequeridas;
    public int monedas;

    public TextMeshProUGUI txtMonedas;
    public GameObject[] enemys=new GameObject[3];

    //sonidos
    public AudioSource audioSource;
    public AudioClip  monedaSound;
    public AudioClip perro;
    public AudioClip gato;
    public AudioClip rata;
    public AudioClip salto;
    public AudioClip dash;

    //win or lose
    public GameObject win;
    public GameObject lose;

    // Start is called before the first frame update
    void Start()
    {
        
        monedas = 0;
        //txtMonedas.text = "Monedas: "+monedas;
        txtMonedas.text =  monedas.ToString() ;
    }

    // Update is called once per frame
    void Update()
    {
        txtMonedas.text = monedas.ToString();
        if (Input.GetKeyDown("p"))
        {
            if (monedas >= precio)
            {
                PoderDash();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "enemyKiller")
        {
            SceneManager.LoadScene("jamBCP");
        }
        if (collision.gameObject.tag == "coin")
        {
            audioSource.clip = monedaSound;
            audioSource.Play();
            Destroy(collision.gameObject);
            sumarMoneda();
            generarEnemy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Finish")
        {
            
            winComporobar();
            pause.CambiarEstadodeJuego1();
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "rata")
        {
            
            restarMoneda();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "perro")
        {
            

            inversion();
            Destroy(collision.gameObject);
        }
    }

    void winComporobar()
    {
        if (monedas >= monedasRequeridas)
        {
            win.SetActive(true);
            
        }
        else
        {
            lose.SetActive(true);
            
        }
    }
    void sumarMoneda()
    {
        monedas++;
        txtMonedas.text = monedas.ToString();
    }
    void restarMoneda()
    {
        if (monedas != 0)
        {
            monedas = monedas - 1;
            txtMonedas.text = monedas.ToString();
        }

    }
    void inversion()
    {
        if (monedas <= 0)
        {
            
        }
        if (monedas % 2 == 0)
        {
            int n = Random.Range(0, 100);
            if (n < 30)
            {
                monedas = monedas + (monedas / 2);
            }
            else if (n >= 30)
            {
                monedas = monedas - (monedas / 2);
            }
            txtMonedas.text = monedas.ToString();
            print(n);
        }
        if (monedas % 2 != 0)
        {
            int n = Random.Range(0, 100);
            if (n < 30)
            {
                monedas = monedas + ((monedas + 1)/ 2);
            }
            else if (n >= 30)
            {
                monedas = monedas - ((monedas + 1)/ 2);
            }
            txtMonedas.text = monedas.ToString();
            print(n);
        }
    }
    void generarEnemy(GameObject coin)
    {
        
        int n = Random.Range(0, 3);
        if (n == 1)
        {
            Vector2 posicion1 = new Vector2(coin.transform.position.x - 10, coin.transform.position.y + 10);
            Instantiate(enemys[n], posicion1, enemys[n].transform.rotation);
        }
        else
        {
            Vector2 posicion = new Vector2(coin.transform.position.x + 20, coin.transform.position.y + 10);
            Instantiate(enemys[n], posicion, enemys[n].transform.rotation);
        }
    }

        
    void PoderDash()
    {
        audioSource.clip = dash;
        audioSource.Play();
        monedas=monedas-precio;
        transform.position = new Vector2(transform.position.x + 10, transform.position.y);
        txtMonedas.text = monedas.ToString();
    }
}
