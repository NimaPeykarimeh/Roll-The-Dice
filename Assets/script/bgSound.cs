using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgSound : MonoBehaviour
{
    [SerializeField] AudioSource audioManager;
    [SerializeField] AudioClip music;

    private static bgSound _bgSoundInstance;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (_bgSoundInstance == null)
        {
            _bgSoundInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        

    }
    private void Start()
    {
        audioManager.PlayOneShot(music);

    }
}
