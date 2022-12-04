using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConversationTextDisplayScript: MonoBehaviour
{
    public Text ConversationTextBox;
    public TextMeshProUGUI TutorialTextBox;
    public TextMeshProUGUI TutorialTextBoxRight;
    public static bool final = false;
    public Color PEtoHeat;
    public Color HeattoPE;
    public Color DieColor;
    public Color ScoreColor;
    public Color NiceGreenText;
    public GameObject DiceActiveOrNot;
    public GameObject TutorialLeftSpeechBubble;
    public GameObject TutorialRightSpeechBubble;
    public GameObject TutorialArrow;
    public Sprite endgametextsprite;

    // Start is called before the first frame update
    void Start()
    {
        final = false;
        ConversationTextBox.text = null;
        
        if(GameObject.Find("TutorialMarker").GetComponent<TutorialScript>().Tutorial == true)
        {
            DragOutAtomTutorial();  //this starts the tutorial version!  The first 3 turns are scripted.
        }
        else
        {
            StartRolling();
        }

    }

    public void DragOutAtom()  //the function is called from DieCheckZoneScript (line 73)
    {
        ConversationTextBox.text = "Drag an atom into the play space";
        ConversationTextBox.color = Color.white;
        ConversationTextBox.fontStyle = FontStyle.Normal;
        StartCoroutine(countdown());
    }

    public void DragOutAtomTutorial()  //the function is called from above (conversationTextDisplayScript)
    {
        TutorialTextBox.text = "Drag a Carbon atom into the play space";
        TutorialTextBox.color = NiceGreenText;
        //ConversationTextBox.fontStyle = FontStyle.Normal;
        //StartCoroutine(countdown());
    }

    public void RotateAtomInstructions()  //used in the tutorial version--called from UIDragNDrop script
    {
        TutorialArrow.SetActive(false);
        TutorialTextBox.text = "Click on the atom to rotate it.  (Do this 4 times!)";
        TutorialTextBox.color = Color.blue;
        ConversationTextBox.fontStyle = FontStyle.Normal;
        //this text remains visible until the player has successfully rotated an atom (in RotateThis script)

    }

    public void SwitchAtomForm()    //called from RotateThis script
    {
        TutorialTextBox.text = "Use a Right Click or Long Click to change the form of a carbon or oxygen atom";
        TutorialTextBox.color = NiceGreenText;
        //this text remains visible until player switches atom form (in SwapIt script)
    }

   
    public void BlueJoulesArePE()  //called in tutorial mode from SwapIt script after player has changed atom form a couple times
    {
        TutorialTextBox.text = "Blue Jewels represent POTENTIAL ENERGY.";
        TutorialTextBox.color = Color.blue;
        //TRY TO MAKE THE JEWELS BLINK ON THE CARBON ATOM WHILE THIS TEXT IS DISPLAYED!!!!        
        Invoke("CarbonHas4JoulesPE", 8);
        
    }

    public void CarbonHas4JoulesPE()  //called in tutorial mode from the function shown above (BlueJoulesArePE)  1
    {
        TutorialTextBox.text = "An UNBONDED carbon atom has 4-Joules of Potential Energy";
        TutorialTextBox.color = NiceGreenText;       
        Invoke("StartRollingTutorial", 8);
    }

    public void StartRollingTutorial()  //called in tutorial mode from the function shown above (CarbonHas4JoulesPE)  2
    {
        GameObject.Find("TutorialMarker").GetComponent<TutorialScript>().DiceActiveOrNot.SetActive(true);  //this makes the purple die appear in tutorial
        TutorialTextBox.text = "Click the Purple Dice Icon to roll the Die";        
        TutorialTextBox.color = DieColor;
        DieScript.rolling = 0;
       
    }

    public void StartRolling()  //called in standard mode on Round 0 (upon game Startup)  
    {
        GameObject.Find("TutorialMarker").GetComponent<TutorialScript>().DiceActiveOrNot.SetActive(true);  //this makes the purple die appear in tutorial
        ConversationTextBox.text = "Click the Purple Dice Icon to roll the Die";
        ConversationTextBox.color = DieColor;
        DieScript.rolling = 0;

    }

    public void ChooseOxygenEB()  //this is used on turn 2 of tutorial mode--called from DieCheckZone script
    {
        TutorialRightSpeechBubble.SetActive(true);
        TutorialLeftSpeechBubble.SetActive(false);
        TutorialTextBoxRight.text = "Choose the SECOND form of oxygen (the diagonal form)";
        TutorialTextBoxRight.color = PEtoHeat;
    }

    public void SwitchFormToOxygenEB()  //called from UIDragNDrop on turn 2 of tutorial
    {
        TutorialTextBoxRight.text = "The diagonal form of oxygen can make a DOUBLE BOND with Carbon";
        TutorialTextBoxRight.color = NiceGreenText;
        //ConversationTextBox.fontStyle = FontStyle.Normal;
        GameObject.Find("TutorialMarker").GetComponent<TutorialScript>().DiceActiveOrNot.SetActive(false);
        RotateThis.DisableRotation = false;
        print("rotation enabled");
        Invoke("MakeDoubleBond", 7);
    }

   
    public void MakeDoubleBond()  //invoked from function above  3
    {
        TutorialTextBoxRight.text = "Rotate the Oxygen and Line up the atoms on a diagonal to make a Double Bond!";
        TutorialTextBoxRight.color = Color.blue;
    }

    public void BondingConvertsPEtoHeat()  //called from JewelMover script
    {
        GameObject.Find("TutorialMarker").GetComponent<TutorialScript>().DiceActiveOrNot.SetActive(false);
        TutorialTextBoxRight.text = "When atoms bond, Potential Energy is converted to Heat Energy.";
        TutorialTextBoxRight.color = PEtoHeat;
        Invoke("BondStrengthMessage", 8);
    }


    public void BondStrengthMessage()    //called from the function above    4
    {
        TutorialRightSpeechBubble.SetActive(false);
        TutorialLeftSpeechBubble.SetActive(true);
        TutorialTextBox.text = "The number of Joules converted to Heat depends on BOND STRENGTH (see the red onscreen table)";
        TutorialTextBox.color = PEtoHeat;
        Invoke("PointsForRedJoules", 10);
        
    }

    public void PointsForRedJoules()  //invoked from the function above   5
    {
        TutorialRightSpeechBubble.SetActive(true);
        TutorialLeftSpeechBubble.SetActive(false);
        TutorialTextBoxRight.text = "Each Joule of Heat is Worth 10 Points. You now have: " +DisplayCanvasScript.ScoreTotal + " points!";
        TutorialTextBoxRight.color = NiceGreenText;
        Invoke("ContinueRolling", 10);
    }

    public void ContinueRolling()  //called in tutorial mode from the function shown above (PointsForRedJoules)   6
    {
        TutorialRightSpeechBubble.SetActive(false);
        TutorialLeftSpeechBubble.SetActive(true);
        GameObject.Find("TutorialMarker").GetComponent<TutorialScript>().DiceActiveOrNot.SetActive(true);
        TutorialTextBox.text = "Click the Purple Die Icon to Continue";
        //ConversationTextBox.fontStyle = FontStyle.Normal;
        TutorialTextBox.color = DieColor;
        //DieScript.rolling = 0;
    }

    public void ChooseH2()   //called from DieCheckZone Script
    {
        TutorialRightSpeechBubble.SetActive(true);
        TutorialLeftSpeechBubble.SetActive(false);
        GameObject.Find("TutorialMarker").GetComponent<TutorialScript>().DiceActiveOrNot.SetActive(false);
        TutorialTextBoxRight.text = "Choose diatomic hydrogen (H2)";
        TutorialTextBoxRight.color = Color.gray;
    }

    public void BreakABond()   //called from UIDragNDrop script
    {        
        GameObject.Find("FlameController").GetComponent<FlameHidingScript>().FlameOn();
        TutorialTextBoxRight.text = "Drag the Bond-breaking Energy Flame Icon onto the center of the H2 molecule";
        TutorialTextBoxRight.color = HeattoPE;
    }

    public void BreakingBondsIncreasesPE()  //called from GoldenJewelMover script
    {
        GameObject.Find("FlameController").GetComponent<FlameHidingScript>().FlameOff();
        TutorialTextBoxRight.text = "Breaking a Bond converts Heat Energy to Potential Energy";
        TutorialTextBoxRight.color = Color.blue;
        Invoke("BondHtoC", 8);
    }

    public void BondHtoC()  //invoked from function above 7
    {
        TutorialRightSpeechBubble.SetActive(false);
        TutorialLeftSpeechBubble.SetActive(true);
        TutorialTextBox.text = "Bond both of the single Hydrogen Atoms to the Carbon Atom";
        TutorialTextBox.color = Color.black;

    }

    public void MoleculeCompletionTutorial()  //called from JewelMover script
    {

        TutorialTextBox.text = "Completing a Molecule earns Bonus Points (see blue table for point values)";
        TutorialTextBox.color = Color.blue;
        SwapIt.DisableSwap = false;   //restores the ability to swap atom shapes
        print("swap atom enabled");
        Invoke("ContinueToTheEndOfTheGame", 10);
    }

    public void MoleculeCompletionEarnsBonusPts()  //called from JewelMover script 
    {
        ConversationTextBox.text = "Completing a Molecule earns Bonus Points (see blue table for point values)";
        ConversationTextBox.color = Color.blue;
        StartCoroutine(countdown());
               
    }

    public void ContinueToTheEndOfTheGame()    //invoked from function above MoleculeCompletionTutorial 8
    {
        print("Continue to the End");
        //StopAllCoroutines();
        TutorialTextBox.text = "This molecule has 4 atoms and is worth 30 BONUS POINTS.";
        TutorialTextBox.color = HeattoPE;
        Invoke("ContinueToTheEndOfTheGame2", 8);
    }

    public void ContinueToTheEndOfTheGame2()  //invoked from function above  9
    {
        TutorialRightSpeechBubble.SetActive(true);
        TutorialLeftSpeechBubble.SetActive(false);
        TutorialTextBoxRight.text = "You now have Six Joules of Heat worth 60 POINTS!";
        TutorialTextBoxRight.color = PEtoHeat;
        //TutorialTextBox.fontStyle = FontStyle.Normal;  NEED TMPro FontStyle
        Invoke("ContinueToTheEndOfTheGame3", 9);
    }

    public void ContinueToTheEndOfTheGame3()  //invoked from function above  9
    {
        TutorialTextBoxRight.text = "Your total score is 60 heat pts + 30 bonus pts = 90 total points!";
        TutorialTextBoxRight.color = HeattoPE;
        Invoke("ContinueToTheEndOfTheGame4", 8);
    }


    public void ContinueToTheEndOfTheGame4()  //invoked from function above  9
    {
        TutorialRightSpeechBubble.SetActive(false);
        TutorialLeftSpeechBubble.SetActive(true);
        TutorialTextBox.text = "A complete game is 12 rounds.";
        TutorialTextBox.color = NiceGreenText;
        //TutorialTextBox.fontStyle = FontStyle.Normal;  NEED TMPro FontStyle
        Invoke("ContinueToTheEndOfTheGame5", 7);
    }

    public void ContinueToTheEndOfTheGame5()  //invoked from function above 10
    {
        TutorialTextBox.text = "To get a high score, make STRONG BONDS and COMPLETE many molecules!";
        TutorialTextBox.color = Color.blue;
        Invoke("NowYouKnowHowToPlay", 7);
    }

    public void NowYouKnowHowToPlay ()   //invoked from function above 11
    {
        TutorialTextBox.text = "This ends the tutorial instructions.  Have fun playing The Crown Joules!";
        TutorialTextBox.color = NiceGreenText;
        Invoke("ContinueRollingWithCountdown", 6);
    }


    public void ContinueRollingWithCountdown()  //invoked from function above 12
    {
        GameObject.Find("TutorialSpeechBubble").SetActive(false);
        GameObject.Find("FlameController").GetComponent<FlameHidingScript>().FlameOn();  //activates unbonding flame icon
        GameObject.Find("TutorialMarker").GetComponent<TutorialScript>().DiceActiveOrNot.SetActive(true);
        ConversationTextBox.text = "Click the Purple Die to Start the next turn";
        ConversationTextBox.fontStyle = FontStyle.Normal;
        ConversationTextBox.color = DieColor;
        DieScript.rolling = 0;
        StartCoroutine(countdown());
    }

    public void Denied()
    {
        ConversationTextBox.text = "You don't have enough Joules to break this bond!";
        StartCoroutine(countdown());
    }

    public void OutOfInventory()
    {
        ConversationTextBox.text = "These atoms are exhausted.  Roll again!";
        StartCoroutine(countdown());
    }

    public void OutOfInventory2()
    {
        ConversationTextBox.text = "You can't have any more of that atom, choose another!";
        StartCoroutine(countdown());
    }

    public void OutOfInventory3()
    {
        ConversationTextBox.text = "You can't swap that atom, you alrady are at the Limit!";
        StartCoroutine(countdown());
    }

    public void finalTurn()
    {
        final = true;
        ConversationTextBox.text = "Final Turn! Make all your moves, then click END GAME to finalize your score!";
		GameObject.Find("DiceButton").GetComponent<Image>().sprite = endgametextsprite;
        ConversationTextBox.color = Color.yellow;
		StartCoroutine(countdown());
    }

    public void noStack()
    {
        ConversationTextBox.text = "Drag your chosen atom into an EMPTY SPACE in the playing field.";
        ConversationTextBox.color = Color.yellow;
        StartCoroutine(countdown());
    }

    public void NoBondToBreak()
    {
        ConversationTextBox.text = "This Bond is Already Broken";
        StartCoroutine(countdown());
    }

    public void HeatToPEConversion(int JouleCost)
    {
       ConversationTextBox.text = JouleCost.ToString() + " Joules of Heat Energy converted to Potential Energy";
       ConversationTextBox.color = HeattoPE;
       StartCoroutine(countdown());
    }

    public void PEtoHeatConversion(int BondEnergy)
    {
        ConversationTextBox.text = BondEnergy.ToString() + " Joules of Potential Energy converted to Heat";
        ConversationTextBox.color = PEtoHeat;
        ConversationTextBox.fontStyle = FontStyle.Italic;
        
        StartCoroutine(countdown());
    }

   

    public void CantSwap()
    {
        ConversationTextBox.text = "You can only swap UNBONDED atoms";
        StartCoroutine(countdown());
    }

    public void CantRotate()
    {
        ConversationTextBox.text = "You can only rotate UNBONDED atoms";
        StartCoroutine(countdown());
    }

    private IEnumerator countdown()  //this is a co-routine, can run in parallel with other scripts/functions
    {
        yield return new WaitForSeconds(5);
        if (final)
        {
            ConversationTextBox.text = "Final Turn! Make all your moves, then click END GAME to finalize your score!";
            ConversationTextBox.color = Color.yellow;
			GameObject.Find("DiceButton").GetComponent<Image>().sprite = endgametextsprite;
        }
        
        else if (GameObject.Find("TutorialMarker").GetComponent<TutorialScript>().Tutorial == true && DieScript.totalRolls == 3)
        {
            //don't erase the Bonus Point text message
        }

        else
        {
            ConversationTextBox.text = null;
            ConversationTextBox.color = Color.white;
            ConversationTextBox.fontStyle = FontStyle.Normal;
        }
        yield break;
    }
}



