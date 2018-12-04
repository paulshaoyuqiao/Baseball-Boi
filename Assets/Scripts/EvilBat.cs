using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilBat : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform target;
    Transform tran;
    Vector3 originalPos;
    float originalWeight;
    float timepassed;
    float normalizer;
    // Use this for initialization
    void Start()
    {
        normalizer = 1f;
        rb = this.GetComponent<Rigidbody2D>();
        tran = this.GetComponent<Transform>();
        originalPos = tran.position;
        timepassed = 0f;
        originalWeight = 1f;
    }

    // Update is called once per frame
    void Update()
    {
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
            rb.gravityScale = 0;
            rb.velocity = new Vector2(0, 0);
        }
        */
        transform.position = Vector3.MoveTowards(transform.position, target.position, 0.05f * Time.timeScale * normalizer);
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
        rb.gravityScale = 0;
        rb.velocity = new Vector2(0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        normalizer = 0f;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        normalizer = 1f;
    }
}
