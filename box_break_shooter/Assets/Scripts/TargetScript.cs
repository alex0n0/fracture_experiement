using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour {

	public float health = 50f;
    public GameObject fracturedCube;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        GameObject fractured = Instantiate(fracturedCube, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(fractured, 5f);
    }
}
