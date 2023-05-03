using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlLaser : MonoBehaviour
{
    public LineRenderer laserD;
    public bool IsLaser = true;
    // Start is called before the first frame update
    void Start()
    {
    }
    void OnTriggerStay2D(Collider2D other)
	{

		if (other.gameObject.tag == "Player")
		{
			 if (Input.GetKeyDown(KeyCode.Space))
            {
                IsLaser = !IsLaser;
                print("is triggered");
                laserD.gameObject.SetActive(IsLaser);
            }
            
        }
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
