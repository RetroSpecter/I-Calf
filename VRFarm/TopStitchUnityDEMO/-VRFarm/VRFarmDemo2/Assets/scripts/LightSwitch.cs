using UnityEngine;
using System.Collections;

public class LightSwitch : MonoBehaviour
{
   // Set bulb on and off materials //

    public Material lightMat1ON;
    public Material lightMat1OFF;
    public Material lightMat2ON;
    public Material lightMat2OFF;
    public Material lightMat3ON;
    public Material lightMat3OFF;
    public Material filamentOFF;
    private Material filamentInit;

    public Light lightSource;
    public GameObject bulb;
    public GameObject filament;

    Material[] temp;

    // Set new material array to bulb material array and reference 'temp' instead of 'bulb' //

    void Start()
    {
        
        temp = bulb.GetComponent<Renderer>().materials;
        temp[2] = lightMat1ON;
        temp[0] = lightMat2ON;
        temp[1] = lightMat3ON;
        filamentInit = filament.GetComponent<Renderer>().material;

    }

    // Light Source toggle //

    void OnMouseDown()
    {
        lightSource.enabled = !lightSource.enabled;
    }

    // Check if light source is on or off and swap materials accordingly //
   
    void Update()
    {

        if (lightSource.enabled)
        {
            temp[2] = lightMat1ON;
            temp[0] = lightMat2ON;
            temp[1] = lightMat3ON;
            bulb.GetComponent<Renderer>().materials = temp;
            filament.GetComponent<Renderer>().material = filamentInit;
        }
        else
        {
           temp[2] = lightMat1OFF;
           temp[0] = lightMat2OFF;
           temp[1] = lightMat3OFF;
           bulb.GetComponent<Renderer>().materials = temp;
           filament.GetComponent<Renderer>().material = filamentOFF;
            }

    }
}