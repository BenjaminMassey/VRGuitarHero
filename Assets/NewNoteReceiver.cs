using UnityEngine;
using System;

public class NewNoteReceiver : MonoBehaviour {
    private static bool pressed;
    private static bool strumming;
    private static bool touchingNote;
    private static int temp;
    private static GameObject pointer;

    // Use this for initialization
    void Start () {
        temp = 0;
        pointer = GameObject.Find("Pointer");
	}

    // Update is called once per frame
    void Update() {
        //if (touchingNote)
        //    Debug.Log(name + " noticed a note. You pressed/strumming: " + ": " + pressed + "/" + strumming);
        if (NewNoteControl.playing)
        {
            if (Input.GetKeyDown("up") || Input.GetKeyDown("down") || Input.GetAxis("Vertical") == -1 || Input.GetAxis("Vertical") == 1)
                strumming = true;
            else
                strumming = false;
            string myNum = name[name.Length - 1].ToString();
            if (Input.GetKey(myNum) || Input.GetKey(getJoystickEquivalent(myNum)))
                pressed = true;
            else
                pressed = false;
            if (pressed)
            {
                if (name == "Note Receiver 1")
                    GetComponent<Renderer>().material = (Material)Resources.Load("Green");
                if (name == "Note Receiver 2")
                    GetComponent<Renderer>().material = (Material)Resources.Load("Red");
                if (name == "Note Receiver 3")
                    GetComponent<Renderer>().material = (Material)Resources.Load("Yellow");
                if (name == "Note Receiver 4")
                    GetComponent<Renderer>().material = (Material)Resources.Load("Blue");
                if (name == "Note Receiver 5")
                    GetComponent<Renderer>().material = (Material)Resources.Load("Orange");
            }
            else
                GetComponent<Renderer>().material = (Material)Resources.Load("LightGrey");
            touchingNote = false;
            if (strumming)
            {
                for (int i = 0; i < SongControl.Notes.Length; i++)
                {
                    if (SongControl.Notes[i] != null)
                    {
                        if (GetComponent<BoxCollider>().bounds.Contains(SongControl.Notes[i].transform.position))
                        {
                            touchingNote = true;
                            temp = i;
                        }
                    }
                }
            }
            if (pressed && strumming && touchingNote)
            {
                Destroy(SongControl.Notes[temp]);
                NewNoteControl.score += 100;
                Vector3 pos = pointer.transform.position;
                if (pos.x <= -0.1f)
                    pointer.transform.position = new Vector3(pos.x + 0.1f, pos.y, pos.z);
                else
                    pointer.transform.position = new Vector3(0.0f, pos.y, pos.z);
                Debug.Log("YOU HIT A NOTE OMG");
            }
            /*
            if (strumming && (!touchingNote || !pressed))
            {
                Vector3 pos = pointer.transform.position;
                if(pos.x > -1.66f)
                    pointer.transform.position = new Vector3(pos.x - 0.02f, pos.y, pos.z);
                else
                    pointer.transform.position = new Vector3(-1.66f, pos.y, pos.z);
            }
            */
        }
	}
    string getJoystickEquivalent(string number) {
        if (number == "1")
            return "joystick button 5";
        else if (number == "2")
            return "joystick button 1";
        else if (number == "3")
            return "joystick button 0";
        else if (number == "4")
            return "joystick button 2";
        else if (number == "5")
            return "joystick button 3";
        else
            return "";
    }
}
