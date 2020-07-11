using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dealGenerator : MonoBehaviour
{ 
    public Transform dealPrefab;
    private bool dealExists = false;
    List<Vector3> dealPositions = new List<Vector3>();

    void Start()
    {
        dealPositions.Add(new Vector3(0,0,10));
        //dealPositions.Add(new Vector3(5,0,13));
        //dealPositions.Add(new Vector3(-5,0,13));
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

            if (dealPositions.Count == 0)
            {
                FindObjectOfType<gameManager>().endGame();
            }
            
            dealExists = true;
        }
    }
}
