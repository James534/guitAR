using UnityEngine;
using System.Collections;

public class NoteObject : MonoBehaviour {

    float speed = 0.05f;
    public bool done = false;
    public bool hit = false;
    public Note note;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.x -= speed;
        if (pos.x < 8)
        {
            done = true;
            return;
        }

        transform.position = pos;
	}
}
