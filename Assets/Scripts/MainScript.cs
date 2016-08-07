using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour {

    string musicName = "";
    GameObject canvas;
    GameObject canvasObj;
    GameObject songPlayer;
    GameObject playing = null;

	// Use this for initialization
	void Start ()
    {
        songPlayer = (GameObject)Resources.Load("SongPlayerObj");
        canvas = (GameObject)Resources.Load("Canvas");
        canvasObj = Instantiate(canvas);
    }
	
	// Update is called once per frame
	void Update () {
        handleKeyboard();
        if (playing != null)
        {
            if (playing.GetComponent<SongPlayer>().done)
            {
                GameObject.Destroy(playing);
                playing = null;
            }
        }
        else if (musicName.Length > 0 && playing == null)
        {
            GameObject.Destroy(canvasObj);
            canvasObj = null;
            playing = Instantiate(songPlayer);
        }
	}

    private void handleKeyboard()
    {
        if (Input.GetKeyDown("1"))
            setSong("Jingle bells");
    }

    public void setSong(string name)
    {
        Debug.Log("Clicked");
        musicName = name;
    }
}
