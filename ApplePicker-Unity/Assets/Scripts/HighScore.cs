/**** 
 * Created by: Akram Taghavi-Burrs
 * Date Created: Feb 01, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Feb 02, 2022
 * 
 * Description: Controls the highscore
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //uses UI libraries

public class HighScore : MonoBehaviour
{
    /**** VARIABLES ****/
    static public int score = 1000; // Default high score
    /*NOTE: static public variables are accessible to all scripts and do not reset with scene loads.
      However, restarting the entire game will will reset the highscore, unless you use Unity PlayerPrefabs.*/


    //Awake is called before Start
    private void Awake()
    {
        //if the Playerprefab HighScore already exists read it
        if (PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetInt("HighScore"); //set the score to the recorded HighScore
        }

        //Assign the highscore to the score value
        PlayerPrefs.SetInt("HighScore", score);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text gt = this.GetComponent<Text>(); //get the text compment of the highscore ui
        gt.text = "High Score : " + score; //set the score value text

        //Update the PlayerPrefabs HighScore if nessary
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score); //set HighScore to score
        }
    }//end Update()
}
