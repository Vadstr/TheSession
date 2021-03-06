﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuText : MonoBehaviour
{
    public Text text;
    public int textId;

    void Update()
    {
        string[,] allText = {{"En", "RU", "UA"},
                             {"The session", "Сессия", "Сесія"},
                             {"New Game", "Новая игра", "Нова гра"},
                             {"Continue", "Продолжить", "Продовжити"},
                             {"Autors", "Авторы", "Автори" },
                             {"Exit", "Выход", "Вихід" } ,
                             {"Input name for save", "Введите имя для сохранения", "Введіть назву для збереження"},
                             {"Start new game", "Начать новую игру", "Почати нову гру"} ,
                             {"Select one of save","Выберите одно из сохранений","Виберыть одне зі збережень" } ,
                             {"Save name","Имя сохранения","Ім'я збереження" } ,
                             {"Save time","Время сохранения","Час збереження" } ,
                             {"Progress","Прогресс","Прогрес" } ,
                             {"Select other name","Выбирите другое имя","Оберіть інше ім'я" } };
        text.text = allText[textId, LanguageID.languageID];
    }
}
