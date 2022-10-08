using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayController : MonoBehaviour
{
    
    public GameObject blockPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateBlock(){
        // Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // TODO move other blocks here
        Vector2 pos = new Vector2(0,0);
        GameObject block = Instantiate(blockPrefab, pos, Quaternion.identity);
    }
}
