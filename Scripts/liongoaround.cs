using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liongoaround : MonoBehaviour
{
    public static liongoaround lioninstance=null;
    Animator anim;
    Rigidbody2D rb;
    public float sposition;
    public int direction=1;
    public float mymovePower = 10f;
    public float lookrange=5f;
    Vector3 moveVelocity=Vector3.left;
    public bool chasejudge=false;
    public Transform target;
    void Awake()
    {
        if (lioninstance != null)
            Destroy(gameObject);
        else
            lioninstance = this;
            
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sposition=transform.position.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        reset();
        if(!chasejudge)
        {
            look();
        }
        else
        {
            chase();
        }
 
    }
    void reset()
    {
         anim.SetBool("IsRun",false);
         anim.SetBool("IsWalk",false);
    }
    public void run()
    {
        anim.SetBool("IsRun",true);
    }
    public void walk()
    {
        anim.SetBool("IsWalk",true);
    }
    public void look()
    {
        walk();
        
        if(transform.position.x-sposition<-lookrange)
        {

            direction = -1;
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(direction, 1, 1);
        }
        if(transform.position.x-sposition>lookrange)
        {
            
            direction = 1;
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(direction, 1, 1);
        }
        
        transform.position += moveVelocity * mymovePower * Time.deltaTime/5;


    }

    void chase()
    {
        run();
        sposition=transform.position.x;
        if(transform.position.x>target.position.x)
        {
            direction = 1;
            moveVelocity=Vector3.left;
            transform.localScale = new Vector3(direction, 1, 1);
        }
        else
        {
            direction = -1;
            moveVelocity=Vector3.right;
            transform.localScale = new Vector3(direction, 1, 1);
        }
        transform.position += moveVelocity * mymovePower * Time.deltaTime/3;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
  
        if(other.CompareTag("Player"))
        {
            chasejudge=true;
            target=other.transform;
        }
            
        

    }
    private void OnTriggerExit2D(Collider2D other) {

  
        if(other.CompareTag("Player"))
        {
            chasejudge=false;
            target=null;
        }
            
    }
}
