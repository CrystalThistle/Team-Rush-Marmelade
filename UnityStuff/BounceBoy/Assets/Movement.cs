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
    private float maxYpos;

    private PixelPerfectCamera gameCamera;

    void Start()
    {
        gameCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PixelPerfectCamera>();

        xSize = GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        ySize = GetComponent<SpriteRenderer>().sprite.bounds.size.y;

        xPos = GetComponent<Transform>().transform.position.x;
        yPos = GetComponent<Transform>().transform.position.y;

        maxYpos = gameCamera.nativeResolution.y / 2f;
    }

    void Update()
    {
        xPos += xVel;
        yPos += yVel;

        if (Input.GetKey("left"))
        {
            {
                xVel -= 1f;
            }
        }

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

        if (xVel < -xVelMax)
        {
            xVel = -xVelMax;
        }
        else if (xVel > xVelMax)
        {
            xVel = xVelMax;
        }

        if (yVel < -yVelMax)
        {
            yVel = -yVelMax;
        }
        else if (yVel > yVelMax)
        {
            yVel = yVelMax;
        }

        if (yPos <= -maxYpos + ySize / 2f && yVel < 0f)
        {
            yVel *= -1f;
            yPos = -maxYpos + ySize / 2f;
        }

        transform.position = new Vector3(xPos, yPos, 0f);

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

        if (colObject.tag == "wall")
        {
            
            if (prevXPos - xSize / 2f >= colXPos + colXSize / 2f )
            {
                xVel *= -1;
                xPos = prevXPos;
                yPos = prevYPos;
            }
            else if (prevXPos + xSize / 2f <= colXPos + colXSize / 2f)
            {
                xVel *= -1;
                xPos = prevXPos;
                yPos = prevYPos;
            }
            if (prevYPos - ySize / 2f >= colYPos + colYSize / 2f)
            {
                yVel *= -1;
                xPos = prevXPos;
                yPos = prevYPos;
            }
            else if (prevYPos + ySize / 2f <= colYPos - colYSize / 2f)
            {
                yVel *= -1;
                xPos = prevXPos;
                yPos = prevYPos;
            }
        }
    }
}
