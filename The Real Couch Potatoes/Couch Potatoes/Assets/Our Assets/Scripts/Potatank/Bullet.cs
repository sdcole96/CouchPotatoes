using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 10f;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(DestroyBullet());
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Tank")
		{
			TankController tc = col.gameObject.GetComponent<TankController> ();
			tc.life--;
			tc.Hit ();
		}
	}
}
