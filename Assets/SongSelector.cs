using UnityEngine;
using System.Collections;

public class SongSelector : MonoBehaviour {

    private static TextMesh[] texts = new TextMesh[9];
    private static string[] names = new string[] { "Carry On Wayward Son", "Cherry Pie", "Heart Shaped Box", "I Love Rock And Roll" };
    private static int selected = 0;
    private static int upCount = 0;
    private static int downCount = 0;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < 4; i++)
        {
            texts[i] = GameObject.Find("Option (" + (i + 1) + ")").GetComponent<TextMesh>();
            texts[i].text = names[i];
        }
        /*
        string[] allFiles = System.IO.Directory.GetFiles(Application.dataPath + "/SongTextFiles/", "*.txt");
        int counter = 0;
        foreach (string file in allFiles)
        {
            string modFile = "";
            for (int j = 0; j < file.Length - 6; j++)
            {
                if (j >= (Application.dataPath + "/SongTextFiles/").Length)
                    modFile += file[j];
            }
            bool already = false;
            foreach (string name in names)
            {
                if (modFile == name)
                    already = true;
            }
            if (!already)
            {
                names[counter] = modFile;
                counter++;
            }
        }
        for (int z = 0; z < 10; z++)
            names[z] = makeNice(names[z]);
            */
        moveCursor();
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        bool change = false;
        if (Input.GetAxis("Vertical") == -1)
            upCount += 1;
        else
            upCount = 0;
        if (Input.GetAxis("Vertical") == 1)
            downCount += 1;
        else
            downCount = 0;
        if ((Input.GetKeyDown("down") || downCount > 4) && selected < 3)
        {
            downCount = 0;
            selected += 1;
            change = true;
        }
        if ((Input.GetKeyDown("up") || upCount > 4) && selected > 0)
        {
            upCount = 0;
            selected -= 1;
            change = true;
        }
        if (Input.GetKeyDown("space") || Input.GetKey("joystick button 5"))
        {
            NewNoteControl.SongName = names[selected];
            SongControl.trulyMagical = alex19bb(NewNoteControl.SongName);
            Application.LoadLevel("DifficultySelect");
        }
        if (change)
            moveCursor();
	}
    private static string makeNice(string badStr)
    {
        string fixedName = "";
        bool cap = true;
        for (int k = 0; k < badStr.Length; k++)
        {
            if (badStr[k] != '-')
            {
                if (!cap)
                    fixedName += badStr[k];
                else
                    fixedName += char.ToUpper(badStr[k]);
                cap = false;
            }
            else
            {
                fixedName += " ";
                cap = true;
            }
        }
        if (fixedName == "Eureka I Ve Found Love")
            return "Eureka I've Found Love";
        else
            return fixedName;
    }
    private static void moveCursor()
    {
        for (int i = 0; i < 4; i++)
        {
            Vector3 pos = texts[i].transform.position;
            if (i == selected)
            {
                texts[i].text = names[i];
                texts[i].fontSize = 120;
                texts[i].transform.position = new Vector3(pos.x, 1.0f, pos.z);
            }
            else if (i == selected - 1)
            {
                texts[i].text = names[i];
                texts[i].fontSize = 70;
                texts[i].transform.position = new Vector3(pos.x, 2.6f, pos.z);
            }
            else if (i == selected + 1)
            {
                texts[i].text = names[i];
                texts[i].fontSize = 70;
                texts[i].transform.position = new Vector3(pos.x, -0.6f, pos.z);
            }
            else
                texts[i].text = "";
        }
    }
    private static float alex19bb(string songname)
    {
        switch (songname)
        {
            case "Cherry Pie":
                return 0.9f; // 0.9f // 3.6f
            case "Carry On Wayward Son":
                return -0.15f;
            case "Heart Shaped Box":
                return 0.7f;
            case "I Love Rock And Roll":
                return -1.4f;
            case "Iron Man":
                return 6.66f;
            case "Killing In The Name":
                return 1.75f;
            default:
                return 0.0f;
        }
    }
}
