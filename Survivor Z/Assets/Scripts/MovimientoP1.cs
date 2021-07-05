using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoP1 : MonoBehaviour
{

	public float vida;
	public float speed = 50;
	bool isMoving = false;
	Vector3 mousePos;
	Camera cam;
	GameManager gm;
	// Start is called before the first frame update
	void Start()
    {
		cam = Camera.main;
		gm = FindObjectOfType<GameManager>();
	}

    // Update is called once per frame
    void Update()
    {
		RotateToCursor();
		Movement();
	}

	void Movement()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime,
			Input.GetAxisRaw("Vertical") * speed * Time.deltaTime);


		if (GetComponent<Rigidbody2D>().velocity.magnitude != 0)
		{
			isMoving = true;
		}
		else
		{
			isMoving = false;
		}
	}

	void RotateToCursor()
	{

		mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - cam.transform.position.z));

		Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

		transform.right = direction;
	}

	public void DañoJugador(float daño)
	{
		vida = vida - daño;
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{

		if (collider.tag == "Zombie")
		{
			Destroy(gameObject);
			gm.puntuacion2 += 20;
		}

		

	}
}
