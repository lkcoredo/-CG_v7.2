using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemActionSystem : MonoBehaviour
{
    [Header("Other Scripts References")]

    [SerializeField]
    private Equipment equipment;

    [SerializeField]
    private PlayerInventory playerInventory;

    [Header("Action Panel References")]

    public GameObject actionPanel;

    [SerializeField]
    private Transform dropPoint;

    [SerializeField]
    private GameObject useItemButton;

    [SerializeField]
    private GameObject equipItemButton;

    [SerializeField]
    private GameObject dropItemButton;

    [SerializeField]
    private GameObject destroyItemButton;

    [HideInInspector]
    public ItemData itemCurrentlySelected;

    public void OpenActionPanel(ItemData itemS, Vector3 slotPosition)
    {
        itemCurrentlySelected = itemS;

        if(itemS == null)
        {
            actionPanel.SetActive(false);
            return;
        }

        switch (itemS.itemType)
        {
            
            case ItemTypeS.Ressource:
                useItemButton.SetActive(false);
                equipItemButton.SetActive(false);
                break;
            case ItemTypeS.Equipement:
                useItemButton.SetActive(false);
                equipItemButton.SetActive(true);
                break;
            case ItemTypeS.Consumable:
                useItemButton.SetActive(true);
                equipItemButton.SetActive(false);
                break;
        }

        actionPanel.transform.position = slotPosition;
        actionPanel.SetActive(true);
    }

    public void CloseActionPanel()
    {
        actionPanel.SetActive(false);
        itemCurrentlySelected = null;
    }

    public void UseActionButton()
    {
        print("Use Item : " + itemCurrentlySelected.name);
        playerInventory.ConsumeItem(
            itemCurrentlySelected.healthEffect,
            itemCurrentlySelected.hungerEffect,
            itemCurrentlySelected.thirstEffect,
            itemCurrentlySelected.energyEffect,
            itemCurrentlySelected.temperatureEffect);
        InventoryS.instance.RemoveItem(itemCurrentlySelected);
        CloseActionPanel();
    }

    public void EquipActionButton()
    {
        equipment.EquipAction();
    }

    public void DropActionButton()
    {
        GameObject instantiatedItem = Instantiate(itemCurrentlySelected.prefab);
        instantiatedItem.transform.position = dropPoint.position;
        InventoryS.instance.RemoveItem(itemCurrentlySelected);
        InventoryS.instance.RefreshContent();
        CloseActionPanel();
    }

    public void DestroyActionButton()
    {
        InventoryS.instance.RemoveItem(itemCurrentlySelected);
        InventoryS.instance.RefreshContent();
        CloseActionPanel();
    }
}
