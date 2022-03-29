using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsEvents : MonoBehaviour
{
    public Text newsText;
    public NewsStates news;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (news)
        {
            case NewsStates.Calm:
                break;
            case NewsStates.Curious:
                break;
            case NewsStates.Scientific:
                break;
            case NewsStates.Foreboding:
                break;
            case NewsStates.Unsettled:
                break;
            case NewsStates.Fishy:
                break;
            case NewsStates.Fishmageddon:
                break;
            case NewsStates.ItHasEmerged:
                break;
            default:
                break;
        }
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
    ItHasEmerged
}