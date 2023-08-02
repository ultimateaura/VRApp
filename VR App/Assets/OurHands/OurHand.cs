using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class OurHand : MonoBehaviour
{
    //public values to set in Unity, private used only in script
    public GameObject ourHandPrefab;
    public InputDeviceCharacteristics ourControllerCharacteristics;

    private InputDevice ourDevice;

// Start is called before the first frame update
    void Start()
    {
        InitializeOurHand();
    }

    void InitializeOurHand()
    {
        //check for our controllers characteristics
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(ourControllerCharacteristics, devices);

        //if device identified, instantantiate a hand
        if (devices.Count > 0)
        {
            ourDevice = devices[0];

            GameObject newHand = Instantiate(ourHandPrefab, transform);
        }
    }

    void Update()
    {
        //change animate position or re-initialize
        if (ourDevice.isValid)
        {
            UpdateOurHand();
        }
        else 
        {
            InitializeOurHand();
        }
    }

    void UpdateOurHand()
    {
        if (ourDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            Debug.Log("Trigger Value =" + triggerValue);
        }
        else
        {
            Debug.Log("Trigger not Active");
        }

        if (ourDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            Debug.Log("Grip Value = " + gripValue);

        }
        else
        {
            Debug.Log("Grip not Active");
        }
    }
}
