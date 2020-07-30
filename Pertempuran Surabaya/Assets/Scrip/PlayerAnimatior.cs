using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatior : CharacterAnimator
{
    protected override void Start()
    {
        base.Start();
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null && newItem.equipSlot.Equals(EquipmentSlot.Rifel) || newItem.equipSlot.Equals(EquipmentSlot.Male) || newItem.equipSlot.Equals(EquipmentSlot.Smg))
        {
            animator.SetLayerWeight(1, 1);
        } else
        {
            animator.SetLayerWeight(1, 0);
        }
    }
}
