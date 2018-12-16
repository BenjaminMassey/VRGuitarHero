using UnityEngine;
using System;
using System.IO;
using System.Globalization;

public class SongControl : MonoBehaviour {

    public static GameObject[] Notes;
    public static float[] locations;
    private static int[] frets;
    private static float interval;
    public static float speed;
    public static float length;
    public static bool goAhead;
    public static float trulyMagical;

    // Use this for initialization
    void Start ()
    {
        goAhead = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public static void newSong(string songname, float rate)
    {
        speed = rate;
        //string path = @"C:\Users\benja\Documents\GuitarHero\Guitar Hero\Assets\SongTextFiles\" + songname + ".txt";
        //StreamReader file = File.OpenText(path);
        StreamReader file = File.OpenText(Application.dataPath + "/Resources/" + songname + ".txt");
        int numNotes = getFileLength(songname) - 2;
        Notes = new GameObject[numNotes];
        locations = new float[numNotes];
        frets = new int[numNotes];
        for (int i = 0; i < numNotes; i++)
        {
            string line = file.ReadLine();
            string[] nums = line.Split(':');
            locations[i] = float.Parse(nums[0], CultureInfo.InvariantCulture);
            frets[i] = int.Parse(nums[1]);
        }
        string lengthLine = file.ReadLine();
        //Debug.Log(songname + " is " + lengthLine + "long");
        string[] timesStr = lengthLine.Split(':');
        
        int[] times = { int.Parse(timesStr[0]), int.Parse(timesStr[1]) };
        Debug.Log("Using time of " + times[0] + ":" + times[1]);
        length = (times[0] * 60) + times[1];
        interval = length / int.Parse(file.ReadLine());

        //Debug.Log("Found " + locations.Length + " number of note locations");

        goAhead = true;
        /*
        for (int a = 0; a < locations.Length; a++)
            Debug.Log(locations[a] + ":" + frets[a]);
        */
    }
    public static void playSong(){
        for (int j = 0; j < locations.Length; j++)
        {
            float time = locations[j] * interval;
            time += NewNoteControl.magicConstant + trulyMagical;// + 1.85f;
            //Debug.Log((j + 1) + ", " + frets[j] + ", " + time);
            NewNoteControl.doNote(j + 1, frets[j], time);
        }
    }
    private static int getFileLength(string filename)
    {
        StreamReader file = File.OpenText(filename + ".txt");
        int numLines = 0;
        string line;
        while ((line = file.ReadLine()) != null)
            numLines++;
        return numLines;
    }

}
