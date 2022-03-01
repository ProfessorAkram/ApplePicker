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
using UnityEngine.SceneManagement; //enables scene libraries
public class ApplePicker : MonoBehaviour
{
    /**** VARIABLES ****/
    GameManager gm; //reference to game manager
    GameState gameState; //reference to the current game state

    [Header("SET IN INSPECTOR")]
    public GameObject basketPrefab; //basket prefab
    private int numberOfBaskets; //number of total baskets at start
    public float basketBottomY = -14f; //bottom distance for basket
    public float basketSpacingY = 2F; //distance for each basket
    [HideInInspector]
    public List<GameObject> basketList; // list of baskes

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GM; //find the game manager
        gameState = gm.gameState;// get the game sate

        //if we have not started playing set the defaults
        if (gameState != GameState.Playing) { gm.SetDefaultGameStats(); }

        numberOfBaskets = gm.Lives; //use the lives from game manager

        Debug.Log("baskets " + gm.Lives);

        //For totale number of baskets, create baskets
        for (int i= 0; i<numberOfBaskets; i++)
        {
            GameObject tBasketGo = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGo.transform.position = pos;
            basketList.Add(tBasketGo); //Add basket to list
        } //end for
    }//end Start()

    // Update is called once per frame
    void Update()
    {
    }//end Update()


    public void AppleDestoryed()
    {
        //Destroy all currently falling apples 
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach(GameObject tGo in tAppleArray)
        {
            Destroy(tGo);
        }

        //Destroy one of the Baskets when apple is not catched
        int basketIndex = basketList.Count - 1; //get the index of the last basket in the list because the baskets are added from the bottom up
        GameObject tBasketGo = basketList[basketIndex]; //get the reference to the last basket
        basketList.RemoveAt(basketIndex); //remove the basket from the list
        Destroy(tBasketGo); //destory the basket
        gm.LostLife(); //subtract from lives

        /*NOT relavent 
        //Restart if no more baskets
        if(basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene-00"); //reload scene
        }//end if(basketList.Count == 0)
        */

    }//end AppleDestoryed()
}
