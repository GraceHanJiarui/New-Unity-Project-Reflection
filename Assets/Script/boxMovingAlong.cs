using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxMovingAlong : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay2D(Collision2D other)
	{
        if(other.gameObject.tag == "Mirrow" || other.gameObject.tag == "box"){
            Vector3 targetPos1 = new Vector3(other.transform.position.x, other.transform.position.y, this.transform.position.z);
            this.transform.position =targetPos1;
        }
    }
	
}
