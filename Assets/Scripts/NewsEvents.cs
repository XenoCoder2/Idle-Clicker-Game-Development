using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsEvents : MonoBehaviour
{
    public Text newsText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public enum NewsStates
{
    Calm, 
    Curious, 
    Scientific,
    Foreboding,
    Unsettled, 
    Fishy, 
    Fishmageddon, 
}