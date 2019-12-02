using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PPScript : MonoBehaviour
{
    public PostProcessVolume volume;

    private Vignette vig;
    private Grain grain;
    private bool vigTimer = true;
    private int setPP;
    private enum EffektEnum { vig =1, grain=2, none=0 };
    private int ppIntensity=1;

    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGetSettings(out vig);
        volume.profile.TryGetSettings(out grain);

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
                ppIntensity = 1;
            }
             else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
              setPP = (int)EffektEnum.grain;
                ppIntensity = 1;
        }
            else if (Input.GetKeyDown(KeyCode.Period))
            {
            ppIntensity++;
            }
            else if (Input.GetKeyDown(KeyCode.Minus))
            {
            ppIntensity--;
        }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {

               // vigIntensity = 4;


            }
        //Post processing aus
        if (setPP == (int)EffektEnum.none)
        {
            vig.intensity.value = Mathf.Lerp(vig.intensity.value, .0f, 1f * Time.deltaTime);
            grain.intensity.value = 0;
        }

        //Vignette
        if (setPP == (int)EffektEnum.vig)
        {
            switch (ppIntensity)
            {
                case 1:
                    vig.intensity.value = Mathf.Lerp(vig.intensity.value, 0.55f, 1f * Time.deltaTime);
                    break;
                case 2:
                    vig.intensity.value = Mathf.Lerp(vig.intensity.value, 0.6f, 1f * Time.deltaTime);
                    break;
                case 3:
                    vig.intensity.value = Mathf.Lerp(vig.intensity.value, 0.7f, 1f * Time.deltaTime);
                    break;

                case 0:
                    vig.intensity.value = Mathf.Lerp(vig.intensity.value, .0f, 1f * Time.deltaTime);
                    break;
                case 4:
                    vig.intensity.value = Mathf.Lerp(vig.intensity.value, 0.65f, 1f * Time.deltaTime);
                    if (vig.intensity.value >= 0.62f)
                    {
                        ppIntensity = 5;
                    }
                    break;
                default:
                    vig.intensity.value = Mathf.Lerp(vig.intensity.value, .5f, 1f * Time.deltaTime);
                    if (vig.intensity.value <= .53f)
                    {
                        ppIntensity = 4;
                    }
                    break;

            }
        }

        //Grain
        if (setPP == (int)EffektEnum.grain)
        {
            switch (ppIntensity)
            {
                default:
                    grain.intensity.value = 0.4f;
                    grain.size.value = 1.0f;
                    ppIntensity = 0;
                    break;
                case 1:
                    grain.intensity.value = 0.7f;
                    grain.size.value = 1.1f;
                    break;
                case 2:
                    grain.intensity.value = 1.5f;
                    break;

            }
        }
    }
}
