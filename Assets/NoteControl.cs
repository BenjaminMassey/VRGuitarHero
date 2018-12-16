using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class NoteControl : MonoBehaviour
{
    // Main control for sending all of the notes down the note area. Both creates the notes and moves them over time.
    // Does not deal with interacting with the notes (such as pressing), simply creating and sending them.
    // The score is also stored here, so that the score is not attributed to any specific note receiver.

    // Text object to keep track of and dislay the score - initialized in the start() method
    Text scoreText;

    // Variable to store the player's score, which will be applied to the Text object with updateScore()
    public static int score = 0;

    private static int counter = 0;

    private static int counter2 = 0;

    // Song to be played - initialized in Start()
    public static AudioSource song;

    // OLD TIMING
    //IEnumerator Start()

    void Start()
    {
        // Start() is called once the unity project is run

        // Initialize scoreText
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();

        // Initilaize song and play it
        song = GameObject.Find("Song").GetComponent<AudioSource>();
        song.Play();

        // Main game loop where we update the counter and do the notes
        /* OLD
        while (true) {
            FluorescentAdolescent.intro(0.55f); // .55
            FluorescentAdolescent.mainRiff(8.95f); // 8.95
            FluorescentAdolescent.mainRiff(25.7f); // 25.7
            FluorescentAdolescent.chords(34.42f); // 34.42

            // OLD TIMING
            //yield return new WaitForSeconds(0.01f);
            //counter += 1;
        }
        */

    }


    void Update()
    {
        // Update() is called every frame
        updateScore(); // Self explanatory
        counter += 1;
        FluorescentAdolescent.intro(0.55f); // .55
        FluorescentAdolescent.mainRiff(8.95f); // 8.95
        FluorescentAdolescent.mainRiff(25.7f); // 25.7
        FluorescentAdolescent.chords(34.42f); // 34.42
    }

    private static GameObject createNote(float x, float y, float z)
    {
        // Create and return a cube at a given location, which represents our note.

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube); // Create basic cube
        cube.transform.localScale = new Vector3(0.293f, 0.293f, 0.293f); // Shape it to our note size
        cube.transform.position = new Vector3(x, y, z); // Teleport it to the given position
        return cube; // Return the newly formed and placed object
    }

    private static void moveObjectBy(GameObject obj, float changeX, float changeY, float changeZ)
    {
        // Takes a certain object (such as a note) and moves it by a given x, y, and z value

        if (obj != null) // Avoid null errors
        {
            // Get original position
            float startX = obj.transform.position.x;
            float startY = obj.transform.position.y;
            float startZ = obj.transform.position.z;

            // Calculate the ending position by modifying the start by the given change
            float endX = startX + changeX;
            float endY = startY + changeY;
            float endZ = startZ + changeZ;

            // Teleport the given object to the calculated end point
            obj.transform.position = new Vector3(endX, endY, endZ);
        }
    }
    /*
    public static bool doNote(int noteNumber, int fret, float noteTime) {
        // Do a note for the given fret at a given time in seconds
        // Returns whether or not the note is done being played

        /* OLD TIMING
        // We know that 30 counts = 0.5 seconds, so use that to convert the given time to counts
        int timeInCounts = (int) Math.Round(30 * time / 0.5);

        // Want to create the note 0.5 seconds before it should be played, so 30 counts before
        if (counter == timeInCounts - 30)
        */
    /*
    float currentTime = (float) Math.Round(Time.time, 2);

    float startNoteTime = currentTime - 0.50f;
    float startRange = startNoteTime - 0.10f;
    float endRange = startNoteTime + 0.10f;

    if (startNoteTime < endRange && startNoteTime > startRange)
    {
        if (FluorescentAdolescent.Notes[noteNumber - 1] == null)
        {
            if (fret == 1)
                FluorescentAdolescent.Notes[noteNumber - 1] = createNote(1.092f, 6.4f, -10.5f);
            if (fret == 2)
                FluorescentAdolescent.Notes[noteNumber - 1] = createNote(1.441f, 6.4f, -10.5f);
            if (fret == 3)
                FluorescentAdolescent.Notes[noteNumber - 1] = createNote(1.801f, 6.4f, -10.5f);
        }
    }

    // While in between where you created the note and where it should be played, move it a bit at a time
    // These values are simply (0, -1.55, -1.9) total over 30 counts

    // OLD TIMING
    //if (counter > timeInCounts - 30 && counter < timeInCounts)

    float fps = 1 / Time.deltaTime;
    if(counter % 30 == 0)
        Debug.Log(fps);
    if (currentTime > startNoteTime && currentTime < noteTime)
    {
        //if (FluorescentAdolescent.Notes[noteNumber - 1] != null)
        //moveObjectBy(FluorescentAdolescent.Notes[noteNumber - 1], 0f, -0.05167f, -0.06333f);
        float unitsY = (-1.55f * noteTime) / (fps * counter);
        float unitsZ = (-1.9f * noteTime) / (fps * counter);
        moveObjectBy(FluorescentAdolescent.Notes[noteNumber - 1], 0f, unitsY, unitsZ);
    }

    // Where the note is supposed to be played

    // OLD TIMING
    //if (counter == timeInCounts)

    startRange = noteTime - 0.10f;
    endRange = noteTime + 0.10f;

    if (currentTime < endRange && currentTime > startRange)
    {
        //if (FluorescentAdolescent.Notes[noteNumber - 1] != null)
            Destroy(FluorescentAdolescent.Notes[noteNumber - 1]);
        return true;
    }
    return false;
}
*/
    public static void doNote(int noteNumber, int fret, float time)
    {
        if (timeIs(time))
        {
            if (FluorescentAdolescent.Notes[noteNumber - 1] == null)
            {
                if (fret == 1)
                    FluorescentAdolescent.Notes[noteNumber - 1] = createNote(1.092f, 6.4f, -10.5f);
                if (fret == 2)
                    FluorescentAdolescent.Notes[noteNumber - 1] = createNote(1.441f, 6.4f, -10.5f);
                if (fret == 3)
                    FluorescentAdolescent.Notes[noteNumber - 1] = createNote(1.801f, 6.4f, -10.5f);
            }
        }

        float framerate = 1.0f / Time.deltaTime;
        int frames = (int) Math.Round(framerate, 0);

        counter2++;

        float unitsY = -1.55f / frames;
        float unitsZ = -1.9f / frames;
        if(counter2 < frames)
        {
            moveObjectBy(FluorescentAdolescent.Notes[noteNumber - 1], 0f, unitsY, unitsZ);
        }
        if (counter2 >= frames)
        {
            counter2 = 0;
            if (FluorescentAdolescent.Notes[noteNumber - 1] != null)
                Destroy(FluorescentAdolescent.Notes[noteNumber - 1]);
        }
    }

    static bool timeIs(float time)
    {
        float framerate = 1.0f / Time.deltaTime;
        float seconds = (1.0f / framerate) * counter;

        bool answer;
        if (Math.Round(time, 2) == Math.Round(seconds, 2))
            answer = true;
        else
            answer = false;
        if (answer)
            Debug.Log("Time is " + time);

        return answer;
    }
    /*
    public static IEnumerator doNote(int noteNum, int fret, float time)
    {
        Debug.Log("Running doNote()");
        if (timeIs(time))
        {
            int[] parms = new int[2] { noteNum, fret };
            yield return StartCoroutine(note(parms));
        }
        else
        {
            yield return null;
        }
            
    }
    */
    
    void updateScore()
    {
        // Simply changes the text of the object in the unity game to match the variable in this class

        scoreText.text = score.ToString();
    }
}
