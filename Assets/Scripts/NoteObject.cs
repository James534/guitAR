using UnityEngine;
using System.Collections;

public class NoteObject : MonoBehaviour {

    float speed = 0.05f;
    public bool done = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.y -= speed;
        if (pos.y < 1)
        {
            done = true;
            return;
        }

        transform.position = pos;
	}
}
