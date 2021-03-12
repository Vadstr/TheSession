using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class LanguageID
{
    public static int languageID;
}

[Serializable]
public class LanguageIDAccessor 
{
    public int languageID;
    public void SaveLanguageID() 
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/LanguageID.lan");
        this.languageID = LanguageID.languageID;
        bf.Serialize(file, this);
        file.Close();
    }

    public void LoadLanguageID() 
    {
        if (File.Exists(Application.persistentDataPath + "/LanguageID.lan"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/LanguageID.lan", FileMode.Open);
            var data = (LanguageIDAccessor)bf.Deserialize(file);
            file.Close();
            LanguageID.languageID = data.languageID;
        }
    }
}