using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Turret : MonoBehaviour {

	[Header("Arrtributes")]
	public float fireRate = 5f;// fire float times in one seconds
	public float rotateSpeed = 5f;
	public float fireCountdown = 0;
	public float atkRange = 15f ;
	private Transform target ;
	private Transform firePoint;
	private Transform partToRotate;
	private Vector3 tempDir;
	private GameObject bullet;
	
	void Awake()
	{
		partToRotate = transform.Find("Res");
		firePoint = transform.Find("Res/FirePosition");
		bullet = Resources.Load<GameObject>("Bullet");
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
		Fire();
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
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation
		,Time.deltaTime*rotateSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler(0f,rotation.y,0f);
	}
	private void Fire()
	{
		if (fireCountdown <= 0f)
		{
			Shoot();
			fireCountdown = 1f/fireRate;
		}
		fireCountdown -= Time.deltaTime;
	}
	private void Shoot()
	{
		Transform targetTemp = target;
		GameObject bulletGO = Instantiate(bullet,firePoint.position,firePoint.rotation,transform);
		Bullet bulletScript = bulletGO.GetComponent<Bullet>();
		if (bulletScript != null)
			bulletScript.Seek(target);
	}

}
