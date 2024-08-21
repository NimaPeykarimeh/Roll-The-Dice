using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public event Action OnScore;
    private void Awake()
    {
        if(Instance== null)
        {
            Instance= this;
        }
    }
    public static bool isPlaying = true;
    int totatScore = 6 + 5 + 4 + 3 + 2 + 1;
    public int currentScore = 0;
    [SerializeField] TextMeshPro scoreText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] GameObject player;
    private int currentScene;
    [SerializeField] GameObject levelCompletePanel;

    [SerializeField] float timeBetweenAddingScore;
    [SerializeField] float scoreTimer;
    [SerializeField] bool isScoreAdded = false;
    int animScore;
    int addedScore;
    int scoreWillBeAdded;
    AudioSource _audioSource;
    [SerializeField] AudioClip succesSoundEffet;
    private void Start()
    {
        _audioSource = GameObject.FindGameObjectWithTag("audioManager").GetComponent<AudioSource>();
        //levelCompletePanel = GameObject.FindGameObjectWithTag("levelCompletePanel");
        //levelCompletePanel.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        isPlaying = true;
        scoreText = GameObject.Find("scoreText").GetComponent<TextMeshPro>();
        levelText = GameObject.Find("Canvas").gameObject.transform.Find("levelText").gameObject.GetComponent<TextMeshProUGUI>();
        levelText.text = SceneManager.GetActiveScene().name;
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }
    public void AddScore(int score)
    {   /*
        currentScore+= score;
        
        scoreText.gameObject.GetComponent<Animator>().Play("scoreAddedAnim");
        scoreText.text =currentScore.ToString() + "/" + totatScore.ToString();

        if (currentScore == totatScore)
        {
            LevelComplete();
        }
        */
        scoreText.gameObject.GetComponent<Animator>().Play("scoreAddedAnim");
        isScoreAdded = true;
        animScore = currentScore;
        currentScore += score;
        scoreWillBeAdded = score;
        addedScore = 0;
        scoreTimer = 0;
    }
    private void LevelComplete()
    {
        _audioSource.clip = succesSoundEffet;
        _audioSource.Play();
        levelCompletePanel.SetActive(true);
        isPlaying = false;
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LevelsScene()
    {
        SceneManager.LoadScene("Levels");
    }
    public void StartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GetButtonClick(Button _btn)
    {
        Debug.Log(_btn.name);
        if (_btn.name == "w")
        {
            player.GetComponent<movement>().GoDirW();
        }
        if (_btn.name == "a")
        {
            player.GetComponent<movement>().GoDirA();
        }
        if (_btn.name == "s")
        {
            player.GetComponent<movement>().GoDirS();
        }
        if (_btn.name == "d")
        {
            player.GetComponent<movement>().GoDirD();
        }
    }

    private void Update()
    {
        if (isScoreAdded)
        {
            
            //if you collect score fast doesn't work well, fix it!!
            scoreTimer += Time.deltaTime;
            
            if (scoreTimer >= timeBetweenAddingScore && addedScore < scoreWillBeAdded)
            {
                

                scoreTimer = 0;
                animScore ++;
                addedScore++;
                
                scoreText.text = animScore.ToString() + "/" + totatScore.ToString();

                if (currentScore == totatScore)
                {
                    LevelComplete();
                }

            }
            if (addedScore == scoreWillBeAdded)
            {
                isScoreAdded = false;
                OnScore?.Invoke();

            }
        }




        if (currentScene == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("Levels");
        }
    }
}
