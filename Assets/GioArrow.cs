using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GioArrow : MonoBehaviour
{
    public GameObject meter;
    public GameObject wrapper;
    public float currentRotation;
    public float rotationSpeed;
    public float maxRotation;
    public bool isChoosing;
    private float dir;
    public float lastval;
    public TimeManager timeManager;


    // Use this for initialization
    void Start()
    {
        this.gameObject.SetActive(false);
        isChoosing = false;
        this.currentRotation = 0f;
        this.wrapper.transform.rotation.Set(0f, 0f, 0f, 0f);
        this.dir = 1f;
        lastval = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isChoosing)
        {
            //Debug.Log("INARROW");
            this.currentRotation += this.rotationSpeed * this.dir;
            wrapper.transform.Rotate(new Vector3(0, 0, this.rotationSpeed * dir));
            if (System.Math.Abs(this.currentRotation) > this.maxRotation)
            {
                this.dir *= -1;
            }
        }

    }
    public void Activate()
    {
        Debug.Log("ACTIVATE");
        this.gameObject.SetActive(true);
        timeManager.fullslowDownMotion();
        isChoosing = true;
    }

    public void Deactivate()
    {
        lastval = this.currentRotation;
        this.gameObject.SetActive(false);
       // this.currentRotation = 0f;
        timeManager.resume();
        isChoosing = false;
        //this.wrapper.transform.rotation.Set(0f, 0f, 0f, 0f);
        //this.dir = 1f;
    }
    public float getRotation()
    {
        return lastval;
    }
    public bool GetChoosing()
    {
        return isChoosing;
    }
}