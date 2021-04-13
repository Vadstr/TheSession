using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class ShowSaves : MonoBehaviour
{
    public static GameObject showSavePanel;
    public static GameObject content;

    public static void ShowSavesAndData(List<FileInfo> fileInfos)
    {
        var rtContent = (RectTransform)content.transform;
        var rtShowSwveFromPanel = (RectTransform)showSavePanel.transform;
        float contentHeight = fileInfos.Count * (rtShowSwveFromPanel.rect.height + 15);
        rtContent.sizeDelta = new Vector2(rtContent.sizeDelta.x, contentHeight);
        var positionOfSavePanel = showSavePanel.transform.localPosition.y;

        var Names = SaveSerializable.GetNamesofSavesList(fileInfos);
        var Dates = SaveSerializable.GetDateTimesOfLastOpenSaves(fileInfos);
        for(int i = 0; i < fileInfos.Count; i++)
        {
            var save = Instantiate(showSavePanel, content.transform);
            save.transform.localPosition = new Vector3(530, positionOfSavePanel, 0);
            positionOfSavePanel -= 110;
            var SavePanel = save.transform.Find("SavePanel");
            var SaveNamePanel = SavePanel.transform.Find("SaveNamePanel");
            var SaveTimePanel = SavePanel.transform.Find("SaveTimePanel");
            var NameText = SaveNamePanel.GetComponentInChildren<Text>();
            var DateText = SaveTimePanel.GetComponentInChildren<Text>();

            NameText.text = Names[i];
            DateText.text = Dates[i].ToString();
            
        }
    }
}


