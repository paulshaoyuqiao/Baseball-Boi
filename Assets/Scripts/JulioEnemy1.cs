using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JulioEnemy1 : MonoBehaviour {

    Rigidbody2D rb;
    Transform tran;
    public TimeManager timeManager;
    // Use this for initialization
    void Start () {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-9, -1);
        tran = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Horizontal")){
            tran.position = new Vector3(3.5f, 4.15f, 0f);
            rb.velocity = new Vector2(-9, -1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.gameObject.tag == ("Hitbox")) {
            rb.velocity = new Vector2(20, 0);
        }
    }
}
