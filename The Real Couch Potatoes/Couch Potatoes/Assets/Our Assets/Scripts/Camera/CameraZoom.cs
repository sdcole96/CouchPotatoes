using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {

    public bool isDetached = false;
    public bool atDestination = false;
    public float speed;
    public GameObject tvSet;
    private Vector3 tvPos;
    private Vector3 endPos;

    // Use this for initialization
    void Start () {
        tvPos = tvSet.gameObject.transform.position;
        endPos = new Vector3(tvPos.x, tvPos.y, tvPos.z-2);

    }
	
	// Update is called once per frame
	void Update () {
        if (isDetached && transform.parent != null)
        {
            transform.parent = null; //detach
            Debug.Log("oh we are in the update");
        }
        
        else if (isDetached && !atDestination)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, endPos, step);
            if (transform.position == endPos)
                atDestination = true;
        }
        else if (atDestination)
        {
            transform.LookAt(tvSet.gameObject.transform);
        }
	}
}
