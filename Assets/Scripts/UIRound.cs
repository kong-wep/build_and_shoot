using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIRound : MonoBehaviour
{
    public static UIRound instance { get; private set; }
    public TextMeshProUGUI TMP_text;
    public Image[] indicators;

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
        for(int i=0;i<indicators.Length;i++){
            if(i == value){
                indicators[i].color = new Color(1,1,1,1);
            }
            else if(i < value){
                indicators[i].color = new Color(0,0,0,1);
            }
            else{
                if(i % 2 == 0){
                    indicators[i].color = new Color(1,1,0,1); //yellow
                }
                else{
                    indicators[i].color = new Color(1,0,0,1); // red
                }
            }
        }
    }
}
