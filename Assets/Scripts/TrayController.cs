using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrayController : MonoBehaviour
{
    static int MAX_BLOCKS = 10;

    public GameObject blockPrefab;
    
    RectTransform rectTransform;

    GameObject[] blocks = new GameObject[MAX_BLOCKS+10];
    int blockCount = 0;

    GameObject[] gameBlocks = new GameObject[MAX_BLOCKS*2];
    int gameBlockCount = 0;
    
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
    }
    public void GiveBlock(){
        if(blockCount <= 0){
            return;
        }
        GameObject blockObject = blocks[blockCount-1];
        blockCount-=1;
        UIBlock blockScript = blockObject.GetComponent<UIBlock>();
        blockObject.GetComponent<Image>().color = new Color(1,1,1,1);
        blockScript.isDraggable = true;
        blockScript.tray = this;
    }
    public void FillBlocks(){
        int blockNum = 3;
        float length = rectTransform.sizeDelta.x;
        for(int i=0;i<blockNum;i++){
            Vector2 newPos = new Vector2(transform.position.x+(length*(i+1)/(blockNum+1)),transform.position.y);
            CreateBlock(newPos);
        }
        GiveBlock();
    }

    int CreateBlock(Vector2 pos){ // return index or -1
        // TODO move other blocks here
        if(blockCount >= MAX_BLOCKS)
            return -1;
        GameObject block = Instantiate(blockPrefab, pos, Quaternion.identity,transform);
        blocks[blockCount] = block;
        blockCount++;
        return blockCount-1;
    }

    public void addGameBlock(GameObject block){
        gameBlocks[gameBlockCount] = block;
        gameBlockCount++;
    }

    public void DeleteAll(){
        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);
        }
        for(int i=0;i<blockCount;i++){
		    Destroy(blocks[i]);
            blocks[i] = null;
        }
        for(int i=0;i<gameBlockCount;i++){
		    Destroy(gameBlocks[i]);
            gameBlocks[i] = null;
        }
        blockCount = 0;
        gameBlockCount = 0;
    }
}
