using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour {
    Rigidbody2D rb;
    Transform tran;
    Vector3 originalPos;
    public AudioClip hitNoise;
    float originalWeight;
    float timepassed;
    // Use this for initialization
    void Start() {
        rb = this.GetComponent<Rigidbody2D>();
        tran = this.GetComponent<Transform>();
        originalPos = tran.position;
        timepassed = 0f;
        originalWeight = 1f;
    }

    // Update is called once per frame
    void Update() {
        /*
        timepassed += Time.deltaTime;
        if (Input.GetButtonDown("Horizontal") || timepassed >= 8)
        {
            float x = Random.Range(originalPos.x - 30, originalPos.x + 30);
            float y = Random.Range(originalPos.y - 30, originalPos.y + 30);
            float z = originalPos.z;
            Vector3 pos = new Vector3(x, y, z);
            transform.position = pos;
            timepassed = 0;
            tran.position = originalPos;
            rb.gravityScale = 1;
            rb.velocity = new Vector2(0, 0);
        }
        */
        transform.Translate(-1f * Time.deltaTime, 0, 0);
    }

    public void Reset()
    {
        float x = Random.Range(originalPos.x - 30, originalPos.x + 30);
        float y = Random.Range(originalPos.y - 30, originalPos.y + 30);
        float z = originalPos.z;
        Vector3 pos = new Vector3(x, y, z);
        transform.position = pos;
        timepassed = 0;
        tran.position = originalPos;
        rb.gravityScale = 3;
        rb.velocity = new Vector2(0, 0);
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == ("Hitbox"))
        {
            rb.velocity = new Vector2(20, 8);
            rb.mass = 15;
        }
    }*/
}
