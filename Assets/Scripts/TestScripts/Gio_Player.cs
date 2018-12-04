using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gio_Player : MonoBehaviour {
    public Animator animator;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("IsSwing", true);
        }
        else
        {
            animator.SetBool("IsSwing", false);
        }
    }
}
