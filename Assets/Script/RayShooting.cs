using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooting : MonoBehaviour
{
	public Animator anim;
	
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    if (Input.GetKey(KeyCode.Space)){
		  anim.SetBool("IsShooting", true);
    }
    else {
      anim.SetBool("IsShooting", false);
    }
	
}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag=="Mirrow"){
			anim.speed = 0.0f;
			
		}
}
}