using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MirrorTurning;

public class ButtonTrigger : MonoBehaviour
{
    
    // public Animator anim;
    //public bool IsMirrorTurning = false;
    public bool IsTouchButton = false;
    public MirrorTurning m_MirrorTurning;
    int somethingStay=0;

    // Start is called before the first frame update
    void Start()
    {
        m_MirrorTurning = GameObject.Find("mirrorDL").GetComponent<MirrorTurning>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "box" || other.gameObject.tag == "Mirrow")
        {
           if(somethingStay==0){
            Vector3 targetPos = new Vector3(this.transform.position.x, this.transform.position.y-0.2f, this.transform.position.z);
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, 0.2f);
            m_MirrorTurning.MirrowTurn();
           }
           somethingStay++;
        }

        /*
    }*/

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "box" || other.gameObject.tag == "Mirrow")
        {
            somethingStay--;
            if(somethingStay==0){
            // transform.Translate(0,1.5f,0);
            Vector3 targetPos1 = new Vector3(this.transform.position.x, this.transform.position.y+0.2f, this.transform.position.z);
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos1, 0.2f);
            // this.transform.position=v;
            // anim.SetBool("IsTouchButton", false);

            m_MirrorTurning.MirrowBack();
            }
        }
    }
}
