using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
	public List<Weapon> weaponsPlayer = new List<Weapon>();
	public Weapon currentWeapon;
	public Transform cañon;
	public Image i1, i2, i3, i4;

	public GameObject bullet;
	Weapon wp;


	float nextFire;
	// Start is called before the first frame update
	void Start()
	{
		wp = FindObjectOfType<Weapon>();

		nextFire = 0;

	}




	// Update is called once per frame
	void Update()
	{
		if (weaponsPlayer.Count != 0)
        {
			wp.ownedWeapon = true;
        }
		if (wp.ownedWeapon == true)
		{
			Debug.Log("Accion");
			WeaponAttack();
			SelectWeapon();
		}
        else
        {
			Debug.Log("Edurne");
        }
		

	}

	void WeaponAttack()
	{
		if (Input.GetMouseButton(0) && Time.time > nextFire)
		{
			nextFire = Time.time + currentWeapon.fireRate;
			GameObject newBullet = Instantiate(currentWeapon.prefBullet, cañon.transform.position, currentWeapon.transform.rotation);
			newBullet.GetComponent<Rigidbody2D>().AddForce(transform.right * currentWeapon.speedBullet, ForceMode2D.Impulse);
			Destroy(newBullet, currentWeapon.lifeBullet);



		}

	}

	void SelectWeapon()
	{

		if (Input.GetKeyDown(KeyCode.Alpha1) && weaponsPlayer.Count > 0)
		{
			
			i1.sprite = weaponsPlayer[0].sprTopWeapon;
			i1.enabled = true;
			currentWeapon = weaponsPlayer[0];
			
			weaponsPlayer[0].gameObject.SetActive(true);
			weaponsPlayer[1].gameObject.SetActive(false);
			weaponsPlayer[2].gameObject.SetActive(false);
			weaponsPlayer[3].gameObject.SetActive(false);
			weaponsPlayer[4].gameObject.SetActive(false);

		}
		if (Input.GetKeyDown(KeyCode.Alpha2) && weaponsPlayer.Count > 1)
		{
			
			i2.sprite = weaponsPlayer[1].sprTopWeapon;
			i2.enabled = true;
			currentWeapon = weaponsPlayer[1];

			weaponsPlayer[0].gameObject.SetActive(false);
			weaponsPlayer[1].gameObject.SetActive(true);
			weaponsPlayer[2].gameObject.SetActive(false);
			weaponsPlayer[3].gameObject.SetActive(false);
			weaponsPlayer[4].gameObject.SetActive(false);

		}

	}
	
}
