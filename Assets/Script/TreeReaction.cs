using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeReaction : MonoBehaviour
{
    public bool IsWin = false;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Win()
    {
       
                //if (mt != null) {
                anim.SetBool("IsWin", true);
                
                ///////////////Instantiate(mirror, transform.position = new Vector3(0, 0.3f, 0), Quaternion.Euler(0, 0, 90f));
         
            }
        
    }



