using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class InventoryS : MonoBehaviour
{
    [Header("Other Scripts References")]

    [SerializeField]
    private Equipment equipment;

    [SerializeField]
    private ItemActionSystem itemActionSystem;

    [Header("Inventory Panel References")]

    [SerializeField]
    public List<ItemData> content = new List<ItemData>();

    [SerializeField]
    private GameObject inventoryPanel;

    [SerializeField]
    private Transform inventorySlotsParent;

    const int INVENTORY_SIZE = 20;

    public Sprite emptySlotVisual;

    public static InventoryS instance;

    private bool IsOpen = false;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        CloseInventory();
        RefreshContent();
    }

    public void AddItem(ItemData itemS)
    {
        content.Add(itemS);
        RefreshContent();
    }

    public void RemoveItem(ItemData itemS)
    {
        content.Remove(itemS);
        RefreshContent();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) 
        {
            if(IsOpen)
            {
                CloseInventory();
            }
            else
            {
                OpenInventory();
            }
            
        }
        RefreshContent();
    }

    private void OpenInventory() {
        inventoryPanel.SetActive(true);
        IsOpen = true;
    }

    public void CloseInventory()
    {
        inventoryPanel.SetActive(false);
        itemActionSystem.actionPanel.SetActive(false);
        TooltipSystemS.instance.Hide();
        IsOpen = false;
    }

    public void RefreshContent() 
    {
        // On vide tous les slots / visuels
        for (int i = 0; i < inventorySlotsParent.childCount; i++)
        {
            Slot currentSlot = inventorySlotsParent.GetChild(i).GetComponent<Slot>();
            currentSlot.itemS = null;
            currentSlot.itemVisual.sprite = emptySlotVisual;
        }

        // On peuple le visuel des slots selon le contenu réel de l'inventaire
        for (int i = 0; i < content.Count; i++)
        {
            Slot currentSlot = inventorySlotsParent.GetChild(i).GetComponent<Slot>();
            currentSlot.itemS = content[i];
            currentSlot.itemVisual.sprite = content[i].visual;
        }

        equipment.UpdateEquipmentsDesequipButtons();
    }

    public bool IsFull()
    {
        return INVENTORY_SIZE == content.Count;
    }
}
