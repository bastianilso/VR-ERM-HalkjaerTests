﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelBar : Target {

    private float animationTime = 0.2f;

    private bool feedback = false;
    private float hitTime;

    private SpriteRenderer sprite;
    private bool newHit = false;

    void Awake()
    {
        sprite = this.GetComponent<SpriteRenderer>();
        sprite.color = Color.gray;
    }

    void Update()
    {
        if (feedback)
        {
            if (Time.time - hitTime > animationTime)
            {
                sprite.color = Color.white;

                feedback = false;
            }
        }
    }
    private void OnMouseEnter()
    {
        newHit = true;
    }

    private void OnMouseExit()
    {
        newHit = false;
    }

    public void DeactivateHit()
    {
        newHit = false;
    }

    public bool IsNewHit()
    {
        return newHit;
    }


    public new void SetActiveTarget()
    {
        sprite.color = Color.red;
    }


    public void Cross()
    {
        if (GameManager.GetCurrentTarget() == targetID)
        {
            GameManager.SuccesfulHit();
            PlayFeedback();
        }
        else
        {
            GameManager.ErrorHit(targetID);
        }
    }

    public void SetPosition(int newpos)
    {
        this.transform.position = new Vector3(this.transform.position.x, newpos, this.transform.position.z);
    }

    private void PlayFeedback()
    {
        feedback = true;
        hitTime = Time.time;

        sprite.color = Color.red;
    }

}