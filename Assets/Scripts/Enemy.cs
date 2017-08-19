using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private int wayPointIndex = 0;
	private Transform targetTransfrom;
	private float speed = 10f;
	private Vector3 dir = Vector3.zero;
	void Start () {
		targetTransfrom= WayPoints.wayPoints[0];
	}
	
	// Update is called once per frame
	void Update () {
		EnemyTranslate();
	}
	private void EnemyTranslate()
	{
		dir = targetTransfrom.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime);

		if (Vector3.Distance(transform.position,targetTransfrom.position) <= 0.2f)
		{
			GetNextWayPoint();
		}
	}
	private void GetNextWayPoint()
	{

		// my function
		// if (wayPointIndex == WayPoints.wayPoints.Length - 1)
		// {
		// 	Destroy(gameObject);
		// 	return;
		// }
		// if (wayPointIndex < WayPoints.wayPoints.Length - 1)
		// {
		// 	wayPointIndex++;
		// 	targetTransfrom = WayPoints.wayPoints[wayPointIndex];
		// }
		
		// brackeys function
		if (wayPointIndex >= WayPoints.wayPoints.Length -1)
		{
			WaveSpawner.instance.Enemys.Remove(this);
			Destroy(gameObject);
			return;
		}
		wayPointIndex++;
		targetTransfrom = WayPoints.wayPoints[wayPointIndex];
	}
}
