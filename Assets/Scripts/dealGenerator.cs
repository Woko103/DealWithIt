using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dealGenerator : MonoBehaviour
{ 
    public Transform dealPrefab;
    private bool dealExists = false;

    void FixedUpdate ()
    {
        if (!dealExists)
        {
            createDeal();
        }
    }

    public void createDeal() {
        Transform deal = null;
        deal = Instantiate(dealPrefab, new Vector3(0, 1, 10), Quaternion.identity);
        dealExists = true;
    }
}
