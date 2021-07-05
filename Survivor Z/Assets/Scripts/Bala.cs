using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
	public float damageBullet;
	WeaponController wc;
	// Start is called before the first frame update
	void Start()
	{
		wc = FindObjectOfType<WeaponController>();
		damageBullet = wc.currentWeapon.damage;
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		
		
	}
}
