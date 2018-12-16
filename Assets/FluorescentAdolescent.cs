using System;
using UnityEngine;

internal class FluorescentAdolescent : MonoBehaviour
{
    public static GameObject[] Notes = new GameObject[25];
    public static float length = 2.883f;

    // Class that handles playing Fluorescent Adolescent
    public static void intro(float startTime)
    {
        Debug.Log("running intro");
        // Plays the mainRiff to the song Fluorescent Adolescent
        NewNoteControl.doNote(1, 1, startTime);
        NewNoteControl.doNote(2, 1, 0.28f + startTime);
        NewNoteControl.doNote(3, 1, 0.54f + startTime);
        NewNoteControl.doNote(4, 1, 1.05f + startTime);
        NewNoteControl.doNote(5, 2, 1.45f + startTime);
        NewNoteControl.doNote(6, 3, 1.65f + startTime);
        NewNoteControl.doNote(7, 1, 1.88f + startTime);
        NewNoteControl.doNote(8, 3, 2.15f + startTime);
        NewNoteControl.doNote(9, 3, 2.42f + startTime);
        NewNoteControl.doNote(10, 3, 2.69f + startTime);
        NewNoteControl.doNote(11, 1, 3.21f + startTime);
        NewNoteControl.doNote(12, 1, 3.74f + startTime); // 3.54
        NewNoteControl.doNote(13, 3, 4.28f + startTime); // 3.88
        NewNoteControl.doNote(14, 3, 4.55f + startTime); // 4.15
        NewNoteControl.doNote(15, 3, 4.75f + startTime); // 4.35
        NewNoteControl.doNote(16, 2, 5.45f + startTime); // 5.05
        NewNoteControl.doNote(17, 1, 5.9f + startTime); // 5.5
        NewNoteControl.doNote(18, 3, 6.15f + startTime); // 5.75
        NewNoteControl.doNote(19, 1, 6.42f + startTime); // 6.02
        NewNoteControl.doNote(20, 1, 6.7f + startTime); // 6.3
        NewNoteControl.doNote(21, 1, 6.96f + startTime); // 6.56
        NewNoteControl.doNote(22, 1, 7.5f + startTime); // 7.1
        NewNoteControl.doNote(23, 3, 7.78f + startTime); // 7.38
        NewNoteControl.doNote(24, 2, 8.03f + startTime); // 7.63
        NewNoteControl.doNote(25, 1, 8.3f + startTime); // 7.9
    }
    public static void mainRiff(float startTime)
    {
        NewNoteControl.doNote(1, 1, 0.28f + startTime);
        NewNoteControl.doNote(2, 2, 1.45f + startTime);
        NewNoteControl.doNote(3, 3, 1.65f + startTime);
        NewNoteControl.doNote(4, 1, 1.88f + startTime);
        NewNoteControl.doNote(5, 3, 2.15f + startTime);
        NewNoteControl.doNote(6, 1, 3.21f + startTime);
        NewNoteControl.doNote(7, 1, 3.74f + startTime);
        NewNoteControl.doNote(8, 3, 4.28f + startTime);
        NewNoteControl.doNote(9, 2, 5.45f + startTime);
        NewNoteControl.doNote(10, 1, 5.9f + startTime);
        NewNoteControl.doNote(11, 3, 6.15f + startTime);
        NewNoteControl.doNote(12, 1, 6.42f + startTime);
        NewNoteControl.doNote(13, 1, 7.3f + startTime); // 7.5
        NewNoteControl.doNote(14, 3, 7.58f + startTime); // 7.78
        NewNoteControl.doNote(15, 2, 7.83f + startTime); // 8.03
        NewNoteControl.doNote(16, 1, 8.1f + startTime); // 8.3
    }
    public static void chords(float startTime)
    {
        NewNoteControl.doNote(1, 1, 0.3f + startTime); // 0.1
        NewNoteControl.doNote(2, 3, 0.3f + startTime);

        NewNoteControl.doNote(3, 1, 0.56f + startTime); // 0.36
        NewNoteControl.doNote(4, 3, 0.56f + startTime);

        NewNoteControl.doNote(5, 1, 2.35f + startTime); // 2.45
        NewNoteControl.doNote(6, 3, 2.35f + startTime);

        NewNoteControl.doNote(7, 1, 2.61f + startTime); // 2.71
        NewNoteControl.doNote(8, 3, 2.61f + startTime);

        NewNoteControl.doNote(9, 1, 4.73f + startTime); // 4.83
        NewNoteControl.doNote(10, 3, 4.73f + startTime);

        NewNoteControl.doNote(11, 1, 4.98f + startTime); // 5.08
        NewNoteControl.doNote(12, 3, 4.98f + startTime);

        NewNoteControl.doNote(13, 1, 5.98f + startTime);
        NewNoteControl.doNote(14, 2, 5.98f + startTime);

        NewNoteControl.doNote(15, 1, 6.28f + startTime);
        NewNoteControl.doNote(16, 2, 6.28f + startTime);

        NewNoteControl.doNote(17, 2, 6.98f + startTime);
        NewNoteControl.doNote(18, 3, 6.98f + startTime);

        NewNoteControl.doNote(19, 2, 7.28f + startTime);
        NewNoteControl.doNote(20, 3, 7.28f + startTime);

        NewNoteControl.doNote(21, 2, 7.98f + startTime);
        NewNoteControl.doNote(22, 3, 7.98f + startTime);

        NewNoteControl.doNote(23, 2, 8.28f + startTime);
        NewNoteControl.doNote(24, 3, 8.28f + startTime);
    }
    public static void verseTwo(float startTime)
    {
        NewNoteControl.doNote(1, 1, 0f + startTime);
        NewNoteControl.doNote(2, 2, 0.25f + startTime);
        NewNoteControl.doNote(3, 3, 0.5f + startTime);
        NewNoteControl.doNote(4, 3, 0.75f + startTime);
        
        /*
        NewNoteControl.doNote(5, 1, 3f + startTime);
        NewNoteControl.doNote(6, 2, 3f + startTime);

        NewNoteControl.doNote(7, 1, 3.8f + startTime);
        NewNoteControl.doNote(8, 2, 3.8f + startTime);

        NewNoteControl.doNote(9, 1, 4.1f + startTime);
        NewNoteControl.doNote(10, 2, 4.1f + startTime);

        NewNoteControl.doNote(11, 1, 4.4f + startTime);
        NewNoteControl.doNote(12, 2, 4.4f + startTime);
        */
    }
}