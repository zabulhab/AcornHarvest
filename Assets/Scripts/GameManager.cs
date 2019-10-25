using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// I don't think I'm using this right
/// </summary>
public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public bool paused { get; set; }

    [SerializeField]
    private GUIController guiController;

    [SerializeField]
    private Pause pause;

    public bool IsGameOver;

    [SerializeField]
    private PopupMessage popupMessageRun;

    [SerializeField]
    private PopupMessage popupMessagePause;

    [SerializeField]
    private PopupMessage popupMessagePower;

    private int totalSpawnedObjects;
    public float CurrentFallSpeed { get; set; }
    private readonly float MAX_FALL_SPEED = -20;

    private void Awake()
    {
        CurrentFallSpeed = -5;
    }

    // Increment the amount of spawned objects
    // called by Collectable when it spawns
    public void IncrementTotalSpawned()
    {
        totalSpawnedObjects += 1;
        if (totalSpawnedObjects %20 == 0 && CurrentFallSpeed > MAX_FALL_SPEED)
        {
            IncreaseFallSpeed();
        }
    }

    private void IncreaseFallSpeed()
    {
        CurrentFallSpeed -= .5f;
    }

    // Start is called before the first frame update
    void Start()
    {
        IsGameOver = false;
        paused = false;
        totalSpawnedObjects = 0;
    }

    public void Restart()
    {
        IsGameOver = false;
        paused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        paused = false;
        IsGameOver = false;
        pause.UnpauseGame();
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        IsGameOver = true;
        guiController.ShowGameOverMenu();
        popupMessageRun.HideMessage();
        popupMessagePause.HideMessage();
        popupMessagePower.HideMessage();
        pause.PauseGame();
        paused = true;
    }
}
