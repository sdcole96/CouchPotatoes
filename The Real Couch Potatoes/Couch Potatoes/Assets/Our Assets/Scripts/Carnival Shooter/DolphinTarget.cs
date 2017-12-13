using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DolphinTarget : MonoBehaviour {

    public Material[] playerColors;
    public GameObject pivot;
    public bool hit = false;
    public int targetsLeft = 4;
    public int pointValue = 50;
    public float speed = 3f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pivot.transform.Rotate(0, 0, 70 * Time.deltaTime);
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    public void ChangeTargetColor(MeshRenderer doplhin, int playerNum)
    {
        doplhin.material = playerColors[playerNum - 1];
    }
}
