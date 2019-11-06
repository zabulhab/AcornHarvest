using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

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

    [HideInInspector]
    public bool IsGameOver;

    [SerializeField]
    private PopupMessage popupMessageRun;

    [SerializeField]
    private PopupMessage popupMessagePause;

    [SerializeField]
    private PopupMessage popupMessagePower;

    [HideInInspector]
    public int totalSpawnedObjects;
    public float CurrentFallSpeed { get; set; }
    private readonly float MAX_FALL_SPEED = -20;

    /// <summary>
    /// True if popup messages have been shown once since opening the game.
    /// Set to true after the last message has disappeared.
    /// </summary>
    public bool popupMessagesAlreadyShown;


    [System.Serializable]
    public class GameManagerEvents
    {
        [Tooltip("Invoked when the game has ended")]
        public UnityEvent OnGameOver;
    }

    public GameManagerEvents events;

    public static GameManagerEvents Events { get { return instance.events; } }

    // Variables for the Singleton instance of this Game Manager.
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    // Start is called before the first frame update
    void Start()
    {
        IsGameOver = false;
        paused = false;
        totalSpawnedObjects = 0;
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
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

    public void Restart()
    {
        IsGameOver = false;
        paused = false;
        totalSpawnedObjects = 0;
        pause.UnpauseGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        paused = false;
        IsGameOver = false;
        pause.UnpauseGame();
        totalSpawnedObjects = 0;
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        totalSpawnedObjects = 0;
        events.OnGameOver.Invoke();
        IsGameOver = true;
        guiController.ShowGameOverMenu();
        popupMessageRun.HideMessage();
        popupMessagePause.HideMessage();
        popupMessagePower.HideMessage();
        pause.PauseGame();
        paused = true;
    }
}
