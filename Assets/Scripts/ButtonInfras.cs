using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInfras : MonoBehaviour
{
    public bool rtsVisibleINFRAS;
    public bool rtsVisibleCINEMA;
    public bool rtsVisibleSURVIVAL;
    public bool rtsVisibleRESSOURCES;
    public bool rtsVisibleLIVINGS;
    public bool rtsVisiblePSY;

    void Start()
    {
        rtsVisibleINFRAS = true;
        rtsVisibleCINEMA = true;
        rtsVisibleSURVIVAL = true;
        rtsVisibleRESSOURCES = true;
        rtsVisibleLIVINGS = true;
        rtsVisiblePSY = true;
        Activate_DeactivateINFRAS();
        Activate_DeactivateCINEMA();
        Activate_DeactivateSurvivalInfos();
        Activate_DeactivateRessources();
        Activate_DeactivateLivings();
        Activate_DeactivatePsychologie();
    }

    public void Activate_DeactivateINFRAS() { 
        if (rtsVisibleINFRAS == true) // Hide button
        {
            GameObject.Find("INFRA").transform.localScale = new Vector3(0, 0, 0);
            rtsVisibleINFRAS = false;
        } 
        else // Show button
        {
            GameObject.Find("INFRA").transform.localScale = new Vector3(2, 2, 2);
            rtsVisibleINFRAS = true;
        }
    }

    public void Activate_DeactivateCINEMA() { 
        if (rtsVisibleCINEMA == true) // Hide button
        {
            GameObject.Find("cinema").transform.localScale = new Vector3(0, 0, 0);
            rtsVisibleCINEMA = false;
        } 
        else // Show button
        {
            GameObject.Find("cinema").transform.localScale = new Vector3(2, 2, 2);
            rtsVisibleCINEMA = true;
        }
    }

    public void Activate_DeactivateSurvivalInfos() { 
        if (rtsVisibleSURVIVAL == true) // Hide button
        {
            GameObject.Find("SurvivalInfos").transform.localScale = new Vector3(0, 0, 0);
            rtsVisibleSURVIVAL = false;
            print("SurvivalInfos HIDE");
        } 
        else // Show button
        {
            GameObject.Find("SurvivalInfos").transform.localScale = new Vector3(1, 1, 1);
            rtsVisibleSURVIVAL = true;
            print("SurvivalInfos SHOW");
        }
    }

    public void Activate_DeactivateRessources() { 
        if (rtsVisibleRESSOURCES == true) // Hide button
        {
            GameObject.Find("RESS").transform.localScale = new Vector3(0, 0, 0);
            rtsVisibleRESSOURCES = false;
            print("RESSOURCES HIDE");
        } 
        else // Show button
        {
            GameObject.Find("RESS").transform.localScale = new Vector3(1, 1, 1);
            rtsVisibleRESSOURCES = true;
            print("RESSOURCES SHOW");
        }
    }

    public void Activate_DeactivateLivings() { 
        if (rtsVisibleLIVINGS == true) // Hide button
        {
            GameObject.Find("Livings").transform.localScale = new Vector3(0, 0, 0);
            rtsVisibleLIVINGS = false;
        } 
        else // Show button
        {
            GameObject.Find("Livings").transform.localScale = new Vector3(2, 2, 2);
            rtsVisibleLIVINGS = true;
        }
    }

    public void Activate_DeactivatePsychologie() { 
        if (rtsVisiblePSY == true) // Hide button
        {
            GameObject.Find("PSYC").transform.localScale = new Vector3(0, 0, 0);
            rtsVisiblePSY = false;
        } 
        else // Show button
        {
            GameObject.Find("PSYC").transform.localScale = new Vector3(2, 2, 2);
            rtsVisiblePSY = true;
        }
    }
}
