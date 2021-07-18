using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPanels : MonoBehaviour
{
    public static GridPanels instances=null;
    public Transform[] Grids;
    public List<int> emptyGrids = new List<int>();

    // Start is called before the first frame update
    //public Dictionary<Transform, GameObject> dictionary = new Dictionary<Transform, GameObject>();
    private void Awake() 
    {
        if (instances != null)
            Destroy(gameObject);
        else
            instances = this;
       
    }
    void Start()
    {
        
 
    }
    public int getempty()
    {
        if(emptyGrids.Count==0)
        {
            return 10;
        }
        int temp=emptyGrids[0];
        emptyGrids.Remove(temp);
        emptyGrids.Sort();
        return temp;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void store(Items items)
    {
        int empty=getempty();
        if(empty==10)
        {
            Debug.Log("bag is full");
            return;
        }
        Transform parent=Grids[empty];
        GameObject newItem = Resources.Load("grid") as GameObject;
        if (newItem.GetComponent<UIItem>() != null)
        {
            newItem.GetComponent<UIItem>().SetName(items.name);
            newItem.GetComponent<UIItem>().SetImage(items.pic);
        }
        GameObject.Instantiate(newItem, parent);

    }
    public void throwobj(int id)
    {
        if(emptyGrids.Contains(id))
        {
            Debug.Log("it is an empty grid");
            return;
        }
        
        Transform parent=Grids[id];
        Debug.Log(parent.GetChild(0).gameObject.GetComponent<UIItem>().itemName.text);
        Destroy(parent.GetChild(0).gameObject);
        emptyGrids.Add(id);
        emptyGrids.Sort();
        
    }
    
}
