using UnityEngine;
using System.Collections;

public class TopCollisionWithWall : MonoBehaviour
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
        collisionBounds.size = new Vector2(collisionBounds.size.x, playerMovement.yVel);
        collisionBounds.offset = new Vector2(collisionBounds.offset.x, 8 + playerMovement.yVel / 2f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Vector2 colBlockSpriteBounds = other.GetComponent<SpriteRenderer>().sprite.bounds.size;

        if (other.tag == "wall" && playerMovement.yVel > 0)
        {
            playerMovement.yVel *= -1;
            playerMovement.yPos = other.transform.position.y - colBlockSpriteBounds.y / 2f - playerMovement.ySize / 2f;
        }
    }
}
