//https://gist.github.com/ftvs/5822103

using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	public Transform camTransform;

	// How long the object should shake for.
	public float shakeDuration = 0f;

	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;
	public bool wait = true;


	Vector3 originalPos;

	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
		StartCoroutine (shake ());
	}

	void OnEnable()
	{
		originalPos = camTransform.localPosition;
	}

	void Update()
	{
		if (wait == false) {
			if (shakeDuration > 0) {
				camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

				shakeDuration -= Time.deltaTime * decreaseFactor;
			} else {
				shakeDuration = 0f;
				camTransform.localPosition = originalPos;
			}
		}
	}

	IEnumerator shake()
	{
		yield return new WaitForSeconds (1f);
		wait = false;
	}
}