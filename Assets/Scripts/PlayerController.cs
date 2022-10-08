using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance { get; private set; }
    public int round = 0; // even round build, odd round shoot
    public bool isBuilderRound = true;
    
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        UIRound.instance.SetRound(0);
    }

    void Update()
    {
        
    }

    public void changeRound(int value){
        round = value;
        if(round % 2 == 0){
            isBuilderRound = true;
        }
        else{
            isBuilderRound = false;
            // gen new ball
        }
        UIRound.instance.SetRound(round);
    }
}
