using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLevel : MonoBehaviour
{
    public UIManager UIManager;
    public soundManager soundManager;
    public GameManager Manager;

    // public GameObject treeChangeLevel1;
    // public GameObject treeChangeLevel2;
    // public GameObject treeChangeLevel3;
    [SerializeField] bool lv1;
    [SerializeField] bool lv2;
    [SerializeField] bool lv3;

    void Start()
    {
       
        soundManager = GameObject.Find("SoundManager").GetComponent<soundManager>();
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && lv1 == true)
        {
            
            Manager.Level1();
            
        }
        if (other.gameObject.CompareTag("Player") && lv2 == true)
        {
            // soundManager.Instance.Play(4);
            Manager.Level2();
        }
        if (other.gameObject.CompareTag("Player") && lv3 == true)
        {
            // soundManager.Instance.Play(4);
            Manager.Level3();
        }

    }

    // public void InactiveObjectChangeLevel()
    // {
    //     treeChangeLevel1.SetActive(false);
    // }
    
}
