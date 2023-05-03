using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorTurningTrigger : MonoBehaviour
{

    public Animator anim;

    public void MirrowTurn()
    {
        anim.SetBool("StickPull", true);
        
    }

    public void MirrowBack()
    {
        anim.SetBool("StickPull", false);
    }
}
