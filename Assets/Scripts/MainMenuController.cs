using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void Play()
    {
        Debug.Log("Play!");
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}
