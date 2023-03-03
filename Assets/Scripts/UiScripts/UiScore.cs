using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiScore : MonoBehaviour
{
    public static UiScore Instance;
    public int score = 0;
    // Start is called before the first frame update
    private void Awake() =>Instance = this;

    void Start()
    {
        
    }
    public void ChangeScore(int change)
    {
        if (change > 0)
        {
            score += change;
            gameObject.GetComponent<TextMeshProUGUI>().SetText(score.ToString());
        }
        else
        {
            score -= change;
            gameObject.GetComponent<TextMeshProUGUI>().SetText(score.ToString());
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
