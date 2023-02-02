using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystemS : MonoBehaviour
{
    public static TooltipSystemS instance;

    [SerializeField]
    private TooltipS tooltipS;

    private void Awake() 
    {
        instance = this;
    }

    public void Show(string content, string header = ""){
        tooltipS.SetText(content, header);
        tooltipS.gameObject.SetActive(true);
    }

    public void Hide(){
        tooltipS.gameObject.SetActive(false);
    }
}
