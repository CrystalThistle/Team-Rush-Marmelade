using UnityEngine;
using System.Collections;

public class PlayerPhysics : MonoBehaviour
{
    // Debug
    public Vector2 myVelocity;

    private float xVelMax = 500f;
    private float yVelMax = 500f;
    private bool onGround;
    private Rigidbody2D myBody;
    private float bounce;

    void Start()
    {
        bounce = gameObject.GetComponent<BoxCollider2D>().sharedMaterial.bounciness;
        myBody = gameObject.GetComponent<Rigidbody2D>();
	}
	
	void Update()
    {
        // Debug
        myVelocity = myBody.velocity;

        // Moving left
        if (Input.GetKey("left"))
        {
            if (onGround)
            {

            }
            else
            {
                myBody.velocity += new Vector2(-30f, 0);
            }
        }

        // Moving right
        if (Input.GetKey("right"))
        {
            if (onGround)
            {

            }
            else
            {
                myBody.velocity += new Vector2(30f, 0);
            }
        }

        // Clamp velocity
        myBody.velocity = new Vector2(Mathf.Clamp(myBody.velocity.x, -xVelMax, xVelMax), Mathf.Clamp(myBody.velocity.y, -yVelMax, yVelMax));

        // Jumping / Bouncing
        if (Input.GetKey("space"))
        {
            myBody.gravityScale = 0f;
        }
        else
        {
            myBody.gravityScale = 30f;
            bounce = 0f;
        }
	}
}
    