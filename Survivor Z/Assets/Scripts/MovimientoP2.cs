﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoP2 : MonoBehaviour
{
	public float life = 5;
	public float speed = 2f;
	public Transform target;
	public Transform m_transform;
	public GameObject sombraHabilidadEnemigo;
	GameManager gm;
	Bala bl;

	// Start is called before the first frame update
	void Start()
    {
		gm = FindObjectOfType<GameManager>();
		bl = FindObjectOfType<Bala>();
	}

    // Update is called once per frame
    void Update()
    {
		Movement();
		Habilidades();

		if (life <= 0)
		{
			KillEnemy();
			gm.puntuacion1 += 20;
		}

		

	
	}

	public void Movement()
	{
		if (Input.GetKey(KeyCode.Y))
		{
			m_transform.position = new Vector2(m_transform.position.x, m_transform.position.y + speed * Time.deltaTime);



			transform.right = Vector2.up;
		}


		if (Input.GetKey(KeyCode.H))
		{
			m_transform.position = new Vector2(m_transform.position.x, m_transform.position.y - speed * Time.deltaTime);



			transform.right = Vector2.down;
		}


		if (Input.GetKey(KeyCode.J))
		{
			m_transform.position = new Vector2(m_transform.position.x + speed * Time.deltaTime, m_transform.position.y);


			transform.right = Vector2.right;
		}

		if (Input.GetKey(KeyCode.G))
		{
			m_transform.position = new Vector2(m_transform.position.x - speed * Time.deltaTime, m_transform.position.y);

			transform.right = Vector2.left;
		}

		if (Input.GetKey(KeyCode.Y) && Input.GetKey(KeyCode.J))
		{
			transform.right = Vector2.up + Vector2.right;
		}

		if (Input.GetKey(KeyCode.Y) && Input.GetKey(KeyCode.G))
		{
			transform.right = Vector2.up + Vector2.left;
		}

		if (Input.GetKey(KeyCode.G) && Input.GetKey(KeyCode.H))
		{
			transform.right = Vector2.down + Vector2.left;
		}

		if (Input.GetKey(KeyCode.H) && Input.GetKey(KeyCode.J))
		{
			transform.right = Vector2.down + Vector2.right;
		}
	}


	private void OnTriggerEnter2D(Collider2D collider)
	{

		if (collider.tag == "Bala")
		{
			life = life - collider.GetComponent<Bala>().damageBullet;
			Destroy(collider.gameObject);

		}
		if (collider.tag =="Granada")
        {
			Destroy(collider.gameObject);

		}

	}
	void Habilidades ()
    { float tiempoControlHabilidades =0;
		float tiempoCooldownHabilidades = 15;
		if (Input.GetKeyDown(KeyCode.K) && Time.time > tiempoCooldownHabilidades)
		{
			tiempoCooldownHabilidades = tiempoCooldownHabilidades + tiempoCooldownHabilidades;
			   Vector3 sombra = this.transform.position + Vector3.right + new Vector3(5,0,0);
			Instantiate(sombraHabilidadEnemigo , sombra , this.transform.rotation);
			if (tiempoControlHabilidades < 3)
			{
				tiempoControlHabilidades += Time.deltaTime;
			}
			if (tiempoControlHabilidades >= 3)

            { this.transform.position = sombraHabilidadEnemigo.transform.position;
				Destroy(sombraHabilidadEnemigo.gameObject,1);
			
			}
			

		}
	}
	void KillEnemy()
	{
		Destroy(gameObject);
		
	}
}
