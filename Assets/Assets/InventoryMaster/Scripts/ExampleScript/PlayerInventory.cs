using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerInventory : MonoBehaviour
{
    public GameObject inventory;
    public GameObject characterSystem;
    public GameObject craftSystem;
    /* public GameObject shop;*/
    public Inventory craftSystemInventory;
    private CraftSystem cS;
    public Inventory mainInventory;
    public Inventory characterSystemInventory;
    private Tooltip toolTip;
/*    public ConsumeItem consumer;*/

    //InputDialogue
    bool inputDialogue;

    private InputManager inputManagerDatabase;

    public Image hpImage;
    public Image manaImage;

    float maxHealth = 100;
    float maxMana = 100;
    float maxDamage = 0;
    float maxArmor = 0;
    public double maxFaim = 100;
    public double maxSoif = 100;
    float maxEnergy = 100;
    float maxTemperature = 100;

    public float currentHealth = 60;
    public float currentMana = 100;
    public float currentDamage = 0;
    public float currentArmor = 0;

    public int goldCoins;
    public Text goldText;

    public float currentEndurance = 2;
    public float currentForce = 2;
    public float currentSouplesse = 2;
    public float currentAgilite = 2;
    public float currentForceMentale = 2;
    public float currentApnee = 2;
    public float currentAge = 30;
    public float currentPoids = 70;

    public double currentFaim = 100;
    public double currentSoif = 100;
    public double currentEnergie = 100;
    public float currentSouffle = 100;
    public double currentTemperature = 100;

    public float currentIvresse = 0;
    public float currentMaladie = 0;

    public float currentBruit = 100;
    public float currentVisible = 100;
    public float currentEquivoque = 100;

    public float currentMoral = 100;
    public float currentDesir = 0;
    public float currentPeur = 0;

    public string currentPrenom;
    public string currentNom;

    //emotions


    public float percentageHP = 100;
    public float percentageMana = 100;


    int normalSize = 3;

    public CharacterMotor charactermotor;
    public Animation playerAnimations;

    [SerializeField]
    private float hungerDecreaseRate = 0.05f;

    [SerializeField]
    private float thirstDecreaseRate = 0.1f;

    [SerializeField]
    private float energyDecreaseRate = 0.1f;

    [SerializeField]
    private float temperatureDecreaseRate = 0.1f;

    public void TakeDamage(float damage)
    {
        currentHealth -= damage - currentArmor;
    }

    public void ConsumeItem(float health, float hunger, float thirst, float energy, float temperature)
    {
        currentHealth += health;
        if(currentHealth > maxHealth){
            currentHealth = maxHealth;
        }
        
        currentFaim += hunger;
        if(currentFaim > maxFaim){
            currentFaim = maxFaim;
        }

        currentSoif += thirst;
        if(currentSoif > maxSoif){
            currentSoif = maxSoif;
        }

        currentEnergie += energy;
        if(currentEnergie > maxEnergy){
            currentEnergie = maxEnergy;
        }

        currentTemperature += temperature;
        if(currentTemperature > maxTemperature){
            currentTemperature = maxTemperature;
        }
    }

    /*
    public void OnEnable()
    {
        Inventory.ItemEquip += OnBackpack;
        Inventory.UnEquipItem += UnEquipBackpack;

        Inventory.ItemEquip += OnGearItem;
        Inventory.ItemConsumed += OnConsumeItem;
        Inventory.UnEquipItem += OnUnEquipItem;

        Inventory.ItemEquip += EquipWeapon;
        Inventory.UnEquipItem += UnEquipWeapon;
    }

    public void OnDisable()
    {
        Inventory.ItemEquip -= OnBackpack;
        Inventory.UnEquipItem -= UnEquipBackpack;

        Inventory.ItemEquip -= OnGearItem;
        Inventory.ItemConsumed -= OnConsumeItem;
        Inventory.UnEquipItem -= OnUnEquipItem;

        Inventory.UnEquipItem -= UnEquipWeapon;
        Inventory.ItemEquip -= EquipWeapon;
    }

    void EquipWeapon(Item item)
    {
        if (item.itemType == ItemType.Weapon)
        {
            //add the weapon if you unequip the weapon
        }
    }

    void UnEquipWeapon(Item item)
    {
        if (item.itemType == ItemType.Weapon)
        {
            //delete the weapon if you unequip the weapon
        }
    }

    void OnBackpack(Item item)
    {
        if (item.itemType == ItemType.Backpack)
        {
            for (int i = 0; i < item.itemAttributes.Count; i++)
            {
                if (mainInventory == null)
                    mainInventory = inventory.GetComponent<Inventory>();
                mainInventory.sortItems();
                if (item.itemAttributes[i].attributeName == "Slots")
                    changeInventorySize(item.itemAttributes[i].attributeValue);
            }
        }
    }

    void UnEquipBackpack(Item item)
    {
        if (item.itemType == ItemType.Backpack)
            changeInventorySize(normalSize);
    }

    

    void changeInventorySize(int size)
    {
        dropTheRestItems(size);

        if (mainInventory == null)
            mainInventory = inventory.GetComponent<Inventory>();
        if (size == 3)
        {
            mainInventory.width = 3;
            mainInventory.height = 1;
            mainInventory.updateSlotAmount();
            mainInventory.adjustInventorySize();
        }
        if (size == 6)
        {
            mainInventory.width = 3;
            mainInventory.height = 2;
            mainInventory.updateSlotAmount();
            mainInventory.adjustInventorySize();
        }
        else if (size == 12)
        {
            mainInventory.width = 4;
            mainInventory.height = 3;
            mainInventory.updateSlotAmount();
            mainInventory.adjustInventorySize();
        }
        else if (size == 16)
        {
            mainInventory.width = 4;
            mainInventory.height = 4;
            mainInventory.updateSlotAmount();
            mainInventory.adjustInventorySize();
        }
        else if (size == 24)
        {
            mainInventory.width = 6;
            mainInventory.height = 4;
            mainInventory.updateSlotAmount();
            mainInventory.adjustInventorySize();
        }
    }

    void dropTheRestItems(int size)
    {
        if (size < mainInventory.ItemsInInventory.Count)
        {
            for (int i = size; i < mainInventory.ItemsInInventory.Count; i++)
            {
                GameObject dropItem = (GameObject)Instantiate(mainInventory.ItemsInInventory[i].itemModel);
                dropItem.AddComponent<PickUpItem>();
                dropItem.GetComponent<PickUpItem>().item = mainInventory.ItemsInInventory[i];
                dropItem.transform.localPosition = GameObject.FindGameObjectWithTag("Player").transform.localPosition;
            }
        }
    }

    */

    void Start()
    {
        currentPrenom = PlayerPrefs.GetString("Prenom");
        currentNom = PlayerPrefs.GetString("Nom");
        currentAge = float.Parse(PlayerPrefs.GetString("Age"));
        currentPoids = float.Parse(PlayerPrefs.GetString("Poids"));
        currentEndurance = float.Parse(PlayerPrefs.GetString("Endurance"));
        currentForce = float.Parse(PlayerPrefs.GetString("Force"));
        currentSouplesse = float.Parse(PlayerPrefs.GetString("Souplesse"));
        currentAgilite = float.Parse(PlayerPrefs.GetString("Agilite"));
        currentForceMentale = float.Parse(PlayerPrefs.GetString("ForceMentale"));
        currentApnee = float.Parse(PlayerPrefs.GetString("Apnee"));
        goldText = GameObject.Find("playerGold").GetComponent<Text>();


        inputDialogue = false;
        hpImage = GameObject.Find("currentHP").GetComponent<Image>();
        manaImage = GameObject.Find("currentMana").GetComponent<Image>();

        charactermotor = gameObject.GetComponent<CharacterMotor>();
        playerAnimations = gameObject.GetComponent<Animation>();

        if (inputManagerDatabase == null)
            inputManagerDatabase = (InputManager)Resources.Load("InputManager");

        if (craftSystem != null)
            cS = craftSystem.GetComponent<CraftSystem>();

        if (GameObject.FindGameObjectWithTag("Tooltip") != null)
            toolTip = GameObject.FindGameObjectWithTag("Tooltip").GetComponent<Tooltip>();
        if (inventory != null)
            mainInventory = inventory.GetComponent<Inventory>();
        if (characterSystem != null)
            characterSystemInventory = characterSystem.GetComponent<Inventory>();
        if (craftSystem != null)
            craftSystemInventory = craftSystem.GetComponent<Inventory>();

        currentHealth = currentHealth * currentEndurance;
        currentMana = currentMana * currentForceMentale;
        currentDamage = currentDamage * currentForce;

        //InvokeRepeating("UpdateHunger", 1f, 1f);  //1s delay, repeat every 1s
        //InvokeRepeating("UpdateThirst", 1f, 1f);  //1s delay, repeat every 1s
        //InvokeRepeating("UpdateFatigue", 1f, 1f);  //1s delay, repeat every 1s
        //InvokeRepeating("UpdateFroid", 1f, 1f);  //1s delay, repeat every 1s
    }

    void UpdateHunger()
    {

        currentFaim -= hungerDecreaseRate * Time.deltaTime;

        if (currentFaim < 0)
        {
            Dead();
        }
    }

    void UpdateThirst()
    {
        currentSoif -= thirstDecreaseRate * Time.deltaTime;
        if (currentSoif < 0)
        {
            Dead();
        }
    }

    void UpdateFatigue()
    {
        currentEnergie -= energyDecreaseRate * Time.deltaTime;
        if (currentEnergie < 0)
        {
            Dead();
        }
    }

    void UpdateFroid()
    {
        currentTemperature -= temperatureDecreaseRate * Time.deltaTime;
        if (currentTemperature < 0)
        {
            Dead();
        }
    }

    void SellItem(Item item)
    {
        /*consumer*/
        Inventory inventory = transform.parent.parent.parent.GetComponent<Inventory>();
        inventory.ConsumeItem(item);
    }

    public void ApplyDamage(float theDamage)
    {
        if(!charactermotor.isDead) { 
            currentHealth = currentHealth - (theDamage - ((currentArmor * theDamage) / 100));
        
            if(currentHealth <= 0)
            {
                Dead();
            }
        }

    }

    public void Dead()
    {
        charactermotor.isDead = true;
        playerAnimations.Play("die");
    }

    public void OnConsumeItem(Item item)
    {
        for (int i = 0; i < item.itemAttributes.Count; i++)
        {
            if (item.itemAttributes[i].attributeName == "Health")
            {
                if ((currentHealth + item.itemAttributes[i].attributeValue) > maxHealth)
                    currentHealth = maxHealth;
                else
                    currentHealth += item.itemAttributes[i].attributeValue;
            }
            if (item.itemAttributes[i].attributeName == "Mana")
            {
                if ((currentMana + item.itemAttributes[i].attributeValue) > maxMana)
                    currentMana = maxMana;
                else
                    currentMana += item.itemAttributes[i].attributeValue;
            }
            if (item.itemAttributes[i].attributeName == "Armor")
            {
                if ((currentArmor + item.itemAttributes[i].attributeValue) > maxArmor)
                    currentArmor = maxArmor;
                else
                    currentArmor += item.itemAttributes[i].attributeValue;
            }
            if (item.itemAttributes[i].attributeName == "Damage")
            {
                if ((currentDamage + item.itemAttributes[i].attributeValue) > maxDamage)
                    currentDamage = maxDamage;
                else
                    currentDamage += item.itemAttributes[i].attributeValue;
            }
            if (item.itemAttributes[i].attributeName == "Faim")
            {
                if ((currentFaim + item.itemAttributes[i].attributeValue) > maxFaim)
                    currentFaim = maxFaim;
                else
                    currentFaim += item.itemAttributes[i].attributeValue;
            }
            if (item.itemAttributes[i].attributeName == "Soif")
            {
                if ((currentSoif + item.itemAttributes[i].attributeValue) > maxSoif)
                    currentSoif = maxSoif;
                else
                    currentSoif += item.itemAttributes[i].attributeValue;
            }
        }
    }

/*
    public void OnGearItem(Item item)
    {
        for (int i = 0; i < item.itemAttributes.Count; i++)
        {
            if (item.itemAttributes[i].attributeName == "Health")
                currentHealth += item.itemAttributes[i].attributeValue;
            if (item.itemAttributes[i].attributeName == "Mana")
                currentMana += item.itemAttributes[i].attributeValue;
            if (item.itemAttributes[i].attributeName == "Armor")
                currentArmor += item.itemAttributes[i].attributeValue;
            if (item.itemAttributes[i].attributeName == "Damage")
                currentDamage += item.itemAttributes[i].attributeValue;
        }
    }

    public void OnUnEquipItem(Item item)
    {
        for (int i = 0; i < item.itemAttributes.Count; i++)
        {
            if (item.itemAttributes[i].attributeName == "Health")
                currentHealth -= item.itemAttributes[i].attributeValue;
            if (item.itemAttributes[i].attributeName == "Mana")
                currentMana -= item.itemAttributes[i].attributeValue;
            if (item.itemAttributes[i].attributeName == "Armor")
                currentArmor -= item.itemAttributes[i].attributeValue;
            if (item.itemAttributes[i].attributeName == "Damage")
                currentDamage -= item.itemAttributes[i].attributeValue;
        }
    }

*/

    // Update is called once per frame
    void Update()
    {
        UpdateHunger();
        UpdateThirst();
        UpdateFatigue();
        UpdateFroid();

        if (currentHealth < 0)
        {
            Dead();
        }

        goldText.text = "" + goldCoins;

        if (Input.GetKeyDown(KeyCode.F))
        {
            inputDialogue = true;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inputDialogue = false;
        }

        /*

        //Input.GetKeyDown(KeyCode.O)

        //if (Input.GetKeyDown(inputManagerDatabase.CharacterSystemKeyCode) && inputDialogue == false)
        if (Input.GetKeyDown(KeyCode.M) && inputDialogue == false)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if (!characterSystem.activeSelf)
            {
                //characterSystemInventoryObject = GameObject.Find("Panel - EquipmentSystem(Clone)"); //.GetComponent<Inventory>();
                //characterSystemInventoryObject.enabled = false;
                characterSystemInventory.openInventory();
            }
            else
            {
                if (toolTip != null)
                    toolTip.deactivateTooltip();
                characterSystemInventory.closeInventory();



            }
        }

        //if (Input.GetKeyDown(inputManagerDatabase.InventoryKeyCode) && inputDialogue == false)
        if (Input.GetKeyDown(KeyCode.M) && inputDialogue == false)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if (!inventory.activeSelf)
            {
                mainInventory.openInventory();
            }
            else
            {
                if (toolTip != null)
                    toolTip.deactivateTooltip();
                mainInventory.closeInventory();



            }
        } 

        //if (Input.GetKeyDown(inputManagerDatabase.CraftSystemKeyCode) && inputDialogue == false)
        if (Input.GetKeyDown(KeyCode.M) && inputDialogue == false)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if (!craftSystem.activeSelf)
            {
                //craftSystemInventoryObject = GameObject.Find("Panel - CraftSystem(Clone)"); //.GetComponent<Inventory>();
                //craftSystemInventoryObject.enabled = false;
                craftSystemInventory.openInventory();
            }
            else
            {
                if (cS != null)
                    cS.backToInventory();
                if (toolTip != null)
                    toolTip.deactivateTooltip();
                craftSystemInventory.closeInventory();


            }
        }

        */

    }

}
