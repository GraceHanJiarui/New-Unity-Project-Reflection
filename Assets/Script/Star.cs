using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{

    // public Animator anim;
    // public bool IsStickPull = false;//本身推杆的动画播放条件设置为假
    public MirrorTurning m_MirrorTurningTrigger;
    public MirrorTurning n_MirrorTurningTrigger;
    //public bool i = true;
    private bool countint = false;
    // Start is called before the first frame update
    void Start()
    {
        //m_MirrorTurningTrigger = GameObject.Find("mirrorUR1").GetComponent<MirrorTurningTrigger>();
        //n_MirrorTurningTrigger = GameObject.Find("mirrorUL1").GetComponent<MirrorTurningTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                countint = !countint;
                if (countint)
                {
                    // anim.SetBool("IsStickPull", true);
                    m_MirrorTurningTrigger.MirrowTurn();
                    n_MirrorTurningTrigger.MirrowBack();
                    print("triggered");
                }
                else
                {
                    // anim.SetBool("IsStickPull", false);
                    m_MirrorTurningTrigger.MirrowBack();
                    n_MirrorTurningTrigger.MirrowTurn();
                }
                }
            }
        }


}

    
