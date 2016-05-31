using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour
{
    public bool isEnemyShot = false;

    public int damage = 1;

	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, 20);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
