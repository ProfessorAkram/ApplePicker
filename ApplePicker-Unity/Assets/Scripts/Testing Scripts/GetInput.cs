using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetInput : MonoBehaviour
{
    public InputField playerNameInput;
    [HideInInspector]
    public string playerName;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void SetInput()
    {
        playerName = playerNameInput.text;
        Debug.Log("Hello "+ playerName);
    }
}
