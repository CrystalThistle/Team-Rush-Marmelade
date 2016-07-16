using UnityEngine;
using System.Collections;

public class script : MonoBehaviour {

    private Rigidbody2D rb;
    
	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("left"))
        {
            rb.velocity = new Vector2(-75, rb.velocity.y);
        }

        if (Input.GetKey("right"))
        {
            rb.velocity = new Vector2(75,rb.velocity.y);
        }
        if (Input.GetKey("space"))
        {
            rb.gravityScale = 0.0f;
        }
        else
        {
            rb.gravityScale = 10;
        }
	}
}
    