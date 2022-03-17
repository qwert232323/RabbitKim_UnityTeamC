using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    public void Game_start()
    {
        SceneManager.LoadScene("Scenes/Map/1");
    }
}
