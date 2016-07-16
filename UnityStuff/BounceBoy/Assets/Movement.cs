using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float xPos;
    public float yPos;
    public float xVel;
    public float yVel;
    public float xVelMax = 7f;
    public float yVelMax = 7f;
    public float gravity;

    private float prevXPos;
    private float prevYPos;
    private float xSize;
    private float ySize;
    private float screenWidth;
    private float screenHeight;

    private PixelPerfectCamera gameCamera;

    void Start()
    {
        gameCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PixelPerfectCamera>();

        xSize = GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        ySize = GetComponent<SpriteRenderer>().sprite.bounds.size.y;

        xPos = GetComponent<Transform>().transform.position.x;
        yPos = GetComponent<Transform>().transform.position.y;

        screenWidth = gameCamera.nativeResolution.x / 2f;
        screenHeight = gameCamera.nativeResolution.y / 2f;
    }

    void Update()
    {
        // Update position based on velocity
        xPos += xVel;
        yPos += yVel;
        
        // Left player movement
        if (Input.GetKey("left"))
        {
            {
                xVel -= 1f;
            }
        }

        // Right player movement
        if (Input.GetKey("right"))
        {
            {
                xVel += 1f;
            }
        }

        if (yVel > -10f)
        {
            yVel -= gravity / 100f;
        }

        // Horizontal speed limits
        if (xVel < -xVelMax)
        {
            xVel = -xVelMax;
        }
        else if (xVel > xVelMax)
        {
            xVel = xVelMax;
        }

        // Vertical speed limits
        if (yVel < -yVelMax)
        {
            yVel = -yVelMax;
        }
        else if (yVel > yVelMax)
        {
            yVel = yVelMax;
        }

        // Left screen border collision
        if (xPos <= -screenWidth + xSize / 2f && xVel < 0f)
        {
            xVel = -xVel;
            xPos = -screenWidth + xSize / 2f;
        }

        // Right screen border collision
        if (xPos >= screenWidth - xSize / 2f && xVel > 0f)
        {
            xVel = -xVel;
            xPos = screenWidth - xSize / 2f;
        }

        // Bottom screen border collision
        if (yPos <= -screenHeight + ySize / 2f && yVel < 0f)
        {
            yVel = -yVel;
            yPos = -screenHeight + ySize / 2f;
        }

        // Top screen border collision
        if (yPos >= screenHeight - ySize / 2f && yVel > 0f)
        {
            yVel = -yVel;
            yPos = screenHeight - ySize / 2f;
        }

        // Apply position transform values
        transform.position = new Vector3(xPos, yPos, 0f);

        // Register previous frame position
        prevXPos = xPos;
        prevYPos = yPos;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject colObject = col.gameObject;

        float colXPos = colObject.GetComponent<Transform>().transform.position.x;
        float colYPos = colObject.GetComponent<Transform>().transform.position.y;
        float colXSize = colObject.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        float colYSize = colObject.GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        
        // When colliding with a wall
        if (colObject.tag == "wall")
        {
            // Left side collision
            if (prevXPos - xSize / 2f >= colXPos + colXSize / 2f)
            {
                xVel = -xVel;
                xPos = prevXPos;
                yPos = prevYPos;
            }
            // Right side collision
            else if (prevXPos + xSize / 2f <= colXPos + colXSize / 2f)
            {
                xVel = -xVel;
                xPos = prevXPos;
                yPos = prevYPos;
            }

            // Bottom side collision
            if (prevYPos - ySize / 2f >= colYPos + colYSize / 2f)
            {
                yVel = -yVel;
                xVel = -xVel;
                xPos = prevXPos;
                yPos = prevYPos;
            }
            // Top side collision
            else if (prevYPos + ySize / 2f <= colYPos - colYSize / 2f)
            {
                yVel = -yVel;
                xVel = -xVel;
                xPos = prevXPos;
                yPos = prevYPos;
            }
        }
    }
}
