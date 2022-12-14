using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance { get; private set; }
    public int round = 0; // even round build, odd round shoot
    public bool isBuilderRound = true;
    public GameObject hook;
    public TrayController tray;
    static int MAX_ROUNDS = 9;
    
    public AvatarController avatar;

	public GameObject ballPrefab;
	public GameObject avatarPrefab;
    public GameObject winnerPanel;
    public TextMeshProUGUI winnerText;
    static int MAX_BALLS = 5;
    int ballCount = 0;
    GameObject[] balls = new GameObject[MAX_BALLS];
    
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
        if(value > MAX_ROUNDS){
            UIRound.instance.SetRound(MAX_ROUNDS);
            winnerText.text = string.Format("Builder!");
            winnerPanel.active = true;
            return;
        }
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
            balls[ballCount] = ball;
            ballCount++;
        }
        UIRound.instance.SetRound(round);
    }
    public void avatarDies(){
        avatar = null;
        winnerPanel.active = true;
        winnerText.text = string.Format("Shooter!");
        return;
    }
    public void replay(){
        round = 0;
        UIRound.instance.SetRound(0);
        winnerPanel.active = false;
        isBuilderRound = true;
        DeleteAll();
        tray.DeleteAll();
        tray.FillBlocks();
        if(avatar != null){        
            avatar.Reset();
        }
        else{
            GameObject av = Instantiate(avatarPrefab, transform.position, Quaternion.identity);
            av.GetComponent<AvatarController>().Reset();
            avatar = av.GetComponent<AvatarController>();
        }
    }
    void DeleteAll(){
        for(int i=0;i<ballCount;i++){
		    Destroy(balls[i]);
        }
        ballCount = 0;
    }
}
