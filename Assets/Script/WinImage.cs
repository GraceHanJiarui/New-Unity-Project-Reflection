using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinImage : MonoBehaviour
{
    public Animator anim;
    public bool IsWin = false;
    
    // Start is called before the first frame update
    void Start()
    {
        this.anim.SetBool("IsWin", false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Win()
    {
        this.anim.SetBool("IsWin", true);
    }
    

}
