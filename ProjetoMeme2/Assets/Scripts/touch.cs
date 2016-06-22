﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class touch : MonoBehaviour {

	public GameObject VaiEVem, RegiaoAlvo, BamBamObject;
    public Slider EnergyBar;
	public float CountToPowerUp;
    private float newY;
    private Vector3 newScale;
    public int maxEnergy = 4;
    private bool CanStop = true;
    private bool AlreadyTouched = false;
    public float ScaleSpeed = 0.2f;
    public float ReferencePosition = 0.5f;
    private float lerpTime = 3f;
    private float currentLerpTime = 0f;
    private float perc;
    private float xPosition;

	public void Stop(){
        ///*
        if (CanStop)
        {
            xPosition = VaiEVem.transform.position.x;

            if (xPosition >= (-1) * ReferencePosition && xPosition <= ReferencePosition)
            {
                if (!AlreadyTouched)
                {
                    AlreadyTouched = true;
                    // x = x+0.5f;
                    //Debug.Log("Yay");
                    //Barrinha2.transform.localScale += new Vector3(0,x,0);
                    Debug.Log(VaiEVem.transform.position.x);
                    Debug.Log("hello dear");
                    EnergyBar.value += 1 / CountToPowerUp;
                    GetComponent<ScoreManager>().AddScore(1);
                    BamBamObject.GetComponent<Animator>().SetBool("WantMore", true);
                }
            }
            else
            {
                AlreadyTouched = false;
            }
        }
        //*/
    }
    public void PowerUpTouch()
    {
        if (!CanStop)
        {
            GetComponent<ScoreManager>().AddScore(1);
        }
    }

    public void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Stop();
        }

        //<!-- consume energy
        if(EnergyBar.value == 1)
        {
            //Debug.Log("hello");
            BamBamObject.GetComponent<Animator>().SetBool("IsPowerUpActive", true);

            CanStop = false;
        }
        if(!CanStop)
        {
            //Debug.Log("hello2");
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
            }
            perc = currentLerpTime / lerpTime;
            EnergyBar.value = Mathf.Lerp(1, 0, perc);
            if(EnergyBar.value == 0)
            {
                CanStop = true;
                currentLerpTime = 0;
                BamBamObject.GetComponent<Animator>().SetBool("IsPowerUpActive", false);
            }
        }
        // -->
    } 
}