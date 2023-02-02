using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItemS : MonoBehaviour
{
    [SerializeField]
    private float pickupRange = 2.6f;
    public InventoryS inventorys;

    [SerializeField]
    private GameObject pickupText;

    [SerializeField]
    private LayerMask layerMask;

    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit, pickupRange, layerMask)) {
            if(hit.transform.CompareTag("Item")) {
                pickupText.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E)) {
                    inventorys.content.Add(hit.transform.gameObject.GetComponent<ItemS>().item);
                    Destroy(hit.transform.gameObject);
                }
            }
        } else {
            pickupText.SetActive(false);
        }
    }
}
