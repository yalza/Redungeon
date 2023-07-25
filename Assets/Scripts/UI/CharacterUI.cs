using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    [SerializeField] RectTransform content;

    [SerializeField] RectTransform[] rectTransforms;

    [SerializeField] Button owned, unlock, play;

    [SerializeField] int price;

    int playerIndex;

    private void Awake()
    {
        
    }

    private void Start()
    {
        playerIndex = 0;
        PlayerPrefs.SetInt("0", 1);
        PlayerPrefs.Save();
    }

    public void OnPlayGame()
    {
        playerIndex = Mathf.Abs((int)( content.anchoredPosition.x / rectTransforms[0].rect.width));
        PlayerPrefs.SetInt(Constant.playerIndex,playerIndex);
        PlayerPrefs.Save();
        SceneManager.LoadScene(2);
    }

    private void Update()
    {
        
    }

    private void UpdateUnlocked()
    {

        bool isOwned = PlayerPrefs.GetInt(playerIndex.ToString()) == 1;
        if (isOwned)
        {
            owned.gameObject.SetActive(true);
            unlock.gameObject.SetActive(false);
            play.transform.GetChild(0).GetComponent<Image>().color = Color.white;
            play.interactable = true;
        }
        else
        {
            owned.gameObject.SetActive(false);
            unlock.gameObject.SetActive(true);
            play.transform.GetChild(0).GetComponent<Image>().color = Color.gray;
            play.interactable = false;  

            if (PlayerPrefs.GetInt(Constant.totalCoin) >= price)
            {
                unlock.interactable = true;
                unlock.transform.GetChild(0).GetComponent<Image>().color = Color.white;
            }
            else
            {
                unlock.interactable = false;
                unlock.transform.GetChild(0).GetComponent<Image>().color = Color.gray;
            }
        }
       

    }


    public void OnPrev()
    {
        
        if (content.anchoredPosition.x == 0) {
            content.anchoredPosition = new Vector3( -content.rect.width + rectTransforms[1].rect.width, content.anchoredPosition.y);
        }
        else
        {
            content.anchoredPosition = new Vector3(content.anchoredPosition.x + rectTransforms[1].rect.width, content.anchoredPosition.y);
        }
        playerIndex = Mathf.Abs((int)(content.anchoredPosition.x / rectTransforms[0].rect.width));
        UpdateUnlocked();
    }
    public void OnNext()
    {
        
        if (content.anchoredPosition.x == -content.rect.width + rectTransforms[1].rect.width)
        {
            content.anchoredPosition = new Vector3(0, content.anchoredPosition.y);
        }
        else
        {
            content.anchoredPosition = new Vector3(content.anchoredPosition.x - rectTransforms[1].rect.width, content.anchoredPosition.y);
        }
        playerIndex = Mathf.Abs((int)(content.anchoredPosition.x / rectTransforms[0].rect.width));
        UpdateUnlocked();
    }

    public void OnReturn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Unlock()
    {
        owned.gameObject.SetActive(true);
        unlock.gameObject.SetActive(false);
        play.transform.GetChild(0).GetComponent<Image>().color = Color.white;
        play.interactable = true;
        PlayerPrefs.SetInt(Constant.totalCoin,PlayerPrefs.GetInt(Constant.totalCoin) - price);
        PlayerPrefs.SetInt(playerIndex.ToString(), 1);
        PlayerPrefs.Save();
        GameEvents.updateTotalCoinEvent.Invoke();
    }
}
