using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiHpPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    TextMeshProUGUI text;

    public void UiChangeHp(int hp)
    {
        if (hp<=0) SceneManager.LoadScene("DeathScene");
        text = GetComponent<TextMeshProUGUI>();
        text.SetText(hp.ToString());
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
