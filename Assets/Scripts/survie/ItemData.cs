using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items/New item")]
public class ItemData : ScriptableObject
{
    [Header("Data")]
    public string name;
    public string description;
    public Sprite visual;
    public GameObject prefab;
    public bool stackable;
    public int maxStack;

    [Header("Effects")]
    public float healthEffect;
    public float hungerEffect;
    public float thirstEffect;
    public float energyEffect;
    public float temperatureEffect;

    [Header("Armor Stats")]
    public float armorPoints;

    [Header("Weapon Stats")]
    public float damagePoints;

    [Header("Types")]
    public ItemTypeS itemType;
    public EquipmentTypeS equipmentType;
    public WeaponTypeS weaponType;
}

public enum ItemTypeS
{
    Ressource,
    Equipement,
    Consumable
}

public enum EquipmentTypeS
{
    Head,
    Chest,
    Hands,
    Legs,
    Feet,
    Weapon
}

public enum WeaponTypeS
{
    Bow,
    Shoot,
    Smash,
    Stab,
    Launch,
    None
}

