using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BestDistanceText : MonoBehaviour
{
    TextMeshProUGUI bestDistanceText;

    private void Awake()
    {
        bestDistanceText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        bestDistanceText.text ="best: " +  PlayerPrefs.GetInt(Constant.bestDist).ToString() + "m";
    }
}
