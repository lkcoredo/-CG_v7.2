using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    private Image HungerBarImage;
    public float currentHunger;
    public float MaxHunger = 100f;
    PlayerInventory Player;

    private void Start()
    {
        HungerBarImage = GetComponent<Image>();
        Player = FindObjectOfType<PlayerInventory>();
    }

    private void Update()
    {
        currentHunger = (float) Player.currentFaim;
        HungerBarImage.fillAmount = currentHunger / MaxHunger;
    }
}
