using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{

    private WeaponScript _weapon = null;
	// Use this for initialization
	void Awake ()
    {
        _weapon = GetComponent<WeaponScript>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(_weapon != null)
        {

            _weapon.Attack(true);
        }
    }
}
