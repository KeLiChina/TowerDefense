using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;
	public GameObject standardTurretPrefab;
	public GameObject anotherTurretPrefab;
	private GameObject turretToBuild;
	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
		standardTurretPrefab = Resources.Load<GameObject>("BloodEyeTurret");
	}
	public GameObject GetTurretToBuild()
	{
		return turretToBuild;
	}
	public void SetTurretToBuild(GameObject turret)
	{
		turretToBuild = turret;
	}
}
