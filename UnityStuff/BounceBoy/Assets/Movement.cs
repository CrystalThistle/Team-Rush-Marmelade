using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float xPos;
    public float yPos;
    public float xVel;
    public float yVel;
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

        maxYpos = gameCamera.nativeResolution.y / 2;
    }

    void Update()
    {
        xPos += xVel;
        yPos += yVel;

        if (yVel > -10)
        {
            yVel -= gravity / 100;
        }

        if (yPos <= -maxYpos + ySize / 2 && yVel < 0)
        {
            yVel *= -1;
            yPos = -maxYpos + ySize / 2;
        }

        transform.position = new Vector3(xPos, yPos, 0);

        prevXPos = xPos;
        prevYPos = yPos;
    }
}
