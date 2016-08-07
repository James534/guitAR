using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;

public class SongPlayer : MonoBehaviour
{

    List<List<Note>> tabs;
    const float BEAT_TO_SEC = 0.5f;

    GameObject[] tabObjects;
    List<GameObject> currentNotes;

    List<string> playedTabs;

    int tabIndex = 0;
    float deltaT = 0;
    public float zoffset = 33, xoffset = 20;

    public bool done = false;
    bool donePlaying = false;

    // Use this for initialization
    void Start () {
            Debug.Log("Starting song player!");
        tabs = SongLibary.getJingleBells();
        tabObjects = new GameObject[6];
        for (int i = 0; i < 6; i++)
            //tabObjects[i] = (GameObject)Resources.Load("String"+(i+1));
            tabObjects[i] = (GameObject)Resources.Load("" + (i + 1));

        currentNotes = new List<GameObject>();
        playedTabs = new List<string>();
    }

    string genNotesKey(Note n)
    {
        return "" + n.strNum + "," + n.tabNum;
    }

	// Update is called once per frame
	void Update ()
    {
        if (done)
        {
            return;
        }
        if (!SocketListener.read) {
            string[] clientMsg = SocketListener.msg.Split(';');
            SocketListener.read = true;
            for (int i = 0; i < clientMsg.Length; i++)
            {
                int[] noteProperties = Array.ConvertAll<string, int>(clientMsg[i].Split(','), int.Parse);
                for (int n = 0; n < currentNotes.Count; n++)
                {
                    NoteObject curNote = currentNotes[n].GetComponent<NoteObject>();
                    if (curNote.note.strNum == noteProperties[0] && curNote.note.tabNum == noteProperties[1])
                    {
                        print("Hitting note " + clientMsg[i]);
                        curNote.hit = true;
                        break;
                    }
                }
            }
        }
        for (int i = 0; i < currentNotes.Count; i++)
        {
            GameObject toDelete = currentNotes[i];
            NoteObject n = toDelete.GetComponent<NoteObject>();
            if (n.hit)
            {
                print("Hit note!");
                currentNotes.RemoveAt(i);
                Destroy(toDelete);
                continue;
            }
            else if (n.done)
            {
                currentNotes.RemoveAt(i);
                GameObject.Destroy(toDelete);
            }
        }
        if (donePlaying && currentNotes.Count == 0)
        {
            done = true;
            return;
        }

        deltaT -= Time.deltaTime;
        if (deltaT <= 0)
        {
            for (int i = 0; i < tabs[tabIndex].Count; i++)
            {
                Note n = tabs[tabIndex][i];
                GameObject newNoteObj = Instantiate(tabObjects[n.strNum-1]);
                newNoteObj.GetComponent<NoteObject>().note = new Note(n.strNum, n.tabNum, n.dur);
                Vector3 pos = new Vector3(xoffset, 0, zoffset - (-1 + n.tabNum * 3.5f));
                newNoteObj.transform.position = pos;
                currentNotes.Add(newNoteObj);
                deltaT = n.dur * BEAT_TO_SEC;
            }
            tabIndex++;
            if (tabIndex > tabs.Count - 1)
            {
                donePlaying = true;
                Debug.Log("Done song!");
            }
        }
    }
}