using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    private Image EnergyBarImage;
    public float currentEnergy;
    public float MaxEnergy = 100f;
    PlayerInventory Player;

    private void Start()
    {
        EnergyBarImage = GetComponent<Image>();
        Player = FindObjectOfType<PlayerInventory>();
    }

    private void Update()
    {
        currentEnergy = (float)Player.currentEnergie;
        EnergyBarImage.fillAmount = currentEnergy / MaxEnergy;
    }
}
