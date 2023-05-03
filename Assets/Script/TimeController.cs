using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class TimeController : MonoBehaviour
{

        //private int totaltime1 = 5;
        private int totaltime2 = 60;
        private float intervaletime = 1;
        //public Text countdown1text;
        public Text countdown2text;
        public GameObject Win;
    public Player m_Player;
    public Animator anim;
    public GameObject Player;
    public bool isDead = false;
    
    // Start is called before the first frame update
    void Start()
    {
        //countdown1text.text = string.Format("{0:00}:{1:00}", (int)totaltime1 / 60, (float)totaltime1 % 60);
        countdown2text.text = string.Format("{0:00}:{1:00}", (int)totaltime2 / 60, (float)totaltime2 % 60);
        m_Player = GameObject.Find("Player").GetComponent<Player>();
        //StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update()
    {


        if (Player) {
            int M = (int)(totaltime2 / 60);
            float S = totaltime2 % 60;
            if (totaltime2 > 0)
            {
                //Win.gameObject.SetActive(false);
                intervaletime -= Time.deltaTime;
                if (intervaletime <= 0)
                {
                    intervaletime += 1;
                    totaltime2--;
                    countdown2text.text = string.Format("{0:00}:{1:00}", M, S);

                }
            }
            if (totaltime2 <= 0)
            {

                this.anim.SetBool("IsDestroy", true);

                m_Player.IsFinished();
                Win.gameObject.SetActive(true);
                //Win.anim.SetBool("IsWin", true);
                //m_WinImage.Win();
            } }
        }

    }

    

