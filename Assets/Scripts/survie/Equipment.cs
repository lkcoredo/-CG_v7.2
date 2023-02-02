using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Equipment : MonoBehaviour
{
    [SerializeField]
    private ItemActionSystem itemActionSystem;

    [SerializeField]
    private PlayerInventory playerInventory;

    [Header("Equipment Panel References")]

    [SerializeField]
    private EquipmentLibrary equipmentLibrary;

    [SerializeField]
    private Image headSlotImage;

    [SerializeField]
    private Image chestSlotImage;

    [SerializeField]
    private Image handsSlotImage;

    [SerializeField]
    private Image legsSlotImage;

    [SerializeField]
    private Image feetSlotImage;

    [SerializeField]
    private Image weaponSlotImage;

    // Garde une trace des équipements actuels
    private ItemData equipedHeadItem;
    private ItemData equipedChestItem;
    private ItemData equipedHandsItem;
    private ItemData equipedLegsItem;
    private ItemData equipedFeetItem;
    public ItemData equipedWeaponItem;

    // Garde une trace des types d'armes actuels
    public ItemData equipedBowItem;
    public ItemData equipedShootItem;
    public ItemData equipedSmashItem;
    public ItemData equipedStabItem;
    public ItemData equipedLaunchItem;
    public ItemData equipedNoneItem;

    [SerializeField]
    private Button headSlotDesequipButton;

    [SerializeField]
    private Button chestSlotDesequipButton;

    [SerializeField]
    private Button handsSlotDesequipButton;

    [SerializeField]
    private Button legsSlotDesequipButton;

    [SerializeField]
    private Button feetSlotDesequipButton;

    [SerializeField]
    private Button weaponSlotDesequipButton;

    private void DisablePreviousEquipedEquipment(ItemData itemToDisable)
    {
        if(itemToDisable == null)
        {
            return;
        }

        EquipmentLibraryItem equipmentLibraryItem = equipmentLibrary.content.Where(elem => elem.itemData == itemToDisable).First();
        
        
        if (equipmentLibraryItem != null) 
        {
            for (int i = 0; i < equipmentLibraryItem.elementsToDisable.Length; i++)
            {
                equipmentLibraryItem.elementsToDisable[i].SetActive(true);
            }

            equipmentLibraryItem.itemPrefab.SetActive(false);
        }

        playerInventory.currentDamage -= itemToDisable.damagePoints;
        playerInventory.currentArmor -= itemToDisable.armorPoints;
        InventoryS.instance.AddItem(itemToDisable);
    }

    public void DesequipEquipment(EquipmentTypeS equipmentType)
    {
        // 1. Enlever le visuel de l'équipement sur le personnage + ré-activer les parties visuelles qu'on avait désactiver pour cet objet 
        // 2. Enlever le visuel de l'équipement de la colonne equipement de l'inventaire
        // 3. Renvoyer l'équipement dans l'inventaire du joueur
        // 4. Faire un refreshContent à la fin

        if(InventoryS.instance.IsFull())
        {
            Debug.Log("L'inventaire est plein, impossible de se déséquiper de cet élément");
            return;
        }

        ItemData currentItem = null;

        switch(equipmentType)
        {
            case EquipmentTypeS.Head:
                currentItem = equipedHeadItem;
                equipedHeadItem = null;
                headSlotImage.sprite = InventoryS.instance.emptySlotVisual;
                break;
            
            case EquipmentTypeS.Chest:
                currentItem = equipedChestItem;
                equipedChestItem = null;
                chestSlotImage.sprite = InventoryS.instance.emptySlotVisual;
                break;

            case EquipmentTypeS.Hands:
                currentItem = equipedHandsItem;
                equipedHandsItem = null;
                handsSlotImage.sprite = InventoryS.instance.emptySlotVisual;
                break;

            case EquipmentTypeS.Legs:
                currentItem = equipedLegsItem;
                equipedLegsItem = null;
                legsSlotImage.sprite = InventoryS.instance.emptySlotVisual;
                break;

            case EquipmentTypeS.Feet:
                currentItem = equipedFeetItem;
                equipedFeetItem = null;
                feetSlotImage.sprite = InventoryS.instance.emptySlotVisual;
                break;

            case EquipmentTypeS.Weapon:
                currentItem = equipedWeaponItem;
                equipedFeetItem = null;
                weaponSlotImage.sprite = InventoryS.instance.emptySlotVisual;
                break;
        }

        EmptyWeaponTypeVariable();     
        EquipmentLibraryItem equipmentLibraryItem = equipmentLibrary.content.Where(elem => elem.itemData == currentItem).First();
        
        if (equipmentLibraryItem != null) 
        {
            for (int i = 0; i < equipmentLibraryItem.elementsToDisable.Length; i++)
            {
                equipmentLibraryItem.elementsToDisable[i].SetActive(true);
            }

            equipmentLibraryItem.itemPrefab.SetActive(false);
        }

        playerInventory.currentDamage -= currentItem.damagePoints;
        playerInventory.currentArmor -= currentItem.armorPoints;
        InventoryS.instance.AddItem(currentItem);
        InventoryS.instance.RefreshContent();
    }

    public void UpdateEquipmentsDesequipButtons()
    {
        headSlotDesequipButton.onClick.RemoveAllListeners();
        headSlotDesequipButton.onClick.AddListener(delegate { DesequipEquipment(EquipmentTypeS.Head); });
        headSlotDesequipButton.gameObject.SetActive(equipedHeadItem);

        chestSlotDesequipButton.onClick.RemoveAllListeners();
        chestSlotDesequipButton.onClick.AddListener(delegate { DesequipEquipment(EquipmentTypeS.Chest); });
        chestSlotDesequipButton.gameObject.SetActive(equipedChestItem);

        handsSlotDesequipButton.onClick.RemoveAllListeners();
        handsSlotDesequipButton.onClick.AddListener(delegate { DesequipEquipment(EquipmentTypeS.Hands); });
        handsSlotDesequipButton.gameObject.SetActive(equipedHandsItem);

        legsSlotDesequipButton.onClick.RemoveAllListeners();
        legsSlotDesequipButton.onClick.AddListener(delegate { DesequipEquipment(EquipmentTypeS.Legs); });
        legsSlotDesequipButton.gameObject.SetActive(equipedLegsItem);

        feetSlotDesequipButton.onClick.RemoveAllListeners();
        feetSlotDesequipButton.onClick.AddListener(delegate { DesequipEquipment(EquipmentTypeS.Feet); });
        feetSlotDesequipButton.gameObject.SetActive(equipedFeetItem);

        weaponSlotDesequipButton.onClick.RemoveAllListeners();
        weaponSlotDesequipButton.onClick.AddListener(delegate { DesequipEquipment(EquipmentTypeS.Weapon); });
        weaponSlotDesequipButton.gameObject.SetActive(equipedWeaponItem);

    }

    public void EquipAction()
    {
        EmptyWeaponTypeVariable();
        print("Equip Item : " + itemActionSystem.itemCurrentlySelected.name);
        EquipmentLibraryItem equipmentLibraryItem = equipmentLibrary.content.Where(elem => elem.itemData == itemActionSystem.itemCurrentlySelected).First();
        
        if(equipmentLibraryItem != null)
        {
            switch(itemActionSystem.itemCurrentlySelected.equipmentType)
            {
                case EquipmentTypeS.Head:
                    DisablePreviousEquipedEquipment(equipedHeadItem);
                    headSlotImage.sprite = itemActionSystem.itemCurrentlySelected.visual;
                    equipedHeadItem = itemActionSystem.itemCurrentlySelected;
                    break;

                case EquipmentTypeS.Chest:
                    DisablePreviousEquipedEquipment(equipedChestItem);
                    chestSlotImage.sprite = itemActionSystem.itemCurrentlySelected.visual;
                    equipedChestItem = itemActionSystem.itemCurrentlySelected;
                    break;

                case EquipmentTypeS.Hands:
                    DisablePreviousEquipedEquipment(equipedHandsItem);   
                    handsSlotImage.sprite = itemActionSystem.itemCurrentlySelected.visual;
                    equipedHandsItem = itemActionSystem.itemCurrentlySelected;
                    break;

                case EquipmentTypeS.Legs:
                    DisablePreviousEquipedEquipment(equipedLegsItem);
                    legsSlotImage.sprite = itemActionSystem.itemCurrentlySelected.visual;
                    equipedLegsItem = itemActionSystem.itemCurrentlySelected;
                    break;

                case EquipmentTypeS.Feet:
                    DisablePreviousEquipedEquipment(equipedFeetItem);
                    feetSlotImage.sprite = itemActionSystem.itemCurrentlySelected.visual;
                    equipedFeetItem = itemActionSystem.itemCurrentlySelected;
                    break;

                case EquipmentTypeS.Weapon:
                    DisablePreviousEquipedEquipment(equipedWeaponItem);
                    weaponSlotImage.sprite = itemActionSystem.itemCurrentlySelected.visual;
                    equipedWeaponItem = itemActionSystem.itemCurrentlySelected;
                    break;
            }

            switch(itemActionSystem.itemCurrentlySelected.weaponType)
            {
                    case WeaponTypeS.Bow:
                        equipedBowItem = itemActionSystem.itemCurrentlySelected;
                        break;
                    
                    case WeaponTypeS.Shoot:
                        equipedShootItem = itemActionSystem.itemCurrentlySelected;
                        break;

                    case WeaponTypeS.Smash:
                        equipedSmashItem = itemActionSystem.itemCurrentlySelected;
                        break;

                    case WeaponTypeS.Stab:
                        equipedStabItem = itemActionSystem.itemCurrentlySelected;
                        break;

                    case WeaponTypeS.Launch:
                        equipedLaunchItem = itemActionSystem.itemCurrentlySelected;
                        break;

                    case WeaponTypeS.None:
                        equipedNoneItem = itemActionSystem.itemCurrentlySelected;
                        break;
            }    

            for (int i = 0; i < equipmentLibraryItem.elementsToDisable.Length; i++) 
            {
                equipmentLibraryItem.elementsToDisable[i].SetActive(false);
            }
            equipmentLibraryItem.itemPrefab.SetActive(true);
            playerInventory.currentDamage += itemActionSystem.itemCurrentlySelected.damagePoints;
            playerInventory.currentArmor += itemActionSystem.itemCurrentlySelected.armorPoints;
            InventoryS.instance.RemoveItem(itemActionSystem.itemCurrentlySelected);
        }
        else
        {
            Debug.LogError("Equipment : " + itemActionSystem.itemCurrentlySelected.name + " non existant dans la librairie des équipements");
        }
        itemActionSystem.CloseActionPanel();
    }

    private void EmptyWeaponTypeVariable()
    {
        equipedBowItem = null;
        equipedShootItem = null;
        equipedSmashItem = null;
        equipedStabItem = null;
        equipedLaunchItem = null;
        equipedNoneItem = null; 
    }


}
