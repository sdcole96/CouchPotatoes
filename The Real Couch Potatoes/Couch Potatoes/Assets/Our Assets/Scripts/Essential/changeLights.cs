using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeLights : MonoBehaviour {
    private Light lightSource;
    private float duration = 0.1f;
    public float delay;
    public bool running = false;


	// Use this for initialization
	void Start () {
        lightSource = GetComponent<Light>();
        StartCoroutine("beginFlash");

	}
	
	// Update is called once per frame
	void Update () {
        if(running)
        {
            
            float phiT = Time.time / duration+delay * 2 * Mathf.PI;
            float amp = Mathf.Cos(phiT) * 0.5F + 0.5F;
            lightSource.intensity = amp;
            

        }
        
    }

    IEnumerator beginFlash()
    {
        yield return new WaitForSeconds(delay);
        running = true;
    }


}
