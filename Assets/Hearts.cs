using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour {
    public Animator animator;
    public AudioClip hurtSound;
    private AudioSource source;
    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void decreaseHealth()
    {
        animator.SetBool("decrease", true);
        source.PlayOneShot(hurtSound, 1f);
    }
    public void increaseHealth()
    {
        animator.SetBool("increase", true);
    }
}
