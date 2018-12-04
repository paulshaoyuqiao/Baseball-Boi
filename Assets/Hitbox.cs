using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour {
    public AudioClip[] HitSounds;
    private AudioSource source;
    private float TimeLimit;
    private float CurrentTime;
    public Player player;
    [HideInInspector]
    public GioArrow directionMeter;
    private bool isChoosing;
    private GameObject currentEnemy;
    private float cooldown;
    // Use this for initialization
    void Start () {
        TimeLimit = 3f;
        CurrentTime = 0f;
        isChoosing = false;
        source = GetComponent<AudioSource>();
        directionMeter = player.getDirectionMeter();
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("HELLO");
        if (cooldown > 0) {
            cooldown -= Time.deltaTime;
        }
        if (isChoosing == false)
        {
            CurrentTime += Time.unscaledDeltaTime;
        }
        if (isChoosing = true && (Input.GetButtonDown("Jump") || TimeLimitReached())) {
            directionMeter.Deactivate();
            Rigidbody2D rb = currentEnemy.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(10, directionMeter.getRotation()*0.3f);
            CurrentTime = 0f;
            int i = Random.Range(0, HitSounds.Length);
            AudioClip HitSound = HitSounds[i];
            source.PlayOneShot(HitSound, 1f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (cooldown > 0)
        {
            Debug.Log(Time.deltaTime);
            Debug.Log(cooldown);
            return;
        }
        directionMeter.Activate();
        currentEnemy = collision.gameObject;
        isChoosing = true;
        cooldown = 0.1f;
        
    }
    private bool TimeLimitReached()
    {
        return TimeLimit <= CurrentTime;
    }
}
