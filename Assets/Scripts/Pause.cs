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
            if (GameManager.Instance.paused == false && !GameManager.Instance.IsGameOver)
            {
                PauseGame();
                guiController.ShowPauseMenu();
            }
            else if (GameManager.Instance.paused == true && !GameManager.Instance.IsGameOver)
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
        GameManager.Instance.paused = true;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1f;
        GameManager.Instance.paused = false;
    }
}
