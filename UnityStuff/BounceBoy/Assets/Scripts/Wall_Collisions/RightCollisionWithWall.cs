using UnityEngine;
using System.Collections;

public class RightCollisionWithWall : MonoBehaviour
{
    private BoxCollider2D collisionBounds;
    private Movement playerMovement;

    void Start()
    {
        collisionBounds = GetComponent<BoxCollider2D>();
        playerMovement = GetComponentInParent<Movement>();
    }

	void Update()
    {
        collisionBounds.size = new Vector2(playerMovement.xVel, collisionBounds.size.y);
        collisionBounds.offset = new Vector2(8 + playerMovement.xVel / 2f, collisionBounds.offset.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Vector2 colBlockSpriteBounds = other.GetComponent<SpriteRenderer>().sprite.bounds.size;

        if (other.tag == "wall" && playerMovement.xVel > 0)
        {
            playerMovement.xVel *= -1;
            playerMovement.xPos = other.transform.position.x - colBlockSpriteBounds.x / 2f - playerMovement.xSize / 2f;
        }
    }
}
