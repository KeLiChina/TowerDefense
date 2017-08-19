using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Turret : MonoBehaviour {

	public Transform target ;
	private float atkRange = 15f ;
	private Transform partToRotate;
	private Vector3 tempDir;
	private float rotateSpeed = 5f;
	void Awake()
	{
		partToRotate = transform.Find("Res");
	}
	void Start () {
		InvokeRepeating("UpdateAtkTarget",0f,0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null)
		{
			return;
		}
		RotateToTarget();
		Debug.DrawLine(transform.position,target.position,Color.green);
	}
	private void UpdateAtkTarget()
	{
		float shotestDistance = Mathf.Infinity;
		foreach (var one in WaveSpawner.instance.Enemys)
		{
			float distance = Vector3.Distance(transform.position,one.transform.position);
			if ( distance < shotestDistance)
			{
				shotestDistance = distance;
				target = one.transform;
			}
		}
		if (shotestDistance > atkRange)
		{
			target = null;
		}
	}
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position,atkRange);
	}
	private void RotateToTarget()
	{
		tempDir = -transform.position + target.position;
		Quaternion lookRotation = Quaternion.LookRotation(tempDir);
		// Vector3 rotation = lookRotation.eulerAngles;
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation,Time.deltaTime*rotateSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler(0f,rotation.y,0f);
	}
}
