using UnityEngine;
using System.Collections;

public class PlayerPhysics : MonoBehaviour
{
    // Debug
    public Vector2 myVelocity;

    private float xVelMax = 500f;
    private float yVelMax = 500f;
    private bool onGround = false;
    private Rigidbody2D myBody;
    private BoxCollider2D myCollider;
    private float bounce;

    void Start()
    {
        bounce = gameObject.GetComponent<BoxCollider2D>().sharedMaterial.bounciness;
        myBody = gameObject.GetComponent<Rigidbody2D>();
        myCollider = gameObject.GetComponent<BoxCollider2D>();
	}
	
	void Update()
    {
        // Debug
        myVelocity = myBody.velocity;

        if (Input.GetKey("space"))
        {
            if (onGround)
            {
                myBody.velocity = new Vector2(myBody.velocity.x, 30f);
                myCollider.sharedMaterial.bounciness = 1f;

                myCollider.enabled = false;
                myCollider.enabled = true;
            }

        }
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
        if (!onGround)
        {
            if (Input.GetKey("space"))
            {
                
            }
        }
        // Jumping / Bouncing
        if (Input.GetKey("space"))
        {
            myBody.gravityScale = 0f;
            myCollider.sharedMaterial.bounciness = 1f;

            myCollider.enabled = false;
            myCollider.enabled = true;
            onGround = true;
        }
        else
        {
            myBody.gravityScale = 30f;
            myCollider.sharedMaterial.bounciness = 0f;

            myCollider.enabled = false;
            myCollider.enabled = true;
            onGround = false;

        }
	}
}
    