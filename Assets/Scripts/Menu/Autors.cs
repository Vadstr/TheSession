using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Autors : MonoBehaviour
{

    public IEnumerator ShowAutors(Text autors, int speed)
    {
        autors.gameObject.SetActive(true);
        autors.text = GetAutors();
        int i = 0;
        while (i < 1) 
        {
            autors.transform.Translate(Vector2.up * Time.deltaTime * speed);
            yield return new WaitForSeconds(0.001f);
            if (autors.transform.localPosition.y > 1500)
                i++;
        }
        autors.gameObject.SetActive(false);
        autors.transform.localPosition = new Vector2(0, -2400);
        yield return null;
    }

    public string GetAutors() 
    {
        int languageID = LanguageID.languageID;
        string[,] work = { {"\nAUTHOR OF THE IDEA\n", "\nDEVELOPER\n",   "\nARTIST\n",   "\nMUSIC BY\n",   "\nSPECIAL THANKS TO\n" },
                           {"\nАВТОР ИДЕИ\n",         "\nРАЗРАБОТЧИК\n", "\nХУДОЖНИК\n", "\nМУЗЫКА ОТ\n",  "\nОТДЕЛЬНОЕ СПАСИБО\n" },
                           {"\nАВТОР ІДЕЇ\n",         "\nРОЗРОБНИК\n",   "\nХУДОЖНИК\n", "\nМУЗИКА ВІД\n", "\nОКРЕМА ПОДЯКА\n" } };
        string[,] people = { {"Striletskiy Vadym\n", "Starodubcev Ilya\n", "Tennesse\n", "My mom\n",    "Danilyuk Denys\n" },
                             {"Стрилецькый Вадым\n", "Стародубцев Илья\n", "Tennesse\n", "Моей маме\n", "Данилюк Денис\n" }, 
                             {"Стрілецький Вадим\n", "Стародубцев Ілля\n", "Tennesse\n", "Моїй мамі\n", "Данилюк Денис\n" } };
        return work[languageID, 0]+ people[languageID, 0] + work[languageID, 1] + people[languageID, 0] + work[languageID, 2] + people[languageID, 0] +
            people[languageID, 1] + work[languageID, 3] + people[languageID, 2] + work[languageID, 4] + people[languageID, 3] + people[languageID, 4];
    }
}

