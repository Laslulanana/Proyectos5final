using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc1 : MonoBehaviour
{
	public float life = 2;
	public Transform punto1;
	public Transform punto2;
	public float speed ;
	
	private bool llegada = false;
	private bool perseguir;
	private bool ataque;
	public bool humano = true;
	public bool zombie = false;
	public float dist;
	public GameObject player;
	GameManager gm;
	Bala bl;
	Granadas gn;


	// Start is called before the first frame update
	void Start()
	{
		bl = FindObjectOfType<Bala>();
		gm = FindObjectOfType<GameManager>();
		gn= FindObjectOfType<Granadas>();
	
	}

	// Update is called once per frame
	void Update()
	{
		dist = Vector3.Distance(player.transform.position, transform.position);
		Movement();

		if (life <= 0)
		{
			KillEnemy();
		}


		




	}

	private void OnTriggerEnter2D(Collider2D collider)
	{

		
		if (humano == true)
		{
			if (collider.tag == "Bala")
			{
				life = life - 1 ;
				gm.puntuacion1 -= 5;
			}
			if (collider.tag == "Granada")
			{
				
				gm.puntuacion1 -= 5;
			}

			if (collider.tag == "Zombie")
			{
				zombie = true;
				humano = false;
				gm.puntuacion2 += 10;
			}

			if (collider.tag == "Jugador")
			{
				Destroy(gameObject);
				gm.puntuacion1 += 10;
			}
		}

		if (zombie == true)
		{
			
			if (collider.tag == "Jugador")
			{
				Destroy(player);
				gm.puntuacion2 += 20;
			}

			if (collider.tag == "Bala")
			{
				life = life - 1;
				gm.puntuacion1 += 4;
			}
			if (collider.tag == "Granada")
			{
				
				gm.puntuacion1 += 4;
			}


		}

	}

	

	void KillEnemy()
	{
		Destroy(gameObject);
		
	}

	public void Movement()
	{


		


		if (zombie == true)
		{
			transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed *Time.deltaTime);

			Vector3 dir = player.transform.position - transform.position; Quaternion rotation = Quaternion.LookRotation(new Vector3(0, 0, dir.z)); transform.rotation = rotation;
		}

		if(humano == true)
		{
			

			if (perseguir && !ataque)
			{
				transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

				Vector3 dir = player.transform.position - transform.position; Quaternion rotation = Quaternion.LookRotation(new Vector3(0, 0, dir.z)); transform.rotation = rotation;

			}

			else if (!perseguir)
			{
				if (!llegada)
				{
					transform.position = Vector3.MoveTowards(transform.position, punto1.position, speed * Time.deltaTime);

					Vector3 dir = punto1.position - transform.position;
					float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
					transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
					if (transform.position == punto1.position)
					{
						llegada = true;
					}

				}
				else
				{
					transform.position = Vector3.MoveTowards(transform.position, punto2.position, speed * Time.deltaTime);
					if (transform.position == punto2.position)
					{
						llegada = false;
					}
				}
			}

			
		}

		
		
	}
}
