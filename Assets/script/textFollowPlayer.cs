using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class textFollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] float textDist;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void LateUpdate()
    {   

        transform.position = new Vector3(player.transform.position.x,player.transform.position.y + textDist, player.transform.position.z);
    }
    
}
