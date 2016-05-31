﻿using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    public Vector2 speed = new Vector2(10, 10);

    private Vector2 _movement;
    private Rigidbody2D _rigidbody;
    private WeaponScript _weapon;
    // Use this for initialization
    void Start ()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Awake()
    {
        _weapon = GetComponent<WeaponScript>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        _movement = new Vector2(moveHorizontal * speed.x, moveVertical * speed.y);

        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");

        if(shoot)
        {            

            if(_weapon != null)
            {
                _weapon.Attack(false);
            }
        }

    }

    void FixedUpdate()
    {
        _rigidbody.velocity = _movement;
    }
}
