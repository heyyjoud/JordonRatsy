using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //to create strawberry score bar
    public Image[] score;
    public Sprite fullGoldStrawberry;
    public Sprite emptyGoldStrawberry;

    private int finalScore = Cake.scoreCounter;
    // Cake.scoreCounter = 0;

    //private int chances = 3; 

    void Update()
    {
        //set the images for the score bar (I'm confused on how this is working)
        foreach (Image img in score)
        {
            img.sprite = emptyGoldStrawberry;
        }
        for (int i = 0; i < finalScore; i++)
        {
            score[i].sprite = fullGoldStrawberry;
        }
    }

    public void ResetScore()
    {
        Cake.scoreCounter = 0;
    }

}
