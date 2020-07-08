using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot;
    public SkinnedMeshRenderer mess;

    public int armorModifier;
    public int damageModifiar;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
    }
}

public enum EquipmentSlot { Male, Smg, Rifel }
