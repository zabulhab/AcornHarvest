using System.Collections;
using UnityEngine;

/// <summary>
/// Controls how long this instance of the miss text displays
/// </summary>
public class MissTextDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeAway());
    }

    private IEnumerator FadeAway()
    {
        yield return new WaitForSecondsRealtime(.2f);
        Destroy(gameObject);
    }
}
