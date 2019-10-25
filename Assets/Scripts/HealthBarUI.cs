using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Called when acorn missed. Changes health UI length.
    public void DepleteHealth()
    {
        gameObject.GetComponent<Image>().fillAmount -= .1f;

    }
}
