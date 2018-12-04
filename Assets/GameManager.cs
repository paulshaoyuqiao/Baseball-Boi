using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject bat1;
    public GameObject bat2;
    public GameObject tree1;
    public GameObject tree2;
    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            bat1.SetActive(true);
            bat2.SetActive(true);
            tree1.SetActive(true);
            tree2.SetActive(true);
            bat1.GetComponent<EvilBat>().Reset();
            bat2.GetComponent<EvilBat>().Reset();
            tree1.GetComponent<Dummy>().Reset();
            tree2.GetComponent<Dummy>().Reset();
            player.GetComponent<Player>().Reset();
        }
    }
}
