using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeat : MonoBehaviour {

    private BoxCollider2D groundCollider;
    private float groundHorizontalLength;
    public TimeManager timeManager;
    public Player player;

    // Use this for initialization
    void Start () {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x;

	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < -groundHorizontalLength){
            Reposition();
        }
        if (player.getHealth() < 1f)
        {
            Time.timeScale = 0;
        }
    }

    private void Reposition(){
        Vector2 groundOffset = new Vector2(groundHorizontalLength * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffset;
        if (Input.GetButtonDown("Jump")) {
            timeManager.slowDownMotion();
        }
    }
}
