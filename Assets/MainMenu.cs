using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{

    private static int selected = 0;
    private static GameObject first;
    private static GameObject second;
    private static GameObject third;
    private static TextMesh textStart;
    private static TextMesh textSettings;
    private static TextMesh textCredits;
    private static int upCount = 0;
    private static int downCount = 0;

    // Use this for initialization
    void Start()
    {
        first = GameObject.Find("Option 1");
        second = GameObject.Find("Option 2");
        third = GameObject.Find("Option 3");
        textStart = GameObject.Find("TEXT: Start Game").GetComponent<TextMesh>();
        textSettings = GameObject.Find("TEXT: Settings").GetComponent<TextMesh>();
        textCredits = GameObject.Find("TEXT: Credits").GetComponent<TextMesh>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxis("Vertical") == -1)
            upCount += 1;
        else
            upCount = 0;
        if (Input.GetAxis("Vertical") == 1)
            downCount += 1;
        else
            downCount = 0;
        if ((Input.GetKeyDown("up") || upCount > 4) && selected > 0)
        {
            upCount = 0;
            selected -= 1;
        }
        if ((Input.GetKeyDown("down") || downCount > 4) && selected < 2)
        {
            downCount = 0;
            selected += 1;
        }
        if (selected == 0)
        {
            first.transform.position = new Vector3(first.transform.position.x, first.transform.position.y, -5.52f);
            second.transform.position = new Vector3(second.transform.position.x, second.transform.position.y, -5.50f);
            third.transform.position = new Vector3(third.transform.position.x, third.transform.position.y, -5.50f);
            textStart.color = new Color(0, 0, 0, 1); // Black
            textSettings.color = new Color(1, 1, 1, 1); // White
            textCredits.color = new Color(1, 1, 1, 1); // White
        }
        if (selected == 1)
        {
            first.transform.position = new Vector3(first.transform.position.x, first.transform.position.y, -5.50f);
            second.transform.position = new Vector3(second.transform.position.x, second.transform.position.y, -5.52f);
            third.transform.position = new Vector3(third.transform.position.x, third.transform.position.y, -5.50f);
            textStart.color = new Color(1, 1, 1, 1); // White
            textSettings.color = new Color(0, 0, 0, 1); // Black
            textCredits.color = new Color(1, 1, 1, 1); // White
        }
        if (selected == 2)
        {
            first.transform.position = new Vector3(first.transform.position.x, first.transform.position.y, -5.50f);
            second.transform.position = new Vector3(second.transform.position.x, second.transform.position.y, -5.50f);
            third.transform.position = new Vector3(third.transform.position.x, third.transform.position.y, -5.52f);
            textStart.color = new Color(1, 1, 1, 1); // White
            textSettings.color = new Color(1, 1, 1, 1); // White
            textCredits.color = new Color(0, 0, 0, 1); // Black
        }
        if (Input.GetKeyDown("space") || Input.GetKey("joystick button 5"))
        {
            if (selected == 0)
                Application.LoadLevel("SongSelect");
            if (selected == 1)
                textSettings.text = "nah";
            if (selected == 2)
                Application.LoadLevel("Credits");
        }
    }
}
