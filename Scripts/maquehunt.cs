using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maquehunt : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other) 
    {
  
        if(other.CompareTag("Player"))
        {

            maquearound.maqueinstance.chasejudge=true;
            maquearound.maqueinstance.target=other.transform;
        }
            
        

    }
    private void OnTriggerExit2D(Collider2D other) {

  
        if(other.CompareTag("Player"))
        {
            maquearound.maqueinstance.chasejudge=false;
            maquearound.maqueinstance.target=null;
        
        
        }
            
    }
}
