using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public GameObject timerObj;
    public bool timerOn = false;
    public TMP_Text timerText;
    public int timeSeconds = 0;
    public int fastestTime = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            timerOn = !timerOn;
            if(timerOn == true)
            {
                StartCoroutine(Timer());
            }
            else
            {
                StopAllCoroutines();
                fastestTime = -1;
                timeSeconds = 0;
            }
        }
        if (timerOn == true)
        {
            timerObj.SetActive(true);
            timerText.text = $"Time: {timeSeconds}";
        }
        else
        {
            timerObj.SetActive(false);
        }
    }

    public IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        timeSeconds += 1;
        StartCoroutine(Timer());
    }

    public void ResetTimer()
    {
        StopCoroutine(Timer());
        if(fastestTime == -1)
        {
            fastestTime = timeSeconds;
            StartCoroutine(ColorChangeTime());
        }
        else if(timeSeconds <= fastestTime)
        {
            fastestTime = timeSeconds;
            StartCoroutine(ColorChangeTime());
        }
        timeSeconds = 0;
    }

    public IEnumerator ColorChangeTime()
    {
        timerText.color = Color.green;
        yield return new WaitForSeconds(1);
        timerText.color = Color.white;
    }
}
