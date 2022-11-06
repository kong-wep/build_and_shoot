using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector : MonoBehaviour
{
    LineRenderer line1;
    LineRenderer line2;
    Rigidbody2D rigidbody;
    // Start is called before the first frame update
    LineRenderer createLine(Color c){
        GameObject l = new GameObject();
        l.AddComponent<LineRenderer>();
        LineRenderer lr = l.GetComponent<LineRenderer>();
        lr.startColor = c;
        lr.endColor = c;
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.sortingOrder = 2;
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        l.transform.SetParent(transform, false);
        l.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        return l.GetComponent<LineRenderer>();
    }
    void Start()
    {
        line1 = createLine(new Color(0,1,0,1));
        line2 = createLine(new Color(1,0,0,1));
        rigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(line1);
        line1.SetPosition(0, new Vector2(transform.position.x,transform.position.y));
        line1.SetPosition(1, new Vector2(transform.position.x,transform.position.y-(rigidbody.gravityScale)));
        
        line2.SetPosition(0, new Vector2(transform.position.x,transform.position.y));
        line2.SetPosition(1, new Vector2(transform.position.x+(rigidbody.velocity.x),transform.position.y+(rigidbody.velocity.y)));
    }
}
