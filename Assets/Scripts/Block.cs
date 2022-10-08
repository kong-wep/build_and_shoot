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
	// private bool isPressed = false;
    Rigidbody2D rigidbody2d;
    // private bool built = false;
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
    }

	void OnCollisionEnter2D (Collision2D colInfo)
	{
        if(PlayerController.instance.isBuilderRound)
            return;
		if (colInfo.relativeVelocity.magnitude > damageThreshold)
		{
            currentHealth-=colInfo.relativeVelocity.magnitude;
            SetHealthBar(currentHealth / (float)maxHealth);
		}
        if(currentHealth<0){
			Die();
        }
	}

	void Die ()
	{
		Destroy(gameObject);
	}

    void SetHealthBar(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}
