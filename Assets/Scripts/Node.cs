using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

	public Color selectColor;
	private Color defaultColor;
	private Renderer m_Renderer;
	private GameObject turret;
	void Start () {
		m_Renderer = gameObject.GetComponent<Renderer>();
		defaultColor = m_Renderer.material.color;
	}
	
	void OnMouseDown()
	{
		if (turret != null)
		{
			Debug.Log("can't build there ! -TODO: Display on screen");
			return;
		}
		// build a turret
		GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
		turret = Instantiate (turretToBuild,transform.position,transform.rotation,BuildManager.instance.transform);
	}

	void OnMouseEnter()
	{
		m_Renderer.material.color = selectColor;
	}
	void OnMouseExit()
	{
		m_Renderer.material.color = defaultColor;
	}
}
