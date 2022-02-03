/**** 
 * Created by: Akram Taghavi-Burrs
 * Date Created: Feb 01, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Feb 02, 2022
 * 
 * Description: Apple Picker game manager 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePicker : MonoBehaviour
{
    /**** VARIABLES ****/
    [Header("SET IN INSPECTOR")]
    public GameObject basketPrefab; //basket prefab
    public int numberOfbaskets = 3; //number of total baskets at start
    public float basketBottomY = -14f; //bottom distance for basket
    public float basketSpacingY = 2F; //distance for each basket


    // Start is called before the first frame update
    void Start()
    {
    //For totale number of baskets, create baskets
     for(int i= 0; i<numberOfbaskets; i++)
        {
            GameObject tBasketGo = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGo.transform.position = pos; 
        } //end for
    }//end Start()

    // Update is called once per frame
    void Update()
    {
    }//end Update()
}
