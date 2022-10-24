using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    float currentTime;
    float startTime = 5f;
    public TextMeshProUGUI textMeshComponent;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;

        if(currentTime > 1) 
            textMeshComponent.text = currentTime.ToString("0");
        else
        {   currentTime = 0;            
            gameObject.SetActive(false);
        }
    }
}
