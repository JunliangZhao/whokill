using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lionhunt : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other) 
    {
  
        if(other.CompareTag("Player"))
        {

            liongoaround.lioninstance.chasejudge=true;
            liongoaround.lioninstance.target=other.transform;
        }
            
        

    }
    private void OnTriggerExit2D(Collider2D other) {

  
        if(other.CompareTag("Player"))
        {
            liongoaround.lioninstance.chasejudge=false;
            liongoaround.lioninstance.target=null;

        
        }
            
    }
}
