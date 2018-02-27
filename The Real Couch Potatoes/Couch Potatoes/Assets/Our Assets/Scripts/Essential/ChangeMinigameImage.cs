using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeMinigameImage : MonoBehaviour, ISelectHandler
{
    public GameObject ImageObj;  ///set this in the inspector
    public Texture newTextureToChangeTo;
    private RawImage img;

    public Color colorChoice;
    public Light lightToChange;

    void Start()
    {
        //lightToChange = GetComponent<Light>();
    }

    public void OnSelect(BaseEventData eventData)
    {
        img = (RawImage)ImageObj.GetComponent<RawImage>();
        img.texture = (Texture)newTextureToChangeTo;
        lightToChange.color = colorChoice;
    }
}
