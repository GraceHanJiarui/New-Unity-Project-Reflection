using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundShining : MonoBehaviour
{
    public Animator anim;
    public bool IsWin1 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Win() {
        anim.SetBool("IsWin1", true);
    }
}
