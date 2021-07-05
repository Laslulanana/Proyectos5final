using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
	public float sizeClip;//balas por cargador
	public float maxBullets;
	public float axctualAmmo;
	public float fireRate;
	public float timeReload;
	public float damage;
	public float speedBullet;
	public float lifeBullet;
	public GameObject prefBullet;

	public Sprite sprTopWeapon;
	public string nameWeapon;
	public bool ownedWeapon;
	WeaponController wc;

	// Start is called before the first frame update
	void Start()
	{
		wc = FindObjectOfType<WeaponController>();
		ownedWeapon = false;
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		
		


			if (collider.tag == "Jugador")
			{

				if (wc.weaponsPlayer.Count > 0)
				{
					ownedWeapon = true;
					foreach (Weapon weapons in wc.weaponsPlayer)
					{

						if (nameWeapon == weapons.nameWeapon)
						{
							//recargar
							ownedWeapon = true;
							Destroy(this.gameObject);


						}
					}
					
				}
			ownedWeapon = true;
			wc.weaponsPlayer.Add(this);
			wc.currentWeapon = this;
			transform.parent = wc.transform;
			DestroyOnlevel();
			GetComponent<SpriteRenderer>().sprite = sprTopWeapon;
			transform.position = GameObject.Find("WeaponPosition").transform.position;
			transform.rotation = GameObject.Find("WeaponPosition").transform.rotation;
		}
			



		
	}

	void DestroyOnlevel()
	{
		//Destroy(GetComponent<SpriteRenderer>());
		Destroy(GetComponent<BoxCollider2D>());
	}
}
