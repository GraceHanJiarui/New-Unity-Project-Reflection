using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using ButtonTrigger;

public class MirrorTurning : MonoBehaviour
{
    // public Animator anim;
    public float zAngle;
    private Quaternion target;

    // Start is called before the first frame update
    void Start()
    {
        zAngle = this.transform.localEulerAngles.z;
        target = Quaternion.Euler(0,0,this.transform.localEulerAngles.z);

        //m_Transform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation=Quaternion.Slerp(this.transform.rotation,target,0.05f);
    }

    public void MirrowTurn()
    {
        if(System.Math.Abs(this.transform.localEulerAngles.z-90)<20){
            zAngle=180;
        }
        else if(System.Math.Abs(this.transform.localEulerAngles.z)<20){
            zAngle=90;
        }
        else if(System.Math.Abs(this.transform.localEulerAngles.z-180)<20){
            zAngle=270;
        }
        else if(System.Math.Abs(this.transform.localEulerAngles.z-270)<20){
            zAngle=0;
        }
        // zAngle = this.transform.localEulerAngles.z + 90f;
        target = Quaternion.Euler(0,0,zAngle);
        
        //  print("物体的原始旋转信息：" + transform.eulerAngles);
        //      transform.rotation = Quaternion.Euler(30, 30, 30);
        //      //transform.localRotation= Quaternion.Euler(30, 30, 30);
        //      print("物体的当前旋转信息：" + transform.eulerAngles);
        // transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
        // this.transform.Rotate(new Vector3(45, 45, 0),Space.Self);
        // anim.SetBool("ButtonDown", true);
        
    }

    public void MirrowBack()
    {
        // var rotangle = Quaternion.Euler(new Vector3(0,0,this.transform.eulerAngles.z-90));
        // print("物体的旋转hou：" + transform.eulerAngles);
        // transform.rotation=Quaternion.Slerp(transform.rotation,rotangle,Time.deltaTime);

       
        // print("物体的原始旋转信息：" + transform.eulerAngles);
        // transform.rotation = Quaternion.Euler(30, 30, 30);
        // //transform.localRotation= Quaternion.Euler(30, 30, 30);
        // print("物体的当前旋转信息：" + transform.eulerAngles);
        if(System.Math.Abs(this.transform.localEulerAngles.z-90)<20){
            zAngle=0;
        }
        else if(System.Math.Abs(this.transform.localEulerAngles.z)<20){
            zAngle=270;
        }
        else if(System.Math.Abs(this.transform.localEulerAngles.z-180)<20){
            zAngle=90;
        }
        else if(System.Math.Abs(this.transform.localEulerAngles.z-270)<20){
            zAngle=180;
        }
        target = Quaternion.Euler(0,0,zAngle);
    }

}

