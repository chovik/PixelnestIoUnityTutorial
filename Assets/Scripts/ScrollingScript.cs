using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ScrollingScript : MonoBehaviour
{

    public Vector2 direction = new Vector2(-1, 0);

    public Vector2 speed = new Vector2(2, 2);

    public bool isLinkedToCamera = false;

    private Rigidbody2D _rigidBody = null;

    private Vector2 _movement;

    public bool isLooping = false;

    private List<Transform> _backgroundParts = null;


    // Use this for initialization
    void Start ()
    {
        _rigidBody = GetComponent<Rigidbody2D>();

        if(isLooping)
        {
            _backgroundParts = new List<Transform>();

            for (int childIndex = 0; childIndex < transform.childCount; childIndex++)
            {
                var child = transform.GetChild(childIndex);
                var renderer = child.GetComponent<Renderer>();

                if(renderer != null)
                {
                    _backgroundParts.Add(child);
                }
            }

            _backgroundParts = _backgroundParts.OrderBy(t => t.position.x).ToList();
        }

    }
	
	// Update is called once per frame
	void Update ()
    {
        _movement = new Vector2(direction.x * speed.x, direction.y * speed.y);

        _movement *= Time.deltaTime;
    }

    void FixedUpdate()
    {
        //_rigidBody.velocity = _movement;

        
        transform.Translate(_movement);

        // Move the camera
        if (isLinkedToCamera)
        {
            Camera.main.transform.Translate(_movement);
        }

        if (isLooping)
        {
            var firstChild = _backgroundParts.FirstOrDefault();

            if (firstChild != null)
            {
                if (firstChild.position.x < Camera.main.transform.position.x)
                {
                    var renderer = firstChild.GetComponent<Renderer>();

                    if (!renderer.IsVisibleFrom(Camera.main))
                    {
                        Transform lastChild = _backgroundParts.LastOrDefault();

                        if (lastChild != null)
                        {
                            var lastChildPosition = lastChild.position;
                            var lastChildRenderer = firstChild.GetComponent<Renderer>();
                            var lastChildSize = lastChildRenderer.bounds.max - lastChildRenderer.bounds.min;

                            firstChild.position = new Vector3(lastChildPosition.x + lastChildSize.x, firstChild.position.y, firstChild.position.z);

                            _backgroundParts.Remove(firstChild);
                            _backgroundParts.Add(firstChild);
                        }
                    }
                }
            }
        }
    }
}
