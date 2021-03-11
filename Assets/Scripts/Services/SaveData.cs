using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


[Serializable]
class SaveData
{
    public int LocationID;
    public int StoryTrigger;
    public List<float> OtherCaracteristics;
    public Vector2 CoordinateOnScene;
}

public class SaveSerializable : MonoBehaviour
{
    int LocationIDToSave;
    int StoryTriggerToSave;
    List<float> OtherCaracteristicsToSave;
    Vector2 CoordinateOnSceneToSave;
    string NameOfSave;

    public SaveSerializable(string name)
    {
        LocationIDToSave = 0;
        StoryTriggerToSave = 0;
        OtherCaracteristicsToSave = new List<float>();
        CoordinateOnSceneToSave = new Vector2();
        NameOfSave = name;
    }

    void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/" + NameOfSave + ".dat");
        SaveData data = new SaveData();
        data.LocationID = LocationIDToSave;
        data.StoryTrigger = StoryTriggerToSave;
        data.OtherCaracteristics = OtherCaracteristicsToSave;
        data.CoordinateOnScene = CoordinateOnSceneToSave;
        bf.Serialize(file, data);
        file.Close();
    }

    void LoadGame(string nameOfSave)
    {
        if (File.Exists(Application.persistentDataPath
          + "/" + nameOfSave + ".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
              File.Open(Application.persistentDataPath
              + "/" + nameOfSave + ".dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            NameOfSave = nameOfSave;
            LocationIDToSave = data.LocationID;
            StoryTriggerToSave = data.StoryTrigger;
            OtherCaracteristicsToSave = data.OtherCaracteristics;
            CoordinateOnSceneToSave = data.CoordinateOnScene;
        }
        else
            throw new ArgumentNullException("Nothing to load");
    }

    bool UniquiSaveName(string saveName) 
    {
        var namesOfSaves = GetNamesofSavesList();
        foreach (var name in namesOfSaves) 
        {
            if (name == saveName) 
            {
                return false;
            }
        }
        return true;
    }

    List<string> GetNamesofSavesList() 
    {
        var namesOfSaves = new List<string>();
        foreach (var path in GetAllSavesPath()) 
        {
            var nameOfSave = path.Substring(Application.persistentDataPath.Length, path.Length - Application.persistentDataPath.Length - 4);
            namesOfSaves.Add(nameOfSave);
        }

        if (namesOfSaves.Count == 0) 
        {
            throw new ArgumentNullException("0 Saves");
        }
        return namesOfSaves;
    }

    List<string> GetAllSavesPath() 
    {
        var path = new List<string>();
        DirectoryInfo directoryInfo = new DirectoryInfo(Application.persistentDataPath);
        foreach (var file in directoryInfo.GetFiles())
        {
            if (Path.GetExtension(file.FullName) == "dat")
            {
                path.Add(file.FullName);
            }
        }
        return path;
    }
}