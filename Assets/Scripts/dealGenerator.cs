﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dealGenerator : MonoBehaviour
{ 
    public Transform dealPrefab;
    public Transform goal;
    private bool dealExists = false;
    List<Vector3> dealPositions = new List<Vector3>();

    void Start()
    {
        //dealPositions.Add(new Vector3(0,0,10));
        //dealPositions.Add(new Vector3(5,0,13));
        //dealPositions.Add(new Vector3(-5,0,13));

        //FIRST
        dealPositions.Add(new Vector3(-12.5f, 0, 11.06f));
        dealPositions.Add(new Vector3(-12.5f, 0, 27.77f));
        dealPositions.Add(new Vector3(-12.5f, 0, -14.09f));
        dealPositions.Add(new Vector3(-12.5f, 0, -30.8f));
        dealPositions.Add(new Vector3(12.5f, 0, -22));
        dealPositions.Add(new Vector3(12.5f, 0, 20));
        //SECOND
        dealPositions.Add(new Vector3(-29.66f, 0, 9));
        dealPositions.Add(new Vector3(-29.66f, 0, 15));
        dealPositions.Add(new Vector3(-29.66f, 0, 23));
        dealPositions.Add(new Vector3(-29.66f, 0, 31));
        dealPositions.Add(new Vector3(-29.66f, 0, 31));
        dealPositions.Add(new Vector3(-29.66f, 0, -11));
        dealPositions.Add(new Vector3(-29.66f, 0, -17));
        dealPositions.Add(new Vector3(-29.66f, 0, -28));
        dealPositions.Add(new Vector3(-29.66f, 0, -34));
        dealPositions.Add(new Vector3(27.1f, 0, -35));
        dealPositions.Add(new Vector3(27.1f, 0, -28));
        dealPositions.Add(new Vector3(27.1f, 0, -18));
        dealPositions.Add(new Vector3(27.1f, 0, -10.5f));
        dealPositions.Add(new Vector3(27.1f, 0, -35));
        dealPositions.Add(new Vector3(27.1f, 0, 7.5f));
        dealPositions.Add(new Vector3(27.1f, 0, 14));
        dealPositions.Add(new Vector3(27.1f, 0, 23.5f));
        dealPositions.Add(new Vector3(27.1f, 0, 29.5f));
        dealPositions.Add(new Vector3(36.6f, 0, 27.5f));
        dealPositions.Add(new Vector3(36.6f, 0, 27.5f));
        dealPositions.Add(new Vector3(36.6f, 0, 10.6f));
        dealPositions.Add(new Vector3(36.6f, 0, -14.4f));
        dealPositions.Add(new Vector3(36.6f, 0, -31.7f));
        dealPositions.Add(new Vector3(-41, 0, -22));
        dealPositions.Add(new Vector3(-41, 0, -20));
        //THIRD
        dealPositions.Add(new Vector3(-26.09f, 0, 40));
        dealPositions.Add(new Vector3(0, 0, 40));
        dealPositions.Add(new Vector3(26.09f, 0, 40));
        dealPositions.Add(new Vector3(-26.09f, 0, -42));
        dealPositions.Add(new Vector3(26.09f, 0, -42));
        dealPositions.Add(new Vector3(-2.5f, 0, 19.6f));
        dealPositions.Add(new Vector3(2.5f, 0, 19.6f));
        dealPositions.Add(new Vector3(-2.5f, 0, -22.1f));
        dealPositions.Add(new Vector3(2.5f, 0, -22.1f)); 
    }

    void FixedUpdate ()
    {
        if (!dealExists)
        {
            createDeal();
        }
    }

    public void createDeal()
    {
        if (dealPositions.Count > 0)
        {
            Transform deal = null;
            int r = Random.Range(0,dealPositions.Count);

            deal = Instantiate(dealPrefab, dealPositions[0], Quaternion.identity);
            dealPositions.RemoveAt(r);

            //Hacer switch y cambiar 0 por r

            goal.transform.position = deal.transform.position + new Vector3(0f,4f,0f);

            //if (dealPositions.Count == 0)
            //{
            //    FindObjectOfType<gameManager>().winGame();
            //}
            
            dealExists = true;
        }
    }
}
