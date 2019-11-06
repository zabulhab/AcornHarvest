using System.Collections;
using UnityEngine;

/// <summary>
/// Controls how long this instance of the combo text displays
/// Initializes with current combo count by finding it in the ComboCounter on Start
/// </summary>
public class ComboTextDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int numberToDisplay = FindObjectOfType<ComboCounter>().currentComboCount;
        Debug.Log("Current Combo Count Found: " + numberToDisplay);
        GetComponent<TMPro.TMP_Text>().
            text = numberToDisplay.ToString();
        StartCoroutine(FadeAway());
    }

    private IEnumerator FadeAway()
    {
        yield return new WaitForSecondsRealtime(.1f);
        Destroy(gameObject);
    }
}
