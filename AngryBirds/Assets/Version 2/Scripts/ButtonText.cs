using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonText : MonoBehaviour
{
    // this script allows for button text to appear on hover over button

    public GameObject buttonText;

    // Start is called before the first frame update
    void Start()
    {
        buttonText.SetActive(false);
    }

    public void OnMouseOver()
    {
        buttonText.SetActive(true);
    }

    public void OnMouseExit()
    {
        buttonText.SetActive(false);
    }    

}
