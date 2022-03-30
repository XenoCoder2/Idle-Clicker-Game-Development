using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsEvents : MonoBehaviour
{
    public Text newsText;
    public static NewsStates news;
    public static int newsNumber;

    // Update is called once per frame
    void Update()
    {
        switch (news)
        {
            case NewsStates.Calm:
                if (newsNumber == 0)
                {
                    newsText.text = "It's a lovely morning in Missifishy, ripe for flipping!";
                }
                else
                {
                    newsText.text = "The weather is sunny, the fish are swimming and all seems right in Missifishy, UFA.";
                }
                break;
            case NewsStates.Curious:
                if (newsNumber == 0)
                {
                    newsText.text = "Reports say that the world has been invaded by a sentient species of Blobfish.";
                }
                else
                {
                    newsText.text = "\"There are no Alien Salmon here.\", claim Alien Salmon.";
                }
                
                break;
            case NewsStates.RandomFact1:
                if (newsNumber == 0)
                {
                    newsText.text = "Did you know that Trout are closely related to Salmon?";
                }
                else
                {
                    newsText.text = "Did you know that Rainbow Trout have been introduced to every continent except Antarctica?";
                }
                
                break;
            case NewsStates.Scientific:
                if (newsNumber == 0)
                {
                    newsText.text = "New breakthroughs in science have shown that flipping a Trout fast enough can create a black-hole!";
                }
                else
                {
                    newsText.text = "Miniature black-hole destroys Pacific Ocean. Experts claim \"This may affect the Trout population\".";
                }
                
                break;
            case NewsStates.Foreboding:
                if (newsNumber == 0)
                {
                    newsText.text = "\"Those darned Trouts warped my house out of existence!\", angry local claims.";
                }
                else
                {
                    newsText.text = "Astrologists have observed a fish-sized comet hurdling towards Earth.";
                }
                
                break;
            case NewsStates.WeatherReport:
                if (newsNumber == 0)
                {
                    newsText.text = "The forecast for today indicates a slight chance of Fishmageddon this afternoon.";
                }
                else
                {
                    newsText.text = "The forecast for today shows a possible chance of Tuna rain.";
                }
                
                break;
            case NewsStates.RandomFact2:
                if (newsNumber == 0)
                {
                    newsText.text = "Did you know that Trout have teeth on the roof of the mouth called 'Vomerine Teeth'?";
                }
                else
                {
                    newsText.text = "Did you know that the largest Trout ever caught measured up to 90cm long?";
                }
               
                break;
            case NewsStates.Fishy:
                if (newsNumber == 0)
                {
                    newsText.text = "\"My best friend was replaced by a Blobfish!\", local conspiracy theorist claims.";
                }
                else
                {
                    newsText.text = "\"Blobfish walk among us\", local conspiracy theorist claims.";
                }
                
                break;
            case NewsStates.Fishmageddon:
                if (newsNumber == 0)
                {
                    newsText.text = "Reports indicate millions of Piranhas launching into space in miniature space craft.";
                }
                else
                {
                    newsText.text = "Locals say Anglerfish are purchasing more lightbulbs than ever, warn of potential supply shortage.";
                }
                
                break;
            case NewsStates.ItHasEmerged:
                if (newsNumber == 0)
                {
                    newsText.text = "A tear in reality has caused thousands of fish to fall out from the void, locals say.";
                }
                else
                {
                    newsText.text = "A rip in the Fish Time Continuum has caused a surge in the price of Oatmeal, locals say.";
                }
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