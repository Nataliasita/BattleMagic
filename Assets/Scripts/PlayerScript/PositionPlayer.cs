using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPlayer : MonoBehaviour
{
    public float PosX;
    public float PosY;
    public float PosZ;

    public Vector3 PositionEnd;
    void Start()
    {
        //  LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F6))
        {
            SaveData();
        }
        if(Input.GetKeyDown(KeyCode.F6))
        {
            LoadData();
        }
    }

    public void SaveData(){
        PlayerPrefs.SetFloat("PositionX", transform.position.x);
        PlayerPrefs.SetFloat("PositionY", transform.position.y);
        PlayerPrefs.SetFloat("PositionZ", transform.position.z);
        Debug.Log("Datos guardado correctamente");
    }

    public void LoadData(){
        PosX= PlayerPrefs.GetFloat("PositionX");
        PosY= PlayerPrefs.GetFloat("PositionY");
        PosZ= PlayerPrefs.GetFloat("PositionZ");

        PositionEnd.x = PosX;
        PositionEnd.y = PosY;
        PositionEnd.z = PosZ;

       transform.position= PositionEnd;
    }
}
