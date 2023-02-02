using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirstBar : MonoBehaviour
{
    private Image ThirstBarImage;
    public float currentThirst;
    public float MaxThirst = 100f;
    PlayerInventory Player;

    private void Start()
    {
        ThirstBarImage = GetComponent<Image>();
        Player = FindObjectOfType<PlayerInventory>();
    }

    private void Update()
    {
        currentThirst = (float) Player.currentSoif;
        ThirstBarImage.fillAmount = currentThirst / MaxThirst;
    }
}
