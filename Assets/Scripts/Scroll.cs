using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {

    //set background/ground scroll speed
    [Range(1f, 20f)]
    public float scrollSpeed = 1f;

    //scroll background/ground by repating it
    public float scrollOffset;

    //starting position of background/ground scroll
    Vector2 startPosition;

    //new position of background/ground 
    float newPosition;

	// Use this for initialization
	void Start () {
        //get background/ground start position
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //calculate bakground/ground repettitions depending on background scroll speed and offset 
        newPosition = Mathf.Repeat(Time.time * -scrollSpeed, scrollOffset);

        //set new position
        transform.position = startPosition + Vector2.right * newPosition;
	}
}
