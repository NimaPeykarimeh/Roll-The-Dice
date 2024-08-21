using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonManager : MonoBehaviour
{
    private void Start()
    {
        Debug.Log(gameObject.transform.childCount);

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text = "Level " + (i + 1).ToString();
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadLevel()
    {
        string clickedButton = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text;
        SceneManager.LoadScene(clickedButton);
        
        
    }

}
