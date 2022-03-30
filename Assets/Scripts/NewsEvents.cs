using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsEvents : MonoBehaviour
{
    public Text newsText;
    public static NewsStates news;

    // Update is called once per frame
    void Update()
    {
        switch (news)
        {
            case NewsStates.Calm:
                newsText.text = "It's a lovely morning in Missifishy, ripe for flipping!";
                break;
            case NewsStates.Curious:
                newsText.text = "Reports say that the world has been invaded by a sentient species of Blobfish.";
                break;
            case NewsStates.RandomFact1:
                newsText.text = "Did you know that Trout are closely related to Salmon?";
                break;
            case NewsStates.Scientific:
                newsText.text = "New breakthroughs in science have shown that flipping a Trout fast enough can create a black-hole!";
                break;
            case NewsStates.Foreboding:
                newsText.text = "\"Those darned Trouts warped my house out of existence!\", angry local claims.";
                break;
            case NewsStates.WeatherReport:
                newsText.text = "The forecast for today indicates a slight chance of Fishmageddon this afternoon.";
                break;
            case NewsStates.RandomFact2:
                newsText.text = "Did you know that Trout have teeth on the roof of the mouth called 'Vomerine Teeth'?";
                break;
            case NewsStates.Fishy:
                newsText.text = "\"My best friend was replaced by a Blobfish!\", local conspiracy theorist claims.";
                break;
            case NewsStates.Fishmageddon:
                newsText.text = "Reports indicate millions of Piranhas launching into space in miniature space craft.";
                break;
            case NewsStates.ItHasEmerged:
                newsText.text = "A tear in reality has caused thousands of fish to fall out from the void, locals say.";
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
    RandomFact1,
    Scientific,
    Foreboding,
    WeatherReport,
    RandomFact2,
    Fishy, 
    Fishmageddon, 
    ItHasEmerged
}