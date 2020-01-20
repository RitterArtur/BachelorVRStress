using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PPScript : MonoBehaviour
{
    public PostProcessVolume volume;

    private Vignette vig;
    VignetteScript vigInstance;
    GrainScript grainInstance;
    private Grain grain;
    private bool vigTimer = true;
    private int setPP;
    private enum EffektEnum { vig =1, grain=2, none=0 };
    private int ppIntensity=1;
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGetSettings(out vig);
        vigInstance = new VignetteScript();

        volume.profile.TryGetSettings(out grain);
        grainInstance = new GrainScript();

        

        vig.intensity.value = 0;
        grain.intensity.value = 0;

    }

    // Update is called once per frame
    void Update()
    {


        //ButtonInputs 
        if (Input.GetKeyDown(KeyCode.Return))
            {
                setPP = (int)EffektEnum.none;
            }
            else if (Input.GetKeyDown(KeyCode.Backspace))
            {
                setPP = (int)EffektEnum.none;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                setPP = (int)EffektEnum.vig;
                
            }
             else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
              setPP = (int)EffektEnum.grain;           
              
            }
            else if (Input.GetKeyDown(KeyCode.Period))
            {
            increaseIntensity();
            }
            else if (Input.GetKeyDown(KeyCode.Minus))
            {
            decreaseIntensity();
        }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {

               // vigIntensity = 4;


            }
        /*

        */

        //Post processing aus
        if (setPP == (int)EffektEnum.none)
        {
            vig.intensity.value = Mathf.Lerp(vig.intensity.value, .0f, 1f * Time.deltaTime);
            grain.intensity.value = 0;
        }

        vig.intensity.value = vigInstance.vignetteValue(vig.intensity.value);

        //Vignette
        if (setPP == (int)EffektEnum.vig)
        {
            
            vig.intensity.value = vigInstance.vignetteValue(vig.intensity.value) ;
        }

        //Grain
        if (setPP == (int)EffektEnum.grain)
        {
            grain = grainInstance.grainValue(grain); 
        }
    }

    void increaseIntensity()
    {
        if (setPP == (int)EffektEnum.vig)
        {
            vigInstance.increaseVignette();

        }else if(setPP == (int)EffektEnum.grain)
        {
            grainInstance.increaseGrain();
        }
    }

    void decreaseIntensity()
    {
        if (setPP == (int)EffektEnum.vig)
        {
            vigInstance.decreaseVignette();
        }
        else if (setPP == (int)EffektEnum.grain)
        {
            grainInstance.decreaseGrain();
        }
    }
}
