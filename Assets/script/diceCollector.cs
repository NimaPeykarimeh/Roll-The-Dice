using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diceCollector : MonoBehaviour
{
    [SerializeField] GameObject theSide;
    [SerializeField] AudioSource audioManager;
    [SerializeField] AudioClip stick;
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject particle;
    [SerializeField] Quaternion _rotation;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("audioManager").GetComponent<AudioSource>();
        gameManager = GameObject.FindGameObjectWithTag("gameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == gameObject.name)
        {
            theSide.SetActive(true);
            collider.gameObject.transform.parent.GetChild(1).gameObject.SetActive(true);
            collider.gameObject.SetActive(false);
            audioManager.PlayOneShot(stick);
            gameManager.AddScore(int.Parse(collider.tag));



            //Instantiate(particle,position: gameObject.transform.position, rotation:_rotation);

        }
    }
}
