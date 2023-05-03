using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxMoveTogether : MonoBehaviour
{
    // public GameObject child;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "box")
        {
            print("collide");
            other.gameObject.transform.SetParent(transform);
            print(other.transform.parent.gameObject);
            // print(parentTransform);
            // if(parentTransform.transform.position.y < this.transform.position.y){
            //     print(parentTransform.transform.position.y+ "fan" + this.transform.position.y);
            //     child.transform.SetParent(parentTransform);
                // Vector3 ptargetPos1 = new Vector3(parentTransform.transform.position.x, this.transform.position.y, this.transform.position.z);
                // this.transform.position=ptargetPos1;

            
            // obj.transform.SetParent(parent);
            // Vector3 targetPos = new Vector3(this.transform.position.x, this.transform.position.y-0.2f, this.transform.position.z);
            // this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, 0.2f);
            // m_MirrorTurning.MirrowTurn();
        }

        /*
    }*/

    }
}
