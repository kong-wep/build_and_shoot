using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance { get; private set; }
    public int round = 0; // even round build, odd round shoot
    public bool isBuilderRound = true;
    public GameObject hook;
    public TrayController tray;
    
	public GameObject ballPrefab;
    
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        UIRound.instance.SetRound(0);
        tray.FillBlocks();
    }

    void Update()
    {
        
    }

    public void changeRound(int value){
        round = value;
        if(round % 2 == 0){
            isBuilderRound = true;
            tray.FillBlocks();
        }
        else{
            isBuilderRound = false;
            // gen new ball
            GameObject ball = Instantiate(ballPrefab, hook.GetComponent<Transform>().position, Quaternion.identity,transform);
            ball.GetComponent<SpringJoint2D>().connectedBody = hook.GetComponent<Rigidbody2D>();
            ball.GetComponent<Ball>().hook = hook.GetComponent<Rigidbody2D>();
        }
        UIRound.instance.SetRound(round);
    }
}
