using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance { get; private set; }
    public int round = 0; // even round build, odd round shoot
    public bool isBuilerRound = true;
    
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
    }

    void Update()
    {
        
    }

    void changeRound(int value){
        if(value % 2 == 0){
            isBuilerRound = true;
        }
        else{
            isBuilerRound = false;
        }
        UIRound.instance.SetRound(value);
    }
}
