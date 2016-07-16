using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SelectionScript : MonoBehaviour
{
    public int optionAmount;
    public float posX;
    public float posY;
    public float optionOffset;

    private int curOption = 0;
    private int originX;
    private int originY;
    private float targetY;

	// Use this for initialization
	void Start()
    {
        this.posX = GetComponent<Transform>().transform.position.x + posX;
        this.posY = GetComponent<Transform>().transform.position.y + posY;
    }
	
	// Update is called once per frame
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch (curOption)
            {
                // One case per option,
                // responds when enter is pressed
                case 0:
                    SceneManager.LoadScene(1);
                    break;
                case 1:
                    Application.Quit();
                    break;
            }
        }
        else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && curOption > 0)
        {
            curOption--;
            targetY = originY + (-optionOffset * curOption);
        }
        else if((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && curOption < optionAmount)
        {
            curOption++;
            targetY = originY + (-optionOffset * curOption);
        }

        posY -= (float)((posY - targetY) * 0.5);

        transform.position = new Vector3(posX, posY, 0f);
    }
}
