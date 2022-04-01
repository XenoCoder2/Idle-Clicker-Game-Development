using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsEvents : MonoBehaviour
{
    #region Text Variable
    public Text newsText;
    #endregion
    #region NewsStates Variable
    public static NewsStates news;
    #endregion
    #region Int Variable
    public static int newsNumber;
    #endregion

    #region Update Method
    // Update is called once per frame
    void Update()
    {
        //Switch between the News States.
        switch (news)
        {
            case NewsStates.Calm:
                //If the newsNumber is equal to 0.
                if (newsNumber == 0)
                {
                    //Set the newsText's text.
                    newsText.text = "It's a lovely morning in Missifishy, ripe for flipping!";
                }
                //Else
                else
                {
                    //Set the newsText's text.
                    newsText.text = "The weather is sunny, the fish are swimming and all seems right in Missifishy, UFA.";
                }
                break;
            case NewsStates.Curious:
                //If the newsNumber is equal to 0.
                if (newsNumber == 0)
                {
                    //Set the newsText's text.
                    newsText.text = "Reports say that the world has been invaded by a sentient species of Blobfish.";
                }
                //Else
                else
                {
                    //Set the newsText's text.
                    newsText.text = "\"There are no Alien Salmon here.\", claim Alien Salmon.";
                }
                
                break;
            case NewsStates.RandomFact1:
                //If the newsNumber is equal to 0.
                if (newsNumber == 0)
                {
                    //Set the newsText's text.
                    newsText.text = "Did you know that Trout are closely related to Salmon?";
                }
                //Else
                else
                {
                    //Set the newsText's text.
                    newsText.text = "Did you know that Rainbow Trout have been introduced to every continent except Antarctica?";
                }
                
                break;
            case NewsStates.Scientific:
                //If the newsNumber is equal to 0.
                if (newsNumber == 0)
                {
                    //Set the newsText's text.
                    newsText.text = "New breakthroughs in science have shown that flipping a Trout fast enough can create a black-hole!";
                }
                //Else
                else
                {
                    //Set the newsText's text.
                    newsText.text = "Miniature black-hole destroys Pacific Ocean. Experts claim \"This may affect the Trout population\".";
                }
                
                break;
            case NewsStates.Foreboding:
                //If the newsNumber is equal to 0.
                if (newsNumber == 0)
                {
                    //Set the newsText's text.
                    newsText.text = "\"Those darned Trouts warped my house out of existence!\", angry local claims.";
                }
                //Else
                else
                {
                    //Set the newsText's text.
                    newsText.text = "Astrologists have observed a fish-sized comet hurdling towards Earth.";
                }
                
                break;
            case NewsStates.WeatherReport:
                //If the newsNumber is equal to 0.
                if (newsNumber == 0)
                {
                    //Set the newsText's text.
                    newsText.text = "The forecast for today indicates a slight chance of Fishmageddon this afternoon.";
                }
                //Else
                else
                {
                    //Set the newsText's text.
                    newsText.text = "The forecast for today shows a possible chance of Tuna rain.";
                }
                
                break;
            case NewsStates.RandomFact2:
                //If the newsNumber is equal to 0.
                if (newsNumber == 0)
                {
                    //Set the newsText's text.
                    newsText.text = "Did you know that Trout have teeth on the roof of the mouth called 'Vomerine Teeth'?";
                }
                //Else
                else
                {
                    //Set the newsText's text.
                    newsText.text = "Did you know that the largest Trout ever caught measured up to 90cm long?";
                }
               
                break;
            case NewsStates.Fishy:
                //If the newsNumber is equal to 0.
                if (newsNumber == 0)
                {
                    //Set the newsText's text.
                    newsText.text = "\"My best friend was replaced by a Blobfish!\", local conspiracy theorist claims.";
                }
                //Else
                else
                {
                    //Set the newsText's text.
                    newsText.text = "\"Blobfish walk among us\", local conspiracy theorist claims.";
                }
                
                break;
            case NewsStates.Fishmageddon:
                //If the newsNumber is equal to 0.
                if (newsNumber == 0)
                {
                    //Set the newsText's text.
                    newsText.text = "Reports indicate millions of Piranhas launching into space in miniature space craft.";
                }
                //Else
                else
                {
                    //Set the newsText's text.
                    newsText.text = "Locals say Anglerfish are purchasing more lightbulbs than ever, warn of potential supply shortage.";
                }
                
                break;
            case NewsStates.ItHasEmerged:
                //If the newsNumber is equal to 0.
                if (newsNumber == 0)
                {
                    //Set the newsText's text.
                    newsText.text = "A tear in reality has caused thousands of fish to fall out from the void, locals say.";
                }
                //Else
                else
                {
                    //Set the newsText's text.
                    newsText.text = "A rip in the Fish Time Continuum has caused a surge in the price of Oatmeal, locals say.";
                }
                break;
            default:
                break;
        }
    }
    #endregion
}
//An Enum for each News State.
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