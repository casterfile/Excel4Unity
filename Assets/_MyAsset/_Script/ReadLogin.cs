using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReadLogin : MonoBehaviour
{
    List<string> ExcelData = new List<string>();
    [SerializeField] InputField username;
    [SerializeField] InputField password;
    [SerializeField] Text Output;
    // Start is called before the first frame update
    void Start()
    { 
        username.text = "test@gmail.com";
        password.text = "seav123";
        Output.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Login()
    {
        Read();
        Validation();
        if (Validation())
        {
            Output.text = "Successful Login";
        }
        else
        {
            Output.text = "Failed Login";
        }
    }

    void Read()
    {
        string path = Application.dataPath + "/Resources/ExcelFiles/Login.xlsx";
        Excel xls = ExcelHelper.LoadExcel(path);
        xls.ShowLog();


        string data = ExcelTable.excelData;
        string[] raw = data.Split(char.Parse("†"));
        for (int x = 0; x < raw.Length; x++)
        {
            ExcelData.Add(raw[x]);
        }
    }

    bool Validation()
    {
        bool istrue = false;
        for (int x = 0; x < ExcelData.Count; x++)
        {
            if(ExcelData[x].Length > 2)
            {
                //print("ExcelData: " + ExcelData[x]);
                //print("X: " + x);
                string data = ExcelData[x];
                string[] column = data.Split(char.Parse("¶"));

                string newUsername = column[2].Replace(" ", String.Empty);
                string newPassword = column[3].Replace(" ", String.Empty);
                if (username.text == newUsername && password.text == newPassword)
                {
                    istrue = true;
                }
            }
            
        }
        
        return istrue;
    }
}
