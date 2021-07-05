using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorSlow : MonoBehaviour
{
    MovimientoP2 z2;
    WeaponController wc;
    public float tiempoSlow = 0;
    float velocidadnormal;
    float velocidadReducida;
    // Start is called before the first frame update
    void Start()
    {
        z2 = FindObjectOfType<MovimientoP2>();
        velocidadnormal = z2.speed;
        wc = FindObjectOfType<WeaponController>();
         velocidadReducida = z2.speed * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Zombie")
        {
            if (tiempoSlow <= 4)
            {
                z2.speed = velocidadReducida;


                tiempoSlow += Time.deltaTime;
            }

           
        }



    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Zombie")
        {

            z2.speed = velocidadnormal;


        }
    }
}
