using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private GameObject GameOverMenu;

    [SerializeField]
    private GameObject PauseMenu;

    [SerializeField]
    private GameObject FullChargeText;

    [SerializeField]
    private GameObject ChargeBar;

    [HideInInspector]
    public void UpdateScoreText(int score)
    {
        scoreText.text = "x " + score;
    }

    public void ShowGameOverMenu()
    {
        GameOverMenu.SetActive(true);
    }

    public void ShowPauseMenu()
    {
        PauseMenu.SetActive(true);
    }

    public void HidePauseMenu()
    {
        PauseMenu.SetActive(false);
    }

    public void ShowFullChargeText()
    {
        FullChargeText.SetActive(true);
    }

    public void HideFullChargeText()
    {
        FullChargeText.SetActive(false);
    }

    public void IncrementChargeUI()
    {
        Debug.Log("CALLED");
        ChargeBar.gameObject.GetComponent<Image>().fillAmount += .1f;
    }

    public void DepleteChargeUI()
    {
        ChargeBar.gameObject.GetComponent<Image>().fillAmount = 0;
    }


}
