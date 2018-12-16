using UnityEngine;
using System.Collections;

public class Note1Control : MonoBehaviour {
    // Controls the green note receiver (referred to as Note Receiver 1)

    /*

    public static bool pressed;
    public static bool strummed;
    public static bool touching;

    public static GameObject noteStrummed = null;

    
    void Start () {
        // Start() is called once the unity project is run

        // We want to check things continuously, so no initalization code
    }

    
    void Update () {
        // Update() is called every frame

        // See what coniditons are currently true
        checkPressed();
        checkStrummed();
        checkTouching();

        // If the player pressed note 1 and strums while there is a note touching the receiver, that's good
        if (pressed && touching && strummed)
        {
            NoteControl.score += 1; // Increase score (will be updated into game via NoteControl.updateScore()
            Destroy(noteStrummed); // Destroy the note that was strummed
        }

        // If the player ever strums while the receiver is not pressed, that's bad
        if (!pressed && strummed)
            NoteControl.score -= 1; // Decrease score (will be updated into game via NoteControl.updateScore()
        // Also bad if he presses and strums at the wrong time - when the note is not touching the receiver
        if (pressed && strummed && !touching)
            NoteControl.score -= 1; // Decrease score (will be updated into game via NoteControl.updateScore()
    }

    void checkPressed() {
        // See if the number 1 key is being pressed

        // Need the colors so the note reciever can light up while being pressed
        Material original = Resources.Load("LightGrey", typeof(Material)) as Material;
        Material green = Resources.Load("Green", typeof(Material)) as Material;

        if (Input.GetKey("1"))
        {
            GetComponent<Renderer>().material = green;
            pressed = true;
        }
        else
        {
            GetComponent<Renderer>().material = original;
            pressed = false;
        }
    }

    void checkStrummed() {
        // See if the player strummed using up or down arrow keys

        if (Input.GetKeyDown("up") || Input.GetKeyDown("down"))
            strummed = true;
        else
            strummed = false;
    }

    void checkTouching() {
        // See if a note is touching the note receiver
        touching = false;
        foreach (GameObject note in FluorescentAdolescent.Notes)
        {
            if (note != null)
            {
                if (GetComponent<Collider>().bounds.Intersects(note.GetComponent<Collider>().bounds))
                {
                    noteStrummed = note;
                    touching = true;
                }
            }
        }
    }

    */

}
