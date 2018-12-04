using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionMeterHandler : MonoBehaviour {
    public GameObject meter;
    public GameObject wrapper;
    public float currentRotation;
    public float rotationSpeed;
    public float maxRotation;
    private float dir;
    

	// Use this for initialization
	void Start () {
        this.currentRotation = 0f;
        this.wrapper.transform.rotation.Set(0f, 0f, 0f, 0f);
        this.dir = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            print(this.currentRotation);
            meter.SetActive(false);
            return;
        }
        this.currentRotation += this.rotationSpeed * this.dir;
        wrapper.transform.Rotate(new Vector3(0, 0, this.rotationSpeed * dir));
        if(System.Math.Abs(this.currentRotation) > this.maxRotation)
        {
            this.dir *= -1;
        }
    }
}
