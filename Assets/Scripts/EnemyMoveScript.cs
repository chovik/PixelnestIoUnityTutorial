using UnityEngine;
using System.Collections;
using System;

public class EnemyMoveScript : MonoBehaviour
{

    // Use this for initialization
    public Vector2 speed = new Vector2(10, 10);

    public Vector2 direction = new Vector2(-1, 0);

    private Vector2 _movement;

    private Rigidbody2D _rigidBody = null;

    private Vector3 _startPosition;

    // Use this for initialization
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _movement = new Vector2(direction.x * speed.x, direction.y * speed.y);
        var currentPosition = transform.position;

        if(Math.Abs(currentPosition.x - _startPosition.x) >= 3.0)
        {
            _startPosition = currentPosition;
            direction.x = -direction.x;
        }
    }

    void FixedUpdate()
    {
        _rigidBody.velocity = _movement;
    }
}
