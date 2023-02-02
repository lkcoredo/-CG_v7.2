using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureBar : MonoBehaviour
{
    private Image TBarImage;
    public float currentT;
    public float MaxT = 100f;
    PlayerInventory Player;

    // Start is called before the first frame update
    void Start()
    {
        TBarImage = GetComponent<Image>();
        Player = FindObjectOfType<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        currentT = (float)Player.currentTemperature;
        TBarImage.fillAmount = currentT / MaxT;
    }
}
