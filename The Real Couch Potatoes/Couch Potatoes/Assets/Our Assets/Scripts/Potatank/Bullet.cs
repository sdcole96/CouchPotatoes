using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 10f;
	public GameObject explosion;

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
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Tank")
		{
			TankController tc = col.gameObject.GetComponentInParent<TankController> ();
			GameObject exp = Instantiate (explosion, this.gameObject.transform);
			exp.transform.parent = null;
			tc.life--;
			tc.Hit ();
			Destroy (this.gameObject);
			Debug.Log ("Destory");
		}
		else
		{
			Destroy (this.gameObject);
		}
	}
}
