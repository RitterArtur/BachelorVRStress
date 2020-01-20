using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class VRCamerascript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rig;
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            rig.SetActive(false);
            rig.SetActive(true);
        }
    }
}
