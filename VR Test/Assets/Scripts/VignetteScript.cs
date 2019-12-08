using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VignetteScript 
{
    int vigIntensity;
    private const int MAX = 5;


    public float vignetteValue(float current)
    {
        
            float val = 0;
            switch (vigIntensity)
            {

                case 1:
                     return  Mathf.Lerp(current, 0.55f, 1f * Time.deltaTime);
                  
                case 2:
                     return Mathf.Lerp(current, 0.6f, 1f * Time.deltaTime);
               
                case 3:
                    return Mathf.Lerp(current, 0.7f, 1f * Time.deltaTime);
                 

                case 0:
                    return Mathf.Lerp(current, .0f, 1f * Time.deltaTime);
                 
                case 4:
                    val = Mathf.Lerp(current, 0.65f, 1f * Time.deltaTime);
                    if (current >= 0.62f)
                    {
                        this.vigIntensity = 5;
                    }
                    break;
                default:
                    val = Mathf.Lerp(current, .5f, 1f * Time.deltaTime);
                    if (val <= .53f)
                    {
                        this.vigIntensity = 4;
                    }
                    break;

            }
            return val;
        
    }

    public void setIntensity(int v)
    {
        this.vigIntensity = v;
    }

    public void increaseVignette()
    {
        if (this.vigIntensity <= MAX)
        {
            this.vigIntensity++;
        }
    }

    public void decreaseVignette()
    {
        if (this.vigIntensity>0) {
            this.vigIntensity--;
        }
    }


}


