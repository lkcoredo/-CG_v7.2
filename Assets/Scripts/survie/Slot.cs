using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ItemData itemS;
    public Image itemVisual;

    [SerializeField]
    private ItemActionSystem itemActionSystem;

    public void OnPointerEnter(PointerEventData eventData) {
        if(itemS != null) {
            TooltipSystemS.instance.Show(itemS.description, itemS.name);
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        TooltipSystemS.instance.Hide();
    }

    public void ClickOnSlot()
    {
        itemActionSystem.OpenActionPanel(itemS, transform.position);
    }
}
