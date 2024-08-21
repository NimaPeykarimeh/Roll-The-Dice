using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAvailable : MonoBehaviour
{
    public bool moveAvailabe;

    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            moveAvailabe = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            moveAvailabe = false;

        }

    }

}
