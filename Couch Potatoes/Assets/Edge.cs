using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour {

	private Mesh mesh;

	// Use this for initialization
	void Start () 
	{
		mesh = this.GetComponent<Mesh> ();
		Vector3[] verts = mesh.vertices;
		foreach (Vector3 v1 in verts) 
		{
			foreach (Vector3 v2 in verts) 
			{
				if(v1.x == v2.x 
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
