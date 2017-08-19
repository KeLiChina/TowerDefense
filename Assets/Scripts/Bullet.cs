using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 70f;
    private Transform target;
    private Vector3 dirTemp;
	private GameObject BulletImpact;

    void Awake()
	{
		BulletImpact = Resources.Load<GameObject>("BulletImpact");
	}
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
		
		Shoot();

    }
    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Shoot()
    {
        dirTemp = target.position - transform.position;
		float distanceofoneframe = Time.deltaTime*speed;
		if (dirTemp.magnitude <= distanceofoneframe)
		{
			
			HitTarget();
			return;
		}
        dirTemp = dirTemp.normalized;
        transform.Translate(dirTemp * distanceofoneframe,Space.World);
	
    }
	private void HitTarget()
	{
		GameObject effect = Instantiate(BulletImpact,transform.position,transform.rotation);
		Destroy(effect,4f);
		Destroy(gameObject);
	}
}
