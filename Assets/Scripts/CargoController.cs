using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoController : MonoBehaviour
{
    
    private string[] colors = new []{"#32a852", "#4287f5", "#fcba03", "#eb4034"};
    
    
    // Start is called before the first frame update
    void Start()
    {
        ColorUtility.TryParseHtmlString(colors[Random.Range(0, colors.Length)], out var randColor);
        GetComponent<Renderer>().material.color = randColor;
    }
}
