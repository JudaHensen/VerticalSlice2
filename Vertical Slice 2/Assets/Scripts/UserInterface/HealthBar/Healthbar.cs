using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {

    private Image image;

    [SerializeField]
    private float percentage = 100;
    private float currentPercentage = 100;

    [SerializeField]
    private float fallOffSpeed; // bar falloff speed

    private bool fallOff = false;


    void Awake()
    {
        image = GetComponent<Image>();
    }

    // Update healthbar smoothing
    void Update()
    {
        percentage = Player.health;

        if (currentPercentage < percentage) currentPercentage = percentage;
        if (currentPercentage > percentage && !fallOff) EnableFallOff();

        FalloffUpdater();

        UpdateBar();
    }

    // Update healtbar falloff
    private void FalloffUpdater()
    {
        if (fallOff)
        {
            currentPercentage -= fallOffSpeed;
            if (currentPercentage <= percentage) fallOff = false;
        }
    }

    // Set player health
    public void SetCurrent(float value)
    {
        percentage = value;
    }

    // Enable healthbar smoothing
    private void EnableFallOff()
    {
        fallOff = true;
    }

    // Update healthbar fill
    private void UpdateBar()
    {
        image.fillAmount = currentPercentage / 100;
    }
}
