using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PPScript : MonoBehaviour
{
    public PostProcessVolume volume;

    private Vignette vig;
    private bool vigBool;
    private int vigIntensity=1;

    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGetSettings(out vig);

        vig.intensity.value = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //ButtonInputs Vignette
        if (Input.GetKeyDown(KeyCode.Return))
        {
            vigBool = true;
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            vigBool = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            vigIntensity = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            vigIntensity = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            vigIntensity = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            vigIntensity = 0;
        }



        if (vigBool) {
            switch (vigIntensity)
            {
                case 1: vig.intensity.value = Mathf.Lerp(vig.intensity.value, 0.55f, 1f * Time.deltaTime);
                    break;
                case 2: vig.intensity.value = Mathf.Lerp(vig.intensity.value, 0.6f, 1f * Time.deltaTime);
                    break;
                case 3: vig.intensity.value = Mathf.Lerp(vig.intensity.value, 0.7f, 1f * Time.deltaTime);
                    break;
                case 0: vig.intensity.value = Mathf.Lerp(vig.intensity.value, .0f, 1f * Time.deltaTime);
                    break;
            }
        }
    }
}
