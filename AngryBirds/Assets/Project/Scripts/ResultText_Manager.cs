using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultText_Manager : MonoBehaviour
{
    public TextMeshProUGUI resultText;

    void Start()
    {
        if(Cake.scoreCounter == 3)
        {
            resultText.text = "WooHoo!";
        }
        else if(Cake.scoreCounter == 2)
        {
            resultText.text = "So Close D;";
        }
        else if(Cake.scoreCounter == 1)
        {
            resultText.text = "Getting there!";
        }
        else
        {
            resultText.text = "Ouch!";
        }
    }

}
