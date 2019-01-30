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


    void Update()
    {
        if (currentPercentage < percentage) currentPercentage = percentage;
        if (currentPercentage > percentage && !fallOff) EnableFallOff();

        FalloffUpdater();

        UpdateBar();
    }

    private void FalloffUpdater()
    {
        if (fallOff)
        {
            currentPercentage -= fallOffSpeed;
            if (currentPercentage <= percentage) fallOff = false;
        }
    }

    public void SetCurrent(float value)
    {
        percentage = value;
    }

    private void EnableFallOff()
    {
        fallOff = true;
    }

    private void UpdateBar()
    {
        image.fillAmount = currentPercentage / 100;
    }
}
