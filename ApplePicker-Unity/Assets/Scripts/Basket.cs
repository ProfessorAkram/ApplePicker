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

public class Basket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
        }//end if(collideWith.tag == "Apple")
    }//end OnCollisionEnter(Collision coll)
}