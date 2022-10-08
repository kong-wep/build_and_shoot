using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    // Health
    public int maxHealth = 40;
	public float currentHealth = 40f;
	float damageThreshold = 5f;
    // Health Mask
    public Image mask;
    float originalSize;

    // Movement
	private bool isPressed = false;
    Rigidbody2D rigidbody2d;
    
    void Start()
    {
        originalSize = mask.rectTransform.rect.width;
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
    }
    void FixedUpdate()
    {
		if (isPressed)
		{
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
		}
    }

	void OnCollisionEnter2D (Collision2D colInfo)
	{
		if (colInfo.relativeVelocity.magnitude > damageThreshold)
		{
            currentHealth-=colInfo.relativeVelocity.magnitude;
            SetHealthBar(currentHealth / (float)maxHealth);
		}
        if(currentHealth<0){
			Die();
        }
	}
    
	void OnMouseDown ()
	{
        if(PlayerController.instance.isBuilerRound){
		    isPressed = true;
        }
	}

	void OnMouseUp ()
	{
        if(PlayerController.instance.isBuilerRound){
		    isPressed = false;
        }
	}

	void Die ()
	{
		// Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

    void SetHealthBar(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}
