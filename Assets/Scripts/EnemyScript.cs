using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{

    private WeaponScript[] _weapons = null;
	// Use this for initialization
	void Awake ()
    {
        _weapons = GetComponentsInChildren<WeaponScript>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(_weapons != null)
        {
            foreach(var weapon in _weapons)
            {
                weapon.Attack(true);
            }            
        }
    }
}
