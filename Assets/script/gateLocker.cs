using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class gateLocker : MonoBehaviour
{
    [SerializeField] int neededScore;
    Vector3 gateCurrentPos;
    Vector3 targetPos;
    [SerializeField] float DoorSpeed;
    int currentScore;
    [SerializeField] TextMeshPro scoreText;
    [SerializeField] GameObject gameManager;
    [SerializeField] Color correctColor;
    [SerializeField] Color wrongColor;
    [SerializeField] bool isOpen;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("gameManager");
        gateCurrentPos = transform.position;
        targetPos = new Vector3(transform.position.x, transform.position.y - 2, transform.position.z);
        isOpen = false;

        scoreText.text = "|" + currentScore.ToString() + "/" + neededScore.ToString() + "|";

        GameManager.Instance.OnScore += OpenGate;
    }


    public void OpenGate()
    {
        currentScore = gameManager.GetComponent<GameManager>().currentScore;
        scoreText.text = "|" + currentScore.ToString() + "/" + neededScore.ToString() + "|";
        if (currentScore == neededScore)
        {
            scoreText.color = correctColor;
            isOpen = true;

        }
        if (currentScore > neededScore && !isOpen)
        {
            scoreText.color = wrongColor;
        }
        
    }

    private void FixedUpdate()
    {

        if (isOpen)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, DoorSpeed * Time.deltaTime);
        }



    }
}
