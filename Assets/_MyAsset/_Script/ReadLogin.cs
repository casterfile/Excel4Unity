using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReadLogin : MonoBehaviour
{
    List<string> ExcelData = new List<string>();
    [SerializeField] InputField username;
    [SerializeField] InputField password;
    // Start is called before the first frame update
    void Start()
    { 
        username.text = "test @gmail.com";
        password.text = "_seav123";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Login()
    {
        Read();
        Validation();
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

    void Validation()
    {
        for (int x = 0; x < ExcelData.Count; x++)
        {
            if(ExcelData[x].Length > 2)
            {
                print("ExcelData: " + ExcelData[x]);
                string data = ExcelData[x];
                string[] column = data.Split(char.Parse("¶"));
                if (username.text == column[2] && password.text == column[3])
                {
                    print("column[2]: " + column[2] + " || column[3]:" + column[3]);
                }
            }
            
        }
    }
}
