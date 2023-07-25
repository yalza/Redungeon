using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int playerDistance = 0;
    [SerializeField] Vector3 playerStartPosition;
    [SerializeField] int playerCoin = 0;

    [SerializeField] GameObject[] Characters;

    private void OnEnable()
    {
        InputEvents.exitEvent.AddListener(OnExit);
        GameEvents.gameOverEvent.AddListener(OnGameOver);
    }

    private void Awake()
    {
        Debug.Log(PlayerPrefs.GetInt(Constant.playerIndex));
        Characters[PlayerPrefs.GetInt(Constant.playerIndex)].SetActive(true);
        
    }

    private void Start()
    {
        int bestDist = PlayerPrefs.GetInt(Constant.bestDist);

        playerCoin = 0;
        playerStartPosition = PlayerMoveController.Instant.transform.position;

        

        GameEvents.updateBestDistanceEvent.Invoke(bestDist);

    }

    private void FixedUpdate()
    {
        CalculateVerticalDistance();
    }

    private void OnDisable()
    {
        InputEvents.exitEvent.RemoveListener(OnExit);
        GameEvents.gameOverEvent.RemoveListener(OnGameOver);
    }

    private void CalculateVerticalDistance()
    {
        playerDistance = Mathf.Max(playerDistance, (int)(PlayerMoveController.Instant.transform.position.y - playerStartPosition.y));
        GameEvents.updateDistanceEvent.Invoke(playerDistance);
        GameEvents.updateBestDistanceEvent.Invoke(playerDistance);
    }

    public void UpdateCoin(int value)
    {
        playerCoin += value;
        GameEvents.updateCoinEvent.Invoke(playerCoin);
        PlayerPrefs.SetInt(Constant.totalCoin, value + PlayerPrefs.GetInt(Constant.totalCoin));
        PlayerPrefs.Save();
    }

    public void OnExit()
    {
        #if (UNITY_EDITOR || DEVELOPMENT_BUILD)
            Debug.Log(this.name + " : " + this.GetType() + " : " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        #endif
        #if (UNITY_EDITOR)
            UnityEditor.EditorApplication.isPlaying = false;
        #elif (UNITY_STANDALONE)
                    Application.Quit();
        #elif (UNITY_WEBGL)
                    SceneManager.LoadScene("QuitScene");
        #endif
    }

    public void OnGameOver()
    {
        PlayerPrefs.SetInt(Constant.distance, playerDistance);
        PlayerPrefs.Save();
        SceneManager.LoadScene(3);
    }
}
