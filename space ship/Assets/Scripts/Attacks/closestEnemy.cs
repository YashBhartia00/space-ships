using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closestEnemy : MonoBehaviour {
	
	private Vector2 direction;
	private Rigidbody2D rb;
	[SerializeField] private float speed = 6f;
	// Use this for initialization
	public bool follow;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		if(transform.gameObject.tag == "Follow")
		{
			follow = true;
		} else
		{
			follow = false;
		}
	}

	void Update () {
		if (follow)
		{
			direction = FindClosestEnemy().transform.position - this.transform.position;
			rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
		}
	}
	//"enemy" to be replaced with script of your enemy object
	enemy FindClosestEnemy()
	{
		float distanceToClosestEnemy = Mathf.Infinity;
		enemy closestEnemy = null;
		enemy[] allEnemies = GameObject.FindObjectsOfType<enemy>();

		foreach(enemy currentEnemy in allEnemies)
		{
			float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
			if(distanceToEnemy < distanceToClosestEnemy)
			{
				distanceToClosestEnemy = distanceToEnemy;
				closestEnemy = currentEnemy;
			}
		}

		return closestEnemy;
	}
}
