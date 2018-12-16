using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class NewNoteControl : MonoBehaviour {

    private static AudioSource song;
    private static float randyTemp;
    private static int frameCount;
    private static float framerate;
    public static int score;
    private static TextMesh scoreDisplay;
    private static GameObject pointer;
    public static bool playing;
    public static string SongName;
    public static int difficulty;
    public static float magicConstant;
    public static float pauseTime;
    public static bool pausing;
    public static float realTime;
    private static float songPercent;
    private static bool swag = true;
    private static int noteCount;

    // Use this for initialization
    void Start() {
        playing = false;
        song = GameObject.Find("Song").GetComponent<AudioSource>();
        string LowerSongName = "";
        foreach (char letter in SongName)
            LowerSongName += char.ToLower(letter);
        Debug.Log("Looking for song " + LowerSongName);
        song.clip = Resources.Load(LowerSongName) as AudioClip;
        //magicConstant = realTime;
        //song.Play();
        frameCount = 0;
        score = 0;
        pausing = false;
        randyTemp = 0;
        pauseTime = 0;
        noteCount = 0;
        scoreDisplay = GameObject.Find("Score").GetComponent<TextMesh>();
        pointer = GameObject.Find("Pointer");
        string SongNameNoSpaces = "";
        foreach (char chr in SongName)
        {
            if (chr != ' ')
                SongNameNoSpaces += char.ToLower(chr);
            else
                SongNameNoSpaces += '-';
        }
        SongControl.newSong(SongNameNoSpaces + "-" + difficulty, 3.0f);
        GameObject.Find("darude-sandstorm").GetComponent<TextMesh>().text = SongName;
        //song.clip = Resources.Load(SongName.ToLower()) as AudioClip;
    }

    // Update is called once per frame
    void Update() {
        frameCount++;
        if (swag)
            scoreDisplay.text = score.ToString();
        framerate = 1.0f / Time.deltaTime;
        realTime = Time.time - pauseTime;
        if (pausing)
            handlePause();
        if (Input.GetKeyDown("space") || Input.GetKeyDown("joystick button 8") || Input.GetKeyDown("joystick button 9"))
        {
            pausing = true;
            randyTemp = Time.time;
        }
        if (!pausing)
        {
            if (SongControl.goAhead)
            {
                if (!playing)
                {
                    song.Play();
                    Debug.Log("Should have started the song");
                    magicConstant = realTime;
                    Debug.Log("Started playing at " + magicConstant + " which is now the constant");
                }

                SongControl.playSong();
                if(swag)
                    playing = true;
            }
        }
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

    public static void doNote(int noteNumber, int fret, float time)
    {
        float speed = SongControl.speed;
        if (timeIs(time))
        {
            if (SongControl.Notes[noteNumber - 1] == null)
            {
                if (fret == 1)
                {
                    SongControl.Notes[noteNumber - 1] = createNote(0.799f, 6.4f, -10.5f);
                    SongControl.Notes[noteNumber - 1].GetComponent<Renderer>().material = (Material) Resources.Load("OffGreen");
                }
                if (fret == 2)
                {
                    SongControl.Notes[noteNumber - 1] = createNote(1.124f, 6.4f, -10.5f);
                    SongControl.Notes[noteNumber - 1].GetComponent<Renderer>().material = (Material)Resources.Load("OffRed");
                }
                if (fret == 3)
                {
                    SongControl.Notes[noteNumber - 1] = createNote(1.449f, 6.4f, -10.5f);
                    SongControl.Notes[noteNumber - 1].GetComponent<Renderer>().material = (Material)Resources.Load("OffYellow");
                }
                if (fret == 4)
                {
                    SongControl.Notes[noteNumber - 1] = createNote(1.774f, 6.4f, -10.5f);
                    SongControl.Notes[noteNumber - 1].GetComponent<Renderer>().material = (Material)Resources.Load("OffBlue");
                }
                if (fret == 5)
                {
                    SongControl.Notes[noteNumber - 1] = createNote(2.099f, 6.4f, -10.5f);
                    SongControl.Notes[noteNumber - 1].GetComponent<Renderer>().material = (Material)Resources.Load("OffOrange");
                }
                noteCount += 1;
            }
        }
        if (timeIsInbetween(time, time + (2.0f * (1 / speed))))
        {
            if (SongControl.Notes[noteNumber - 1] != null)
            {
                float unitsY = -1.55f / (framerate * 2.02f);
                float unitsZ = -1.90f / (framerate * 2.02f);
                //unitsY = unitsY * 1.04f;
                //unitsZ = unitsZ * 1.04f;
                moveObjectBy(SongControl.Notes[noteNumber - 1], 0f, unitsY * speed, unitsZ * speed);
            }
        }
        if (timeIs(time + (2.2f * (1 / speed))))
        {
            if (SongControl.Notes[noteNumber - 1] != null)
            {
                Destroy(SongControl.Notes[noteNumber - 1]);
                Vector3 pos = pointer.transform.position;
                if (pos.x > -1.7f)
                    pointer.transform.position = new Vector3(pos.x - 0.045f, pos.y, pos.z);
                else
                    fail();
            }
        }
    }
    private static bool timeIs(float time)
    {
        float seconds = realTime;//(1.0f / framerate) * frameCount;

        bool answer;
        if (Math.Round(time, 1) == Math.Round(seconds, 1))
            answer = true;
        else
            answer = false;
        //if (answer)
        //    Debug.Log("Time is " + time);

        return answer;
    }

    private static bool timeIsInbetween(float timeA, float timeB)
    {
        float seconds = realTime;//(1.0f / framerate) * frameCount;

        bool answer;
        if (Math.Round(timeA, 2) <= Math.Round(seconds, 2) && Math.Round(timeB, 2) >= Math.Round(seconds, 2))
            answer = true;
        else
            answer = false;

        return answer;
    }

    private static void fail()
    {
        song.Stop();
        scoreDisplay.text = "";
        GameObject.Find("Note Receiver 1").transform.position = new Vector3(0f, -50f, 0f);
        GameObject.Find("Note Receiver 2").transform.position = new Vector3(0f, -50f, 0f);
        GameObject.Find("Note Receiver 3").transform.position = new Vector3(0f, -50f, 0f);
        GameObject.Find("Note Receiver 4").transform.position = new Vector3(0f, -50f, 0f);
        GameObject.Find("Note Receiver 5").transform.position = new Vector3(0f, -50f, 0f);
        GameObject.Find("HappinessBar").transform.position = new Vector3(0f, -50f, 0f);
        GameObject.Find("Pointer").transform.position = new Vector3(0f, -50f, 0f);
        GameObject.Find("Music Area").transform.position = new Vector3(0f, -50f, 0f);
        foreach (GameObject note in SongControl.Notes)
            Destroy(note);
        GameObject.Find("darude-sandstorm").GetComponent<TextMesh>().text = "";
        GameObject black = GameObject.Find("Black");
        black.transform.position = new Vector3(1.48f, 5.3f, -9f);
        string message = "You failed with a score \n of " + score;
        if (swag)
        {
            songPercent = (float) (Math.Round((((float)noteCount / (float)SongControl.locations.Length) * 100f), 2));
            Debug.Log("noteCount: " + noteCount + "  |  locations.Length: " + SongControl.locations.Length + "  |  songPercent " + songPercent.ToString());
            swag = false;
        }
        message += " and got \n" + songPercent.ToString() + "% of the way \n through the song";
        TextMesh display = GameObject.Find("EndText").GetComponent<TextMesh>();
        display.text = message;
        display.transform.position = new Vector3(-0.42f, 6.17f, -9);
        display.fontSize = 35;
        playing = false;
    }

    private static void handlePause()
    {
        if (pausing)
        {
            song.Pause();
            pauseTime = Time.time - randyTemp;
            //GameObject.Find("PauseBlock").transform.position = new Vector3(1.485f, 5.89f, -12.806f);
            GameObject.Find("darude-sandstorm").GetComponent<TextMesh>().text = "Press Green to close or Red to quit";
            if (Input.GetKeyDown("1") || Input.GetKeyDown("space")  || Input.GetKey("joystick button 5") || Input.GetKeyDown("joystick button 8") || Input.GetKeyDown("joystick button 9"))
                pausing = false;
            if (Input.GetKeyDown("2") || Input.GetKey("joystick button 1"))
                Application.LoadLevel("MainMenu");

        }
        if (!pausing)
        {
            song.UnPause();
            GameObject.Find("PauseBlock").transform.position = new Vector3(1.485f, -5f, -12.806f);
            GameObject.Find("darude-sandstorm").GetComponent<TextMesh>().text = SongName;
        }
    }
}
