using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehavior : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Equipment equipmentSystem;

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && equipmentSystem.equipedWeaponItem != null)
        {
            //animator.SetTrigger("Attack");
            //animations.Play("sword");
        }
    }
}
