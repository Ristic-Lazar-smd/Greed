using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UiTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timer;
    public string timerFormatted;

    void Update()
    {
        timerFormatted =((((int)Time.timeSinceLevelLoad) / 60).ToString("00") + ":" + (((int)Time.timeSinceLevelLoad) % 60).ToString("00"));
        timerText.SetText(timerFormatted);
    }
}
