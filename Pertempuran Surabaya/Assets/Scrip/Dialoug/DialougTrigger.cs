using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougTrigger : MonoBehaviour
{
    public Dialoug dialoug;

    void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<DialougManager>().StartDialoug(dialoug);
    }
}
