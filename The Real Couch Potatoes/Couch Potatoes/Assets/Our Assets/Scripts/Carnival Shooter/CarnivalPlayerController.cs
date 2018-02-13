using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivalPlayerController : MonoBehaviour 
{
	public float speed;
	public int playerNum = -1;
	public bool canHit = true;
    public SpriteRenderer innerCrosshair;
    public Camera mainCam;
	public PlayerIndex controllerNum;
	public CarnivalShootGM GM;

    public AudioClip[] hitSounds;
    public AudioSource audioSource;

	// Use this for initialization
	void Start () 
	{
		GM = GameObject.Find ("Game Manager").GetComponent<CarnivalShootGM> ();
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        audioSource = GetComponent<AudioSource>();
        var bottomLeft = mainCam.ScreenToWorldPoint(Vector3.zero);
        var topRight = mainCam.ScreenToWorldPoint(new Vector3(
            mainCam.pixelWidth, mainCam.pixelHeight));
    }
	
	// Update is called once per frame
	void Update () 
	{

		Vector2 movement = GamePad.GetLeftStick (controllerNum);
		transform.Translate(movement.x * speed, -(movement.y * speed), 0);

		// This keeps the reticle from leaving the screen on the x axis
		if (transform.position.x > 10)
			transform.position = new Vector3 (10f, transform.position.y, transform.position.z);
		else if(transform.position.x < -10)
			transform.position = new Vector3 (-10f, transform.position.y, transform.position.z);

		// This keeps the reticle from leaving the screen on the y axis
		if (transform.position.y > 5)
			transform.position = new Vector3 (transform.position.x, 5f, transform.position.z);
		else if(transform.position.y < -5)
			transform.position = new Vector3 (transform.position.x, -5f, transform.position.z);


		if((GamePad.GetButton(CButton.A, controllerNum) || GamePad.GetButton(PSButton.Cross, controllerNum))&&canHit)
		{
			StartCoroutine(FireRate(1.0f));
			RaycastHit hit;
			Ray ray = new Ray (transform.position, transform.forward);
			if (Physics.Raycast (ray, out hit)) 
			{
                if (hit.collider.tag.Equals("Target"))
                {
                    PlayHitSound();
                    Target targetHit = hit.transform.gameObject.transform.root.GetComponent<Target>();
                    targetHit.hit = true;
                    GM.UpdatePlayerScore(playerNum, targetHit.pointValue);
                    hit.collider.enabled = false;
                    targetHit.ChangeTargetColor(playerNum);
                    Handheld.Vibrate();
                }
                else if (hit.collider.tag.Equals("SeagullTarget"))
                {
                    PlayHitSound();
                    SeagullTarget targetHit = hit.transform.gameObject.transform.root.GetComponent<SeagullTarget>();
                    targetHit.hit = true;
                    GM.UpdatePlayerScore(playerNum, targetHit.pointValue);
                    hit.collider.enabled = false;
                    targetHit.ChangeTargetColor(hit.transform.gameObject.GetComponent<MeshRenderer>(), playerNum);
                    Handheld.Vibrate();
                }
                else if (hit.collider.tag.Equals("DolphinTarget"))
                {
                    PlayHitSound();
                    DolphinTarget targetHit = hit.transform.gameObject.transform.root.GetComponent<DolphinTarget>();
                    targetHit.hit = true;
                    GM.UpdatePlayerScore(playerNum, targetHit.pointValue);
                    hit.collider.enabled = false;
                    targetHit.ChangeTargetColor(hit.transform.gameObject.GetComponent<MeshRenderer>(), playerNum);
                    Handheld.Vibrate();
                }
			}
		} 
	}
	
	public IEnumerator FireRate(float seconds)
	{
        Color playerColor = innerCrosshair.color;
        innerCrosshair.color = Color.gray;
        canHit = false;
		yield return new WaitForSeconds(seconds);
		canHit = true;
        innerCrosshair.color = playerColor;
	}

    public void PlayHitSound()
    {
        //AudioClip hitSound = hitSounds[Random.Range(0, hitSounds.Length)];
        //audioSource.clip = hitSound;
        //audioSource.Play();
    }
}
