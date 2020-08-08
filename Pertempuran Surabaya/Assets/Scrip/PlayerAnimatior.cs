using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatior : CharacterAnimator
{
    public WeaponAnimations[] weaponAnimations;
    Dictionary<Equipment, AnimationClip[]> weaponeAnimationDict;
    protected override void Start()
    {
        base.Start();
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;

        weaponeAnimationDict = new Dictionary<Equipment, AnimationClip[]>();
        foreach (WeaponAnimations a in weaponAnimations)
        {
            weaponeAnimationDict.Add(a.weapon, a.clips);
        }
    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null && newItem.equipSlot.Equals(EquipmentSlot.Rifel) || newItem.equipSlot.Equals(EquipmentSlot.Male) || newItem.equipSlot.Equals(EquipmentSlot.Smg))
        {
            animator.SetLayerWeight(1, 1);
            if (weaponeAnimationDict.ContainsKey(newItem))
            {
                currentAttackAnimSet = weaponeAnimationDict[newItem];
            }
        } else
        {
            animator.SetLayerWeight(1, 0);
            currentAttackAnimSet = defaultAttackAnimSet;
        }
    }
    [System.Serializable]
    public struct WeaponAnimations
    {
        public Equipment weapon;
        public AnimationClip[] clips;
    }
}
