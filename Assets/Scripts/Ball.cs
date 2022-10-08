using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	public Rigidbody2D rb;
	public Rigidbody2D hook;

	public float releaseTime = .15f;
	public float maxDragDistance = 2f;

	private bool isPressed = false;
	LineRenderer line;
	void Start(){
		line = GetComponent<LineRenderer>();
		line.enabled = true;
	}
	void Update ()
	{
		if (isPressed)
		{
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if (Vector3.Distance(mousePos, hook.position) > maxDragDistance)
				rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;
			else
				rb.position = mousePos;
		}
		line.SetPosition(0,transform.position);
		line.SetPosition(1,hook.position);
	}

	void OnMouseDown ()
	{
		if(PlayerController.instance.isBuilderRound)
			return;
		isPressed = true;
		rb.isKinematic = true;
	}

	void OnMouseUp ()
	{
		if(PlayerController.instance.isBuilderRound)
			return;
		isPressed = false;
		rb.isKinematic = false;

		StartCoroutine(Release());
	}

	IEnumerator Release ()
	{
		yield return new WaitForSeconds(releaseTime);

		GetComponent<SpringJoint2D>().enabled = false;
		line.enabled = false;
		this.enabled = false;

		// yield return new WaitForSeconds(2f);
	
	}
}
