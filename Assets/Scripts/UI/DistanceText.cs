using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceText : MonoBehaviour
{
    TextMeshProUGUI distanceText;

    private void Awake()
    {
        distanceText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        distanceText.text = PlayerPrefs.GetInt(Constant.distance).ToString() + "m";
    }
}
