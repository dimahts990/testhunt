using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UISystem : MonoBehaviour
{
    [SerializeField]
    Slider progress;
    [SerializeField]
    GameObject startButton, restartButton, winsText;
    static int killBirds;

    private void Awake()
    {
        Time.timeScale=0;
    }

    private void Update()
    {
        progress.value = killBirds;
    }

    public static void addProgress()
    {
        killBirds++;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        startButton.SetActive(false);
    }

    public void EndGame()
    {
        restartButton.SetActive(true);
        winsText.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
