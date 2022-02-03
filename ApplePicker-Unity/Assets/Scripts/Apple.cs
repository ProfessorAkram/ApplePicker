/**** 
 * Created by: Akram Taghavi-Burrs
 * Date Created: Feb 01, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Feb 02, 2022
 * 
 * Description:Controls the falling apples
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{

    /**** VARIABLES ****/
    public static float bottomY = -20f; //the bottom y location
    /*NOTE: Static variables are shared by all instances, think of them as a single global varaible for all instances of the class*/



    // Update is called once per frame
    void Update()
    {
        //if the y position is less than the bottom y
        if(transform.position.y < bottomY)
        {
            Destroy(this.gameObject); //Destory gameObjet

            //Get reference to ApplePicker component of GameManager
            ApplePicker apScript = GameObject.Find("GameManager").GetComponent<ApplePicker>();

            //call the public appleDestory() method of apScript
            apScript.AppleDestoryed();


        }//end if(transform.position.y < bottomY)

    }//end Update()
}
