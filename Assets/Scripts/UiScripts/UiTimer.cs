using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class UiTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timer;
    public string timerFormatted;
    public Image timerImage;
    public Animator timerAnimation;

    public Sprite timer1;
    public Sprite timer2;
    public Sprite timer3;


    void Update()
    {
        timerFormatted = ((((int)Time.timeSinceLevelLoad) / 60).ToString("00") + ":" + (((int)Time.timeSinceLevelLoad) % 60).ToString("00"));
        timerText.SetText(timerFormatted);


        if (Time.timeSinceLevelLoad > 14.0f)
        {
            timerImage.sprite = timer1;
        }

        if (Time.timeSinceLevelLoad > 29.0f)
        {
            timerImage.sprite = timer2;
        }

        if (Time.timeSinceLevelLoad > 44.0f)
        {
            timerImage.sprite = timer3;
        }

        if (Time.timeSinceLevelLoad > 59.0f)
        {
            timerAnimation.enabled = true;
        }

    }
}
