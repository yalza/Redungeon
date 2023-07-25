using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventSystem : MonoBehaviour
{
    public void OnStartGame()
    {
        PlayerPrefs.SetInt(Constant.playerIndex, 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene(2);
    }

    public void OnReplayGame()
    {
        SceneManager.LoadScene(2);
    }

    public void OnSelectCharacter()
    {
        SceneManager.LoadScene(1);
    }
}


