using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

	public Color selectColor;
	private Color defaultColor;
	private Renderer m_Renderer;
	private GameObject turret;
	BuildManager buildManager;
	void Start () {
		m_Renderer = gameObject.GetComponent<Renderer>();
		defaultColor = m_Renderer.material.color;
		buildManager = BuildManager.instance;
	}
	
	void OnMouseDown()
	{
		if (buildManager.GetTurretToBuild() == null)
		{
			return;
		}
		if (turret != null)
		{
			Debug.Log("can't build there ! -TODO: Display on screen");
			return;
		}
		// build a turret
		GameObject turretToBuild = buildManager.GetTurretToBuild();
		turret = Instantiate (turretToBuild,transform.position,transform.rotation,BuildManager.instance.transform);
	}

	void OnMouseEnter()
	{
		if (EventSystem.current.IsPointerOverGameObject())
		{
			return;
		}
		if (buildManager.GetTurretToBuild() == null)
		{
			return;
		}
		m_Renderer.material.color = selectColor;
	}
	void OnMouseExit()
	{
		m_Renderer.material.color = defaultColor;
	}
}
