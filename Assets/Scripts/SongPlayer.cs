using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SongPlayer : MonoBehaviour {

    List<List<Note>> tabs;
    const float BEAT_TO_SEC = 0.5f;

    GameObject[] tabObjects;

    List<GameObject> currentNotes;

    int tabIndex = 0;
    float deltaT = 0;
    public float zoffset = 33, xoffset = 20;

    bool done = false;

	// Use this for initialization
	void Start () {
        tabs = SongLibary.getJingleBells();
        tabObjects = new GameObject[6];
        for (int i = 0; i < 6; i++)
            //tabObjects[i] = (GameObject)Resources.Load("String"+(i+1));
            tabObjects[i] = (GameObject)Resources.Load(""+(i + 1));

        currentNotes = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < currentNotes.Count; i++)
        {
            GameObject toDelete = currentNotes[i];
            NoteObject n = (NoteObject)toDelete.GetComponent<NoteObject>();
            if (n.done)
            {
                currentNotes.RemoveAt(i);
                GameObject.Destroy(toDelete);
            }
        }
        if (done)
        {
            return;
        }
        deltaT -= Time.deltaTime;
        if (deltaT <= 0)
        {
            for (int i = 0; i < tabs[tabIndex].Count; i++)
            {
                Note n = tabs[tabIndex][i];
                GameObject newNote = Instantiate(tabObjects[n.strNum-1]);
                Vector3 pos = new Vector3(xoffset, 0, zoffset - (-1 + n.tabNum * 3.5f));
                newNote.transform.position = pos;
                currentNotes.Add(newNote);
                deltaT = n.dur * BEAT_TO_SEC;
            }
            tabIndex++;
            if (tabIndex > tabs.Count-1)
            {
                done = true;
                Debug.Log("Done song!");
            }
        }
	}
}
