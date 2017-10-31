using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PDSentence : MonoBehaviour
{

    private string[] theseSentences;
    // Use this for initialization
    void Start()
    {
        

        
    }

    void Update() {
    }

    public void MakeProver()
    {
        theseSentences = new string[] {
            "A bird who sings, does so for the song, and not as a reply.",
            "A book should feel like a block of gold.",
            "Gifting flowers leaves you fragrant.",
            "Ivory tusks exist not in a dog's mouth.",
            "Polished concrete does not outvalue flawed diamonds.",
            "For any stone to shine, it must be worked.",
            "In the climb, fear not the crawl, fear the pause.",
            "The depth of your self-doubt matches your self-wisdom.",
            "When drinking at a stream, think of the source.",
            "A case is not enough between true friends, but with others one drink is already too much.",
            "Because one exists, one must then also have a purpose.",
            "Source your drink before you are thirsty.",
            "A true leader blazes the trail for others to follow.",
            "Tolerance for one moment, may save you an age of sadness.",
            " If you don't want anyone to know, don't do it.",
        };

        int Indext = Random.Range(0, 14);
        GetComponent<Text>().text = theseSentences[Indext];
    }

    public void MakeDirection()
    {
        theseSentences = new string[] {
            "YOU MUST SHARE AN ELIXIR WITH BRETHREN TO BOOST YOUR COLLECTIVE PHYTOCHROMES.",
            "YOUR ISOFORM STRUCTURE IS TOO DENSE. YOU ARE NOT YET READY FOR THE CENTRIFUGE. GO UPSTAIRS TO MAKE THEM SOLUBLE.",
            "YOUR COITUS AVIDITY IS DELICATE. SUMMON THREE PITUITARY GLANDS, AND MILK THEM.",
            "YOUR MIDLINE CRYSTALS HAVE HARDENED. YOU NEED TO BE ANNEALED.",
            "YOUR ZINC AND MANGANESE DIOXIDE LEVELS ARE UNBALANCED. THE PERSON ON THE LEFT SHOULD SWAP WITH THE RIGHT.",
            "PERFECTION. IT IS A STATE UNKNOWN TO MOST. BUT IT IS OBVIOUS TO THOSE WHO ARE TRULY AWAKENED SUCH AS YOURSELVES. REJOICE INITIATES!",
            "SENSOR DAMAGE DETECTED. PLEASE APPLY LESS FORCE TO THE SENSORS.",
            "A CHAIN IS ONLY AS STRONG AS ITS WEAKEST LINK. SOMEONE IN YOUR SQUAD IS EXHAUSTED AND IS CAUSING A SIGNAL BLOCKAGE.",
            "MOISTURE DETECTED. PLEASE REFRAIN FROM LICKING THE SENSORS.",
            "REJOICE! OUR CONGREGATION HAS FINALLY FOUND THOSE WHO ARE TRULY WORTHY. THE SLEEPLESS HAVE COME!",
            "YOUR MELATONIN LEVELS HAVE BEEN DEPLETED. YOU ARE IN DANGER OF BEING EXCOMMUNICATED.",
            "PREVENT FURTHER LOSS OF BORBORYGMI BY SEEKING IMMEDIATE ATTENTION UPSTAIRS.",
            "YOUR PTYALISM IS VISIBLE. PLEASE TAKE CARE OF IT DOWNSTAIRS BEFORE YOUR AGORISM GETS TOO HIGH.",
            "SYNODIC FLUCTUATIONS HAVE BEEN FOUND IN YOUR RECORDS. CORRECT THE ANOMALY USING FORM 2553.",
            "COLLECTIVELY, ONLY FOUR HOURS OF SLEEP DETECTED DURING THE LAST FORTNIGHT! PLEASE NOTIFY THE ELDERS AS WE WELCOME OUR NEW INITIATES.",
            "YOUR GROUP IS ALMOST READY. PLEASE CHECK EACH OTHER FOR POLYDIPSIA AND PROCEED DOWNSTAIRS FOR PRE-SESSION TAURINE INJECTIONS.",
            "PLEASE RUB EACH OTHER’S AURICLES TO REDUCE THE ELEVATED LEVELS OF VITEXIN. RETEST ONCE REPLETION HAS BEEN REACHED.",
            "SEASONAL CHANGES HAVE DISRUPTED YOUR THEOBROMINE FLOW. TREAT EACH OTHER TO SOME TONICS TO RESET YOUR OPTICAL ISOMERS.",
            "Hahaha",
            "These are great.",
        };

        int Indext = Random.Range(0, 20);
        GetComponent<Text>().text = theseSentences[Indext];
    }
}