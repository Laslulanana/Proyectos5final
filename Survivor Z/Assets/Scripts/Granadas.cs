using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granadas : MonoBehaviour
{
    // Start is called before the first frame update
    public float damageBullet;
    float velocidadnormal;
    public GameObject particulasVeneno;
    MovimientoP2 z2;
    WeaponController wc;
    public float tiempoSlow = 0;
    void Start()
    {
        z2 = FindObjectOfType<MovimientoP2>();
        velocidadnormal = z2.speed;
        wc = FindObjectOfType<WeaponController>();
        //damageBullet = wc.currentWeapon.damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   /* private void OnTriggerStay2D(Collider2D collider)
    {if (collider.tag == "Zombie")
        {if (tiempoSlow <= 5)
            {
                float reduccion = z2.speed *0.5f;
            z2.speed = reduccion;
                tiempoSlow++ ;
            }
            tiempoSlow = 0;
        }
    
    
        
    }
   
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Zombie")
        {

            z2.speed = velocidadnormal;


        }
    }
   */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Zombie" || other.tag == "Pared")
        {
            var particulasClon = Instantiate(particulasVeneno, this.transform.position, this.transform.rotation);
            Destroy(particulasClon, 4f);
            Destroy(this.gameObject,4f);
            
            
        }
    }
}
