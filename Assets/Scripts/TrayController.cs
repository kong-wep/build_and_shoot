using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayController : MonoBehaviour
{
    static int MAX_BLOCKS = 10;

    public GameObject blockPrefab;
    GameObject[] blocks = new GameObject[MAX_BLOCKS];
    int block_count = 0;
    // Start is called before the first frame update
    void Start()
    {
        CreateBlock();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            CreateBlock();
        }
    }
    int CreateBlock(){ // return index or -1
        // TODO move other blocks here
        if(block_count >= MAX_BLOCKS)
            return -1;
        Vector2 pos = new Vector2(0,0);
        GameObject block = Instantiate(blockPrefab, pos, Quaternion.identity,transform);
        blocks[block_count] = block;
        block_count++;
        return block_count-1;
    }
}
