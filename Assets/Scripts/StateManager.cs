using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    public static StateManager Instance { get; set; }

    public int distance = 0;
    public int waveAngle = 0;

    public Text distanceText;
    public Text angleText;
    public Text resultText;
    public RectTransform angleImage;
    
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else { Destroy(this); }
    }

    private void Update()
    {
        distanceText.text = $"Distance:\n{distance}m";
        angleText.text = $"{waveAngle}°";
        angleImage.rotation = Quaternion.Euler(0, 0, waveAngle);
    }

    public void GameWon(int score)
    {
        resultText.text = $"You delivered {score} cargo!";
        resultText.enabled = true;
        Debug.Log($"You delivered {score} cargo!");
        StartCoroutine(EndGame());
    }

    public void GameLost()
    {
        resultText.text = "You sunk :(";
        resultText.enabled = true;
        Debug.Log("You sunk :(");
        StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
