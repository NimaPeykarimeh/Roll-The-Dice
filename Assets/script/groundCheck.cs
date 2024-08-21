using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{

    [SerializeField] GameObject theDice;
    private void Start()
    {
        theDice = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        transform.position = theDice.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

}
