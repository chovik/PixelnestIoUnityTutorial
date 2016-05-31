using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;

    public Vector2 speed = new Vector2(10, 10);

    private Vector2 movement;
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        movement = new Vector2(moveHorizontal * speed.x, moveVertical * speed.y);

    }

    void FixedUpdate()
    {       
        rb.velocity = movement;
    }
}
