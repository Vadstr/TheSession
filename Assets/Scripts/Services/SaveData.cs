using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


static class SavePlayerData
{
    static public int LocationID;
    static public int StoryTrigger;
    static public List<float> OtherCaracteristics;
    static public float CoordinateOnSceneX;
    static public float CoordinateOnSceneY;
    static public string NameOfSave;
}

[Serializable]
public class SaveSerializable
{
    int LocationIDToSave;
    int StoryTriggerToSave;
    List<float> OtherCaracteristicsToSave;
    float CoordinateOnSceneXToSave;
    float CoordinateOnSceneYToSave;

    public SaveSerializable()
    {
        LocationIDToSave = 0;
        StoryTriggerToSave = 0;
        OtherCaracteristicsToSave = new List<float>();
        CoordinateOnSceneXToSave = 0;
        CoordinateOnSceneYToSave = 0;
    }

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + SavePlayerData.NameOfSave + ".dat");

        LocationIDToSave = SavePlayerData.LocationID;
        StoryTriggerToSave = SavePlayerData.StoryTrigger;
        OtherCaracteristicsToSave = SavePlayerData.OtherCaracteristics;
        CoordinateOnSceneXToSave = SavePlayerData.CoordinateOnSceneX;
        CoordinateOnSceneYToSave = SavePlayerData.CoordinateOnSceneY;
        bf.Serialize(file, this);
        file.Close();
        Debug.Log("correct save");
    }

    public void LoadGame(string nameOfSave)
    {
        if (File.Exists(Application.persistentDataPath + "/" + nameOfSave + ".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
              File.Open(Application.persistentDataPath
              + "/" + nameOfSave + ".dat", FileMode.Open);
            var data = (SaveSerializable)bf.Deserialize(file);
            file.Close();
            SavePlayerData.LocationID = data.LocationIDToSave;
            SavePlayerData.StoryTrigger = data.StoryTriggerToSave;
            SavePlayerData.OtherCaracteristics = data.OtherCaracteristicsToSave;
            SavePlayerData.CoordinateOnSceneX = data.CoordinateOnSceneXToSave;
            SavePlayerData.CoordinateOnSceneY = data.CoordinateOnSceneYToSave;
            SavePlayerData.NameOfSave = nameOfSave;
            Debug.Log("correct load");
        }
    }

    public bool UniquiSaveName(string saveName) 
    {
        var namesOfSaves = GetNamesofSavesList();
        if (namesOfSaves.Count != 0)
        {
            foreach (var name in namesOfSaves)
            {
                if (name.ToLower() == saveName.ToLower())
                {
                    Debug.Log("not uniqui save name");
                    return false;
                }
            }
        }
        Debug.Log("uniqui save name");
        return true;
    }

    List<string> GetNamesofSavesList() 
    {
        var namesOfSaves = new List<string>();
        foreach (var file in GetAllSavesFile()) 
        {
            var nameOfSave = file.FullName.Substring(Application.persistentDataPath.Length + 1, file.FullName.Length - Application.persistentDataPath.Length - 5);
            namesOfSaves.Add(nameOfSave);
        }

        if (namesOfSaves.Count == 0) 
        {
            Debug.Log("zero saves");
            /*throw new ArgumentNullException("0 Saves");*/
        }
        return namesOfSaves;
    }

    public List<FileInfo> GetAllSavesFile() 
    {
        var path = new List<FileInfo>();
        DirectoryInfo directoryInfo = new DirectoryInfo(Application.persistentDataPath);
        foreach (var file in directoryInfo.GetFiles())
        {
            if (Path.GetExtension(file.FullName) == ".dat")
            {
                path.Add(file);
            }
        }
        Debug.Log($"we have {path.Count} save");
        return path;
    }
}