using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ShowSaves : MonoBehaviour
{
    static public GameObject content;
    static public GameObject savePanel;
    static public Text nameOfSave;
    static public Text timeOfSave;

    public static void ShowSavesAndData(List<FileInfo> fileInfos)
    {
        var savematerial = new ShowSaves();
        Instantiate(savePanel, content.transform);
    }
}
