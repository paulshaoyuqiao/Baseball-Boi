using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    private Transform bar;
    public Transform barSprite;
    private Renderer energyRenderer;

    private void Start()
    {
        bar = transform.Find("hBar");
        energyRenderer = barSprite.GetComponent<Renderer>();
        energyRenderer.material.color = Color.green;
    }

    public void setSize(float normalizedSize)
    {
        bar.localScale = new Vector3(normalizedSize, 1f);
    }

    public void ChangeColor(float energy)
    {
        if (energy < 20)
        {
            energyRenderer.material.color = Color.red;
        }
        else if (energy <= 60)
        {
            energyRenderer.material.color = Color.yellow;
        }
        else if (energy <= 100)
        {
            energyRenderer.material.color = Color.green;
        }
    }
}
