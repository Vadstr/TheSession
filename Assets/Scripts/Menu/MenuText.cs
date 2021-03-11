using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuText : MonoBehaviour
{
    public Text text;
    public int textId;
    public int languageID;

    void Update()
    {
        int languageID = LanguageID.languageID;
        string[,] allText = {{"En", "RU", "UA"},
                             {"The session", "Сессия", "Сесія"},
                             {"New Game", "Новая игра", "Нова гра"},
                             {"Continue", "Продолжить", "Продовжити"},
                             {"Autors", "Авторы", "Автори" },
                             {"Exit", "Выход", "Вихід" } ,
                             {"Input name for save", "Введите имя для сохранения", "Введіть назву для збереження"},
                             {"Start new game", "Начать новую игру", "Почати нову гру"} };
        text.text = allText[textId, languageID];
    }
}
