using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class starManager : MonoBehaviour
{
    [Header("MovesMade")]
    public int requiredMoves;
    [SerializeField] private TextMeshProUGUI requiredMovesText;
    public int currentMovesMade;
    public TextMeshProUGUI currentMovesText;

    [SerializeField] Color correctCollor;
    [SerializeField] Color wrongColor;


    // Start is called before the first frame update
    void Start()
    {
        currentMovesText = GameObject.FindGameObjectWithTag("movesText").GetComponent<TextMeshProUGUI>();
        currentMovesMade = 0;
        currentMovesText.color = correctCollor;
        currentMovesText.text = currentMovesMade.ToString() + "/" + requiredMoves;
    }

    public void AddToMovesCount()
    {
        currentMovesMade++;
        if (currentMovesMade <= requiredMoves)
        {
            currentMovesText.color = correctCollor;
        }
        else
        {
            currentMovesText.color = wrongColor;
            currentMovesText.fontStyle = FontStyles.Strikethrough;
        }
        currentMovesText.text = currentMovesMade.ToString() + "/" + requiredMoves.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
