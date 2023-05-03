using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPressButton : MonoBehaviour
{
    bool IsLaser = true;
    public GameObject laserD;
    int somethingStay=0;
    // Start is called before the first frame update
    void Start()
    {
        
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
                IsLaser = false;
                // print("is triggered");
                Vector3 targetPos = new Vector3(this.transform.position.x, this.transform.position.y-0.2f, this.transform.position.z);
                this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, 0.2f);
                laserD.gameObject.SetActive(IsLaser);
            }
            somethingStay++;
            print(somethingStay);
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "box" || other.gameObject.tag == "Mirrow")
        {
            somethingStay--;
            if(somethingStay==0){
                IsLaser = true;
                print("is triggered");
                Vector3 targetPos = new Vector3(this.transform.position.x, this.transform.position.y+0.2f, this.transform.position.z);
                this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, 0.2f);
                laserD.gameObject.SetActive(IsLaser);
            }
        }
    }
}
