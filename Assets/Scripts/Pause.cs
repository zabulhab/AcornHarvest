using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private GUIController guiController;

    // Handle enter input
    private void Update()
    {
        if (Input.GetKeyDown("enter") || Input.GetKeyDown("return"))
        {
            if (gameManager.paused == false && !gameManager.IsGameOver)
            {
                PauseGame();
                guiController.ShowPauseMenu();
            }
            else if (gameManager.paused == true && !gameManager.IsGameOver)
            {
                UnpauseGame();
                guiController.HidePauseMenu();
            }

        } 
    }

    public void PauseGame()
    {
        Debug.Log("Y");
        Time.timeScale = 0f;
        gameManager.paused = true;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1f;
        gameManager.paused = false;
    }
}
