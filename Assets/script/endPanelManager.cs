using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endPanelManager : MonoBehaviour
{

    [SerializeField] private starManager _starManager;
    [SerializeField] private Button NextLevelButton;
    [SerializeField] private buttonManager _buttonManager;
    [Header("Sprites")]
    [SerializeField] private Sprite starCollected;
    [SerializeField] private Sprite emptyStar;

    [Header("Stars")]
    [SerializeField] private GameObject timeStar;
    [SerializeField] private GameObject levelCompleteStar;
    [SerializeField] private GameObject moveStar;
    // Start is called before the first frame update
    void Start()
    {
        _buttonManager= GameObject.FindGameObjectWithTag("gameManager").GetComponent<buttonManager>();
        NextLevelButton = transform.GetChild(0).gameObject.GetComponent<Button>();
        NextLevelButton.onClick.AddListener(_buttonManager.NextLevel);
        _starManager = GameObject.FindGameObjectWithTag("gameManager").GetComponent<starManager>();

        levelCompleteStar.GetComponent<RawImage>().texture = starCollected.texture;

        if (_starManager.currentMovesMade <= _starManager.requiredMoves)
        {
            moveStar.GetComponent<RawImage>().texture = starCollected.texture;
        }

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
