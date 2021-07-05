using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public Text PP2;
	public Text PP1;
	public int puntuacion1;
	public int puntuacion2;
	// Start is called before the first frame update
	void Start()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
		PP1.text = "Policia  " + puntuacion1;
		PP2.text = "Zombie  " + puntuacion2;
	}
}
