using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerInfos : MonoBehaviour
{
    public string input;
    public string Prenom;
    public string Nom;
    public string Age;
    public string Poids;
    public string Endurance;
    public string Force;
    public string Souplesse;
    public string Agilite;
    public string ForceMentale;
    public string Apnee;

    /*public TMP_InputField nameInputField;*/


    void UpdateInputField(string data)
    {
        print("data : " + data);
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("Prenom", Prenom);
        PlayerPrefs.SetString("Nom", Nom);
        PlayerPrefs.SetString("Age", Age);
        PlayerPrefs.SetString("Poids", Poids);
        PlayerPrefs.SetString("Endurance", Endurance);
        PlayerPrefs.SetString("Force", Force);
        PlayerPrefs.SetString("Souplesse", Souplesse);
        PlayerPrefs.SetString("Agilite", Agilite);
        PlayerPrefs.SetString("ForceMentale", ForceMentale);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadStringInputPrenom(string s)
    {
        input = s;
        PlayerPrefs.SetString("Prenom", input);
    }

    public void ReadStringInputNom(string s)
    {
        input = s;
        PlayerPrefs.SetString("Nom", input);
    }

    public void ReadStringInputAge(string s)
    {
        input = s;
        PlayerPrefs.SetString("Age", input);
    }

    public void ReadStringInputPoids(string s)
    {
        input = s;
        PlayerPrefs.SetString("Poids", input);
    }

    public void ReadStringInputEndurance(string s)
    {
        input = s;
        PlayerPrefs.SetString("Endurance", input);
    }

    public void ReadStringInputForce(string s)
    {
        input = s;
        PlayerPrefs.SetString("Force", input);
    }

    public void ReadStringInputSouplesse(string s)
    {
        input = s;
        PlayerPrefs.SetString("Souplesse", input);
    }

    public void ReadStringInputAgilite(string s)
    {
        input = s;
        PlayerPrefs.SetString("Agilite", input);
    }

    public void ReadStringInputForceMentale(string s)
    {
        input = s;
        PlayerPrefs.SetString("ForceMentale", input);
    }

    public void ReadStringInputApnee(string s)
    {
        input = s;
        PlayerPrefs.SetString("Apnee", input);
    }
}
