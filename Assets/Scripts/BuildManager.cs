using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;
	private GameObject turretToBuild;
	private GameObject standardTurretPrefab;
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
	void Start()
	{
		turretToBuild = standardTurretPrefab;
	}
	public GameObject GetTurretToBuild()
	{
		return turretToBuild;
	}
}
