using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	public Vector3 v;
	public bool isDead = false;
	public Rigidbody2D rb2d;
	public Animator anim;
	public float IsJump = 0;
	public GameObject WinUI;
	public GameObject TimeUI;
	public GameObject coin;
	
	//public GameObject LoseUI;
	public GameObject DialogueUI;
	public bool IsFinish = false;
	public bool IsWin = false;
	//public WinImage m_WinImage;

	// Start is called before the first frame update
	void Start()
	{
		v = this.transform.position;
		rb2d = GetComponent<Rigidbody2D>();
		/////////Win.SetActive(false);

	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "ground" || other.gameObject.tag == "box")
		{
			IsJump = 0;
			///////////////////////Win.gameObject.SetActive(false);
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.tag == "spike")
		{
			isDead = true;
		}
		if (other.gameObject.tag == "portalStart")
		{
			this.transform.position= GameObject.Find("PortalEnd").transform.position;
		}
		if (other.gameObject.tag == "coin")
		{
			if(IsJump>0){
				IsJump-=1;
			}
			coin.gameObject.SetActive(false);
		}
	}


	//角色死亡函数
	public void IsFinished()
	{

		anim.SetBool("IsFinish", true);
		WinUI.gameObject.SetActive(true);
		Destroy(this, 2);
		Destroy(TimeUI);
	}


	//角色胜利函数
	public void Won()
	{
		anim.SetBool("IsWin", true);
		//LoseUI.gameObject.SetActive(true);
		Destroy(this, 2);
		Destroy(TimeUI);
		DialogueUI.SetActive(true);
	}

	
		/*////////////////////////////////////////////////////////////public void Retry()
		{
			SceneManager.LoadScene();
		}*/

		// Update is called once per frame
		void Update()
    {
        if (isDead){//死掉啦
			this.transform.position=v;
			anim.SetBool("ToRun", false);
			isDead=false;
		}
		//没死时主角色进行的一切动作
			//按上键，实现跳跃效果
			if (Input.GetKeyDown("up")){
				if (IsJump < 2){
				rb2d.velocity = Vector2.zero;
				rb2d.AddForce(new Vector2(0,250));
				anim.SetTrigger("ToJump");
				IsJump++;
				}
				
				//播放动画
				
			}
			
			
			//按右键，实现移动效果
			if (Input.GetAxisRaw("Horizontal") == 1){
				
				//转朝向
				if (transform.rotation != Quaternion.Euler(0,0,0f)){
					transform.rotation = Quaternion.Euler(0,0,0f);
					
				}
				
				//播放动画
				anim.SetBool("ToRun", true);

				
				//匀速运动
				// Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"),0.0f,0.0f);
				// transform.position = transform.position + Movement * Time.deltaTime*4;
				// ///////////////rb2d.AddForce(new Vector2(8,0));
				
			}
			else if (Input.GetAxisRaw("Horizontal") == -1){
				if (transform.rotation != Quaternion.Euler(0,180,0f)){
					transform.rotation = Quaternion.Euler(0,180,0f);
				}
				anim.SetBool("ToRun", true);
				// Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"),0.0f,0.0f);
				// transform.position = transform.position + Movement * Time.deltaTime*4;
				///////////////////rb2d.AddForce(new Vector2(-8,0));
			}
			else{
				anim.SetBool("ToRun", false);
			}

			Vector3 Movement = new Vector3(Input.GetAxisRaw("Horizontal"),0.0f,0.0f);
			transform.position = transform.position + Movement * Time.deltaTime*4;
		}
        // else //死了的后事
        // {
		// 	// anim.SetBool("IsFinish", true);//让角色播放动画
		// 	// WinUI.gameObject.SetActive(true);//调用失败UI
		// 	// Destroy(gameObject,0);//播完动画后销毁角色
			
		// 	// Invoke("InvokeTest",1f);
		// 	// Update();
			
		// }
			
    }
	

