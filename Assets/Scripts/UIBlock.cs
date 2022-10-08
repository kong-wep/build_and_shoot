using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class UIBlock : MonoBehaviour,IDragHandler 
{
    public bool isDraggable = true;
    public GameObject blockPrefab;
    bool isDragging = false;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0)){
            if(isDragging){
                // release
                isDraggable = false;
                isDragging = false;
                Vector2 pos = Camera.main.ScreenToWorldPoint(transform.position);
                GameObject block = Instantiate(
                    blockPrefab, pos, Quaternion.identity);
		        Destroy(gameObject);
            }
        }
        
    }
    public void OnDrag (PointerEventData eventData)
    {
        if(isDraggable){
            this.transform.position += (Vector3)eventData.delta;
            isDragging = true;
        }
    }
}
