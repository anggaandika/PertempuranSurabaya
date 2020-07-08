using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton

    public static EquipmentManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<EquipmentManager>();
            }
            return _instance;
        }
    }
    static EquipmentManager _instance;

    void Awake()
    {
        _instance = this;
    }

    #endregion

    public SkinnedMeshRenderer targetMess;
    Equipment[] currentEquipment;
    SkinnedMeshRenderer[] currentMeshes;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;

    void Start()
    {
        inventory = Inventory.instence;

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
        currentMeshes = new SkinnedMeshRenderer[numSlots];
    }

    public void Equip(Equipment newItem)
    {
        Equipment oldItem = null;

        int slotIndex = (int)newItem.equipSlot;

        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.AddItem(oldItem);
        }

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        currentEquipment[slotIndex] = newItem;
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mess);
        newMesh.transform.parent = targetMess.transform;

        newMesh.bones = targetMess.bones;
        newMesh.rootBone = targetMess.rootBone;
        currentMeshes[slotIndex] = newMesh;
    }

    public void Unequip (int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            if (currentMeshes[slotIndex] != null)
            {
                Destroy(currentMeshes[slotIndex].gameObject);
            }
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.AddItem(oldItem);

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }

            currentEquipment[slotIndex] = null;
        }
    }

    public void UnequipAll ()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            UnequipAll();
    }
}
