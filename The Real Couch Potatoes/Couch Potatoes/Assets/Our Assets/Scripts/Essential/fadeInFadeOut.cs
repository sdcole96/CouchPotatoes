using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeInFadeOut : MonoBehaviour {

    public Image whiteScreen;
    public float fadeDuration;

	// Use this for initialization
	void Start () {
        whiteScreen.enabled = true;
        whiteScreen.canvasRenderer.SetAlpha(0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FadeIn()
    {
        whiteScreen.CrossFadeAlpha(1.0f, fadeDuration, true);
    }

    public void FadeOut()
    {
        whiteScreen.CrossFadeAlpha(0.0f, fadeDuration, true);
    }
}
