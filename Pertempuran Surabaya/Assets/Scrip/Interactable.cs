using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactableTransform;

    bool isFocus = false;
    Transform player;

    bool hasInteractable = false;
    

    public virtual void Interact ()
    {

    }

    void Update()
    {
        if (isFocus && !hasInteractable)
        {
            float distance = Vector3.Distance(player.position, interactableTransform.position);
            if (distance <= radius)
            {
                Interact();
                hasInteractable = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteractable = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteractable = true;
    }

    void OnDrawGizmosSelected()
    {
        if (interactableTransform == null)
            interactableTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactableTransform.position, radius);
    }
}
