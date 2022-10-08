using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIRound : MonoBehaviour
{
    public static UIRound instance { get; private set; }
    public TextMeshProUGUI TMP_text;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
    }
    public void SetRound(int value)
    {
        TMP_text.text = string.Format("Round {0}",value+1);
    }
}
