using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour
{
    public Vector2 speed = new Vector2(10, 10);

    public Vector2 direction = new Vector2(-1, 0);

    private Vector2 _movement;

    private Rigidbody2D _rigidBody = null;

	// Use this for initialization
	void Start ()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        _movement = new Vector2(direction.x * speed.x, direction.y * speed.y);
	}

    void FixedUpdate()
    {
        _rigidBody.velocity = _movement;
    }
}
