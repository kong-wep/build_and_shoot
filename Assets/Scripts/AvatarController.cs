using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController : MonoBehaviour
{
    // Health
    public int maxHealth = 40;
	public float currentHealth = 40f;
	float damageThreshold = 2f;

    // Movement
    Rigidbody2D rigidbody2d;
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
	void OnCollisionEnter2D (Collision2D colInfo)
	{
        if(PlayerController.instance.isBuilderRound)
            return;
		if (colInfo.relativeVelocity.magnitude > damageThreshold)
		{
            currentHealth-=colInfo.relativeVelocity.magnitude;
            UIHealth.instance.SetValue(currentHealth/maxHealth);
		}
        if(currentHealth<0){
			Die();
        }
	}
	void Die ()
	{
		// Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
