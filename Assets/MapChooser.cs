using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChooser : MonoBehaviour
{
    public int LeafNum = 0;
    public bool IsSelect = false;
    public GameObject Lock;



    private void Start()
    {
        if(PlayerPrefs.GetInt("TotalNum", 0) >= LeafNum)
        {
            IsSelect = true;
        }
        if (IsSelect)
        {
            Lock.SetActive(false);

        }
    }
}
