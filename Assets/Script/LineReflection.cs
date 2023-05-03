using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*using Vectrosity;
public class LineReflection : MonoBehaviour
    {
        private VectorLine myLine;//绘制反射光线
        
        void Start()
        {
        }
        
        void Update()
        {
            v0 = GameObject.Find("origin").transform.position;
                //绘制反射光线...
                fanShe= Vector3.Reflect(hit.point - v0, hit.normal);
                myLine = VectorLine.SetRay3D(Color.blue, 0.1f, hit.point, fanShe);
                myLine.lineWidth = 4.0f; 
        }
}
*/




public class LineReflection : MonoBehaviour
{
	public LineRenderer laser;
	public List<Vector3> laserPoint = new List<Vector3>();
	public LineRenderer reader;
	//public Animator anim;
	public float FireSpeed = 1f;

	public TreeReaction m_TreeReaction;
	public BackgroundShining m_BackgroundShining;
	public Player m_Player;

	public GameObject mirrorDL;
	public GameObject mirrorUL;
	public GameObject mirrorUR;
	public GameObject mirrorDR;
	public GameObject mirrorDL1;

	public bool Condition1 = false;

	////////////////////////public GameObject Win;

	// Start is called before the first frame update
	void Start()
	{
		reader = GetComponent<LineRenderer>();
		m_TreeReaction = GameObject.Find("Point Light 2D").GetComponent<TreeReaction>();
		m_BackgroundShining = GameObject.Find("Freeform Light 2D").GetComponent<BackgroundShining>();
	}

	void OnTriggerStay2D(Collider2D other)
	{

		if (other.gameObject.tag == "ShootPoint")
		{
			Condition1 = true;
		}
        else
        {
			Condition1 = false;
		}
	}

	// Update is called once per frame
	void Update()
	{
		///////////////////var hitt = Physics2D.Raycast(transform.position, transform.right);
		////////////////////laserPoint.Add(hitt.point);
		//transform.Rotate( eulers: Vector3.forward*10f*Time.deltaTime);
		//if (Position1.x == -13.3 && Position1.y == -1){
		///////////////////if (hitt.collider.name.Equals("ShootPoint")) {
			if (Input.GetKey(KeyCode.Space) && Condition1 == true)
			{
			
				laser.gameObject.SetActive(true);
				CastLaser();

				laser.positionCount = laserPoint.Count;
				laser.SetPositions(laserPoint.ToArray());
				/*for(var i : int = 0; i < lengthOfLineRenderer; i++){

			var pos:Vector3(i * 0.5, Mathf.Sin(i + Time.time), 0);

				lineRenderer.SetPosition(i, pos);}*/
			
			}
		
		else
		{
			laser.gameObject.SetActive(false);
		}

	}
	void CastLaser()
	{

		laserPoint.Clear();
		var startPoint = transform.position;
		
		var direction = transform.right;
		laserPoint.Add(startPoint);
		//transform.localScale = new Vector3(1.01f * Time.deltaTime, 1f, 1f);

		//Ray ray = new Ray(transform.position, transform.forward);
		//RaycastHit hitInfo;
		//bool isHit = Physics.Raycast(ray, out hit, 5f, 1 << 0, QueryTriggerInteraction.Collide);
		/*if (Physics.Raycast(ray, out hitInfo))
		{
			lineRenderer.SetPosition(hitInfo.point);
		}
		*/
		int i = 0;
		do
		{
			startPoint += transform.forward * FireSpeed * Time.deltaTime;
			var hit = Physics2D.Raycast(startPoint, direction);
			laserPoint.Add(hit.point);
			if (hit.collider.name.Equals("Point Light 2D"))
			{
				//anim.SetBool("IsWin", true);
				m_TreeReaction.Win();
				m_BackgroundShining.Win();
				m_Player.Won();
				//////////////////////Win.SetActive(true);

			}
			if (hit.collider.tag.Equals("Mirrow"))
			{
				direction = Vector2.Reflect(hit.point - (Vector2)startPoint, hit.normal);
				startPoint = (Vector3)hit.point + direction * 0.01f;
				if (hit.collider.name.Equals("mirrorDL"))
				{
					mirrorDL.gameObject.SetActive(true);
				}
				else if (hit.collider.name.Equals("mirrorUL")) 
				{
					mirrorUL.gameObject.SetActive(true);
				}

				else if (hit.collider.name.Equals("mirrorUR")) 
				{
					mirrorUR.gameObject.SetActive(true);
				}

				else if (hit.collider.name.Equals("mirrorDR")) 
				{
					mirrorDR.gameObject.SetActive(true);
				}

				else if (hit.collider.name.Equals("mirrorDL1"))
				{
					mirrorDL1.gameObject.SetActive(true);
				}
			}
			i++;
		} while (i < 10);

		//SendActorHit(hit.transform.gameObject);
	}

}
