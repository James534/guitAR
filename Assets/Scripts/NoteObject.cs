using UnityEngine;
using System.Collections;

public class NoteObject : MonoBehaviour
{

    float speed = 0.1f;
    public bool done = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x -= speed;
        pos.y += speed;
        if (pos.x < 8)
        {
            done = true;
            return;
        }

        transform.position = pos;
    }
}