/**** 
 * Created by: Akram Taghavi-Burrs
 * Date Created: Feb 01, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Feb 02, 2022
 * 
 * Description: Moves the basket using the mouse
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //enable UI libraries

public class Basket : MonoBehaviour
{
    /**** VARIABLES ****/
    GameManager gm; //reference to game manager

    public Text scoreGT;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GM; //find the game manager

        /*NOT RELAVENT WITH NEW HUD
        //Find a reference to the ScoreCounter GameObject
        GameObject scoreGo = GameObject.Find("ScoreCounter");

        //Get the Text Component of the GameObject
        scoreGT = scoreGo.GetComponent<Text>();

        //set the starting score
        scoreGT.text = "0";
        */
    }

    // Update is called once per frame
    void Update()
    {
/* BASKET MOVEMENT */
        //Get the current scene positon mouse from input
        Vector3 mousePos2D = Input.mousePosition; 
        /*NOTE: Input.mousePosition is how many pixels the mouse is from the top-left corner of the screne. The Z value is always zero because it is techinally a 2D point that the mouse referneces.*/

        //The Camera's Z posiion sets how far to push the mouse into 3D
        mousePos2D.z = Camera.main.transform.position.z;

        //Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D); 
        /*NOTE: ScreenToWorldPoint() converts our mousePoint2D into 3D space, by default the Z(0) value would be set to the -10, thus we first set the z value equal to our camera, this will push the camera, which is at 10, the convert, will then set it exactly to 0.*/

        //Move the x position of the Basekt to the x position of the mouse 
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    
    }//end Update()

    //collsiion with apples
    private void OnCollisionEnter(Collision coll)
    {
        //Check what the basket hit
        GameObject collideWith = coll.gameObject; 
        if(collideWith.tag == "Apple")

        {
            Destroy(collideWith);

            /*NEW WITH GM*/
            int points = collideWith.GetComponent<Apple>().applePoint; //get the point value of the collectable
            gm.UpdateScore(points);//run the update score method of the GM

        }//end if(collideWith.tag == "Apple")



        /*NOW MANAGED BY GM
        //Set the score
        int score = int.Parse(scoreGT.text); //takes the score text and converts it to a int
        score += 100;
        scoreGT.text = score.ToString(); //converts new score to string

        //Update high score if current score is higher
        if(score > HighScore.score)
        {
            HighScore.score = score;
        }//end if(score > HighScore.score)
        */

    }//end OnCollisionEnter(Collision coll)
}
