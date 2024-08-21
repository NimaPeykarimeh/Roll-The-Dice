using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using TMPro;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    private GameObject _player;
    public Vector3 offset;
    private float playerFirstHeight;
    [SerializeField] bool _test;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        playerFirstHeight = _player.transform.position.y;
    }


    private void LateUpdate()
    {

        if (_test)
        {
            transform.position = new Vector3(_player.transform.position.x + offset.x, playerFirstHeight + offset.y, _player.transform.position.z + offset.z);

        }
        else
        {
            transform.position = new Vector3(_player.transform.position.x + offset.x, _player.transform.position.y
                + offset.y, _player.transform.position.z + offset.z);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
