using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class powers : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if(variable.startgame){
            String show ="";
            for(int i=0;i<(variable.power/20);i++)
                show  += "■" ;
            this.GetComponent<Text>().text =show;
        }
        else{
            this.GetComponent<Text>().text = variable.text;
        }
            
    }
}
