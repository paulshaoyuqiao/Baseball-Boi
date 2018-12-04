using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Animator animator;
    public GameObject HitBox;
    public GioArrow Direction;
    private bool IsInAnimation;
    public TimeManager timeManager;
    public EnergyBar energyBar;
    public Hearts heartBar;


    private float energy;
    private double health;
    private float criticalHealth;
    private float MaxEnergy;
    private bool canHealthDecrease;
    private bool canEnergyDecrease;
    private bool canRegenerate;
    private int count;
    private double maxHealth;
    private double prevHealth;

	// Use this for initialization
	void Start () {
        IsInAnimation = false;
        energy = 100f;
        MaxEnergy = 100f;
        health = 6f;
        criticalHealth = 0f;
        canEnergyDecrease = true;
        canHealthDecrease = true;
        canRegenerate = false;
        maxHealth = 6f;
        prevHealth = 0f;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump"))
        {
            if (energy >= 20 && animator.GetBool("IsSwing") == false)
            {
                StartCoroutine("Swing");
            }
            
        }
        if (energy < MaxEnergy)
        {
            energy += Time.deltaTime * 8;
            energyBar.ChangeColor(energy);
            energyBar.setSize(energy / (100 + 0.0f));

        }
        if (health < 0f) {
            canHealthDecrease = false;
        } else {
            canHealthDecrease = true;
        }
        if (prevHealth < maxHealth)
        {
            if (canRegenerate)
            {
                health += Time.deltaTime * 0.5;
                if (health - prevHealth > 1f) 
                {
                    heartBar.increaseHealth();
                    prevHealth = health;
                }
            }
        } else if (health < criticalHealth) {
            timeManager.slowDownMotion();
        } else if (health < 1f){
            Time.timeScale = 0;
        }
        Debug.Log("health: " + health);
        Debug.Log("canRegenerate: " + canRegenerate);
    }

    public void Reset()
    {
        IsInAnimation = false;
        energy = 100f;
        energyBar.setSize(energy);
        health = 6f;
        criticalHealth = 0f;
        canEnergyDecrease = true;
        canHealthDecrease = true;
        canRegenerate = false;
        
    }

    public double getHealth() {
        return health;
    }

    IEnumerator Swing()
    {
        animator.SetBool("IsSwing", true);
        HitBox.SetActive(true);
        if (canEnergyDecrease)
        {
            energy -= 20;
            energyBar.setSize(energy / (100 + 0.0f));
        }
        timeManager.slowDownMotion();
        Debug.Log(animator.GetCurrentAnimatorStateInfo(0).length);
        yield return new WaitUntil(() => animator.GetBool("IsSwing") == false);//animator.GetCurrentAnimatorStateInfo(0).normalizedTime == 1);
        HitBox.SetActive(false);
    }

    public void AlertObservers(string message)
    {
        if (message.Equals("AttackAnimationEnded")) {
            animator.SetBool("IsSwing", false);
            // Do other things based on an attack ending.
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (IsEnemy(col.gameObject) && CanHealthDecrease())
        {
            heartBar.decreaseHealth();
            col.gameObject.SetActive(false);
            health -= 1;
            StartCoroutine(resetCanRegenerate());
        }
    }

    IEnumerator resetCanRegenerate()
    {
        canRegenerate = false;
        prevHealth = health;
        yield return new WaitForSeconds(1.5f);
        canRegenerate = true;
    }
               
    private bool CanHealthDecrease() 
    {
        return health > 0f;
    }

    private bool IsEnemy(GameObject obj)
    {
        return obj.CompareTag("Enemy");
    }

    public GioArrow getDirectionMeter()
    {
        return Direction;
    }

}
