using UnityEngine;
using TMPro;
using System.Collections;

public class TextBlink : MonoBehaviour
{
    [SerializeField] float blinkDuration = 1f;
    TextMeshProUGUI textMeshProUGUI;
    Color baseColor;

    private void Awake()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        baseColor = textMeshProUGUI.color;
    }

    private void Start()
    {
        StartCoroutine(BlinkText());
    }

    private IEnumerator BlinkText()
    {
        while (true)
        {
            float elapsedTime = 0f;

            while (elapsedTime < blinkDuration)
            {
                float alpha = Mathf.PingPong(Time.time, blinkDuration) / blinkDuration;
                Color newColor = new Color(baseColor.r, baseColor.g, baseColor.b, alpha);
                textMeshProUGUI.color = newColor;

                elapsedTime += Time.deltaTime;
                yield return null;
            }
            yield return null;
        }
    }
}
