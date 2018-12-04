using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingGround : MonoBehaviour {


    private Rigidbody2D rb2d;
    public float scrollSpeed = -5f;
    public TimeManager timeManager;
    public Player player;
    /** Need to add game controller */

    // Use this for initialization
    void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(scrollSpeed, 0);
        if (Input.GetButtonDown("Jump"))
        {
            timeManager.slowDownMotion();
        }

    }
	
	// Update is called once per frame
	void Update () {
        if (player.getHealth() < 1f) {
            Time.timeScale = 0;
        }
	}
}
