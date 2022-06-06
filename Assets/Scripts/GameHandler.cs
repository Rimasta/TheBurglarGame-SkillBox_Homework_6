using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameHandler : MonoBehaviour
{
    public Text timerText;

    public GameObject defeatPanel;
    public GameObject victoryPanel;

    [SerializeField] private float timer = 20f;
    [SerializeField] private int firstPin = 7, secondPin = 1, thirdPin=5;
    private bool _isGameOver = false;

    public Text firstPinText, secondPinText, thirdPinText;

    void Start()
    {
        PinUpdate();
    }
    
    void Update()
    {
        GameTimer();
    }

    private void GameTimer()
    {
        if (!_isGameOver)
        {
            timer -= Time.deltaTime;
            timerText.text = Convert.ToString(math.round(timer));
            if (timer <= 0)
            {
                defeatPanel.SetActive(true);
                _isGameOver = true;
            }
        } 
        
    }

    private void PinUpdate()
    {
        if (firstPin < 0) firstPin = 0;
        if (firstPin > 10) firstPin = 10;
        firstPinText.text = Convert.ToString(firstPin);
        
        if (secondPin < 0) secondPin = 0;
        if (secondPin > 10) secondPin = 10;
        secondPinText.text = Convert.ToString(secondPin);
        
        if (thirdPin < 0) thirdPin = 0;
        if (thirdPin > 10) thirdPin = 10;
        thirdPinText.text = Convert.ToString(thirdPin);
        
        if (firstPin == 5 && secondPin == 5 && thirdPin == 5)
        {
            victoryPanel.SetActive(true);
            _isGameOver = true;
        }
    }

    public void UseDrillOnButtonClick()
    {
        firstPin += 1;
        secondPin -= 1;
        thirdPin += 0;
        PinUpdate();
    }
    
    public void UseHammerOnButtonClick()
    {
        firstPin -= 1;
        secondPin += 2;
        thirdPin -= 1;
        PinUpdate();
    }
    
    public void UseLatchkeyOnButtonClick()
    {
        firstPin -= 1;
        secondPin += 1;
        thirdPin += 1;
        PinUpdate();
    }
    
    public void ReloadSceneOnButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
