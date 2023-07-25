using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI distance;
    [SerializeField] TextMeshProUGUI coin;
    [SerializeField] TextMeshProUGUI bestDistance;

    [SerializeField] GameObject scorePanel;
    [SerializeField] GameObject pausePanel;

    private void OnEnable()
    {
        GameEvents.updateDistanceEvent.AddListener(UpdateDistance);
        GameEvents.updateCoinEvent.AddListener(UpdateCoin);
        GameEvents.updateBestDistanceEvent.AddListener(UpdateBestDistance);
    }

    private void OnDisable()
    {
        GameEvents.updateDistanceEvent.RemoveListener(UpdateDistance);
        GameEvents.updateCoinEvent.RemoveListener(UpdateCoin);
        GameEvents.updateBestDistanceEvent.RemoveListener(UpdateBestDistance);
    }


    private void UpdateDistance(int value)
    {
        distance.text = value.ToString() + "m";
    }

    private void UpdateCoin(int value)
    {
        coin.text = "+    " + value.ToString();
    }

    private void UpdateBestDistance(int value)
    {
        int bestDist = PlayerPrefs.GetInt(Constant.bestDist);
        if (bestDist < value)
        {
            bestDist = value;
            PlayerPrefs.SetInt(Constant.bestDist, value);
            PlayerPrefs.Save();

        }

        bestDistance.text = "Best:" + bestDist + "m";

    }

    public void OnPause()
    {
        scorePanel.SetActive(false);
        pausePanel.SetActive(true);

    }
    public void OnResume()
    {
        Time.timeScale = 1;
        scorePanel.SetActive(true);
        pausePanel.SetActive(false);
    } 


    }
