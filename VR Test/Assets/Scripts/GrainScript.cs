using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GrainScript 
{
    int grainIntensity;
    private const int MAX = 2;

    public Grain grainValue(Grain grain)
    {
        switch (grainIntensity)
        {
            case 0:
                grain.intensity.value = 0.0f;
                grain.size.value = 1.1f;
                return grain;
            case 1:
                grain.intensity.value = 0.7f;
                grain.size.value = 1.1f;
                return grain;
            case 2:
                grain.intensity.value = 1.5f;
                return grain;
            default:
                grain.intensity.value = 0.4f;
                grain.size.value = 1.0f;
                return grain;


        }
    }
    public void resetIntensity()
    {
        this.grainIntensity = 1;
    }

    public void setIntensity(int v)
    {
        this.grainIntensity = v;
    }

    public void increaseGrain()
    {
        if (this.grainIntensity < MAX)
        {
            this.grainIntensity++;
        }
    }

    public void decreaseGrain()
    {
        if (this.grainIntensity > 0)
        {
            this.grainIntensity--;
        }
    }
}
