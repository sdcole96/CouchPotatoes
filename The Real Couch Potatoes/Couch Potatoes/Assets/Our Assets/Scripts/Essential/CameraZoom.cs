using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{

    public bool isDetached = false;
    public bool atDestination = false;
    public bool zoomIn;
    public float speed;
    public GameObject zoomInObj;
    private Vector3 zoomInVect;
    private Vector3 endPos;
    public Light lightSource;

    // Use this for initialization
    void Start()
    {
        zoomInVect = zoomInObj.gameObject.transform.position;
        endPos = new Vector3(zoomInVect.x, zoomInVect.y, zoomInVect.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(zoomIn)
            ZoomToTV();
    }
    void ZoomToTV()
    {
        if (isDetached && transform.parent != null)
        {
            transform.parent = null; //detach
            lightSource.enabled = true;
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
            transform.LookAt(zoomInObj.gameObject.transform);
        }
    }
}



