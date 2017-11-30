using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullTarget : MonoBehaviour {

    public Material[] playerColors;
    public GameObject[] seagulls;
    public GameObject pivot;
    public bool hit = false;
    public MeshRenderer target;
    public int pointValue = 50;
    public float speed = 3f;

    // Use this for initialization
    void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		pivot.transform.Rotate (0, 0, -50 * Time.deltaTime);
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        foreach (GameObject sg in seagulls) 
		{
			sg.transform.up = Vector3.up;
		}
	}

    public void ChangeTargetColor(MeshRenderer seagull, int playerNum)
    {
        seagull.material = playerColors[playerNum - 1];

    }
}
