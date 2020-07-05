using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        // Add inventory
        bool wasPickedUp = Inventory.instence.AddItem(item);

        if (wasPickedUp)
            Destroy(gameObject);
    }
}
