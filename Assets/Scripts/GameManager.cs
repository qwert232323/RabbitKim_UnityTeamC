using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject ResultUI;
    public Text ResutText;
    public bool _receive_victory;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(instance);
        }
    }

    public void Result()
    {
        if (_receive_victory)
        {
            ResutText.text = "승리!";

        }

        else 
        {
            ResutText.text = "패배...";
        }
        ResultUI.SetActive(true);
    }
    public void ReGame() {
        SceneManager.LoadScene("Scenes/Map/1");
        Time.timeScale = 1f;
    }
    public void GoLobby() {
        SceneManager.LoadScene("Scenes/Lobby");
        Time.timeScale = 1f;
    }
}
