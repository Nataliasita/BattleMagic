using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject containerHistory;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("OffHistory", 10f);
    }

    void OffHistory()
    {
        containerHistory.SetActive(false);
    }

}
