using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bagcontrol : MonoBehaviour
{
    // Start is called before the first frame update
    public  Items tempitem=new Items();
    public void loaddata()
    {
        tempitem.name="剑";
        tempitem.des="砍人";
        tempitem.pic="ItemPicture/weapon1";
    }
    void Start()
    {
        loaddata();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GridPanels.instances.store(tempitem);
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            GridPanels.instances.throwobj(Random.Range(0, 9));
        }
    }
}
