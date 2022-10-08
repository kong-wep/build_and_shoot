using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class UIBlock : MonoBehaviour,IDragHandler 
{
    public TrayController tray;
    public bool isDraggable = false;
    public GameObject blockPrefab;
    bool isDragging = false;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0)){
            if(isDragging && PlayerController.instance.isBuilderRound){
                // release
                isDraggable = false;
                isDragging = false;
                Vector2 pos = Camera.main.ScreenToWorldPoint(transform.position);
                GameObject block = Instantiate(
                    blockPrefab, pos, Quaternion.identity);
		        Destroy(gameObject);
                tray.addGameBlock(block);
                tray.GiveBlock();
            }
        }
        
    }
    public void OnDrag (PointerEventData eventData)
    {
        if(isDraggable && PlayerController.instance.isBuilderRound){
            this.transform.position += (Vector3)eventData.delta;
            isDragging = true;
        }
    }
}
