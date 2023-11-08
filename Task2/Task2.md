# АНАЛИЗ ДАННЫХ И ИСКУССТВЕННЫЙ ИНТЕЛЛЕКТ [in GameDev]
Отчет по лабораторной работе #2 выполнил:
- Тихонов Егор Станиславович
- РИ-220947

| Задание | Выполнение | Баллы |
| ------ | ------ | ------ |
| Задание 1 | * | 60 |
| Задание 2 | * | 20 |
| Задание 3 | * | 20 |

знак "*" - задание выполнено; знак "#" - задание не выполнено;

Работу проверили:
- к.т.н., доцент Денисов Д.В.
- к.э.н., доцент Панов М.А.
- ст. преп., Фадеев В.О.

[![N|Solid](https://cldup.com/dTxpPi9lDf.thumb.png)](https://nodesource.com/products/nsolid)

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

Структура отчета

- Данные о работе: название работы, фио, группа, выполненные задания.
- Цель работы.
- Задание 1.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Задание 2.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Задание 3.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Выводы.
- ✨Magic ✨

## Цель работы
Научиться передавать в Unity данные из Google Sheets с помощью Python.


## Задание 1
### Выберите одну из компьютерных игр, приведите скриншот её геймплея и краткое описание концепта игры. Выберите одну из игровых переменных в игре (ресурсы, внутри игровая валюта, здоровье персонажей и т.д.), опишите её роль в игре, условия изменения / появления и диапазон допустимых значений. Постройте схему экономической модели в игре и укажите место выбранного ресурса в ней.

![image](https://github.com/Seclud/Urfu-data-analysis/assets/82933148/acc0de9b-8d20-4a9b-bb49-e0d9f1116268)

Dota 2 - Это многопользовательская Моба игра. В ней сражаются 2 команды по 5 игроков. Цель игры: разрушить главное здание противника (трон).

### Рассмотрим роль золота в экономической модели игры

![Новый рисунок](https://github.com/Seclud/Urfu-data-analysis/assets/82933148/d876324f-2ffb-46df-83f4-b4a8eea52f01)

Кран: это источник золота в игре. В Dota 2 золото в основном генерируется за счет убийства вражеских юнитов (крипов, героев), разрушения вражеских построек или просто с течением времени (пассивный доход от золота).

Инвентарь: отображает текущие запасы золота игрока. Золото, которое есть у игрока, можно использовать для покупки предметов или услуг в игре.

Преобразователь: это механизм, с помощью которого золото превращается во что-то другое. В Dota 2 конвертером будет процесс траты золота на покупку предметов. Эти предметы усиливают героев.

Слив: это механизм, который удаляет золото из игры. В Dota 2 золото может быть потеряно при смерти героя игрока

## Задание 2
### С помощью скрипта на языке Python заполните google-таблицу данными, описывающими выбранную игровую переменную в выбранной игре (в качестве таких переменных может выступать игровая валюта, ресурсы, здоровье и т.д.). Средствами google-sheets визуализируйте данные в google-таблице (постройте график, диаграмму и пр.) для наглядного представления выбранной игровой величины.

#### [Таблица](https://docs.google.com/spreadsheets/d/1qe5CWBRvBljQd3sBNpIdxwo-UhRUvHJCBq1I025gHIE/edit#gid=0) доступна по ссылке
![image](https://github.com/Seclud/Urfu-data-analysis/assets/82933148/d01d7c34-a70a-4ba3-a894-45407bcbb321)

```
В таблице:
	первый столбик: минута игры
	второй столбик: кол-во золота у игрока
	третий столбик: изменение золота по сравнению с прошлой минутой
```

<details>
<summary>Скрипт python для генерации данных</summary>

```py
import gspread
import random
gc = gspread.service_account(filename='ivory-volt-367415-cc8a447ba86e.json')
sh = gc.open("UnityDataScienceLab2")

# Создаёт список кортежей, где каждый кортеж (время, золото)
# Игрок зарабатывает случайное количество золота в минуту, но теряет случайное количество золота на 3-й и 5-й минуте.
data = []
for i in range(12):
    if i in [2, 4]:  # Третья и пятая минута
        gold_change = -random.randint(100, 300)  # Теряет случайное кол-во золота
    else:
        gold_change = random.randint(100, 500)  # Получает случайное кол-во золота
    gold = max(0, data[i-1][1] + gold_change) if data else 600  # Начиная с 600 золота
    data.append((i, gold))

for i, (time, gold) in enumerate(data, start=1):
    sh.sheet1.update_cell(i, 1, time)
    sh.sheet1.update_cell(i, 2, gold)
```

</details>

## Задание 3
### Настройте на сцене Unity воспроизведение звуковых файлов, описывающих динамику изменения выбранной переменной. Например, если выбрано здоровье главного персонажа вы можете выводить сообщения, связанные с его состоянием.

![image](https://github.com/Seclud/Urfu-data-analysis/assets/82933148/82b6fa55-5ffa-472b-b89f-62ac6d537ecb) 
<details>
<summary>Код скрипта C# для звуков </summary>

```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class NeedMoreGoldScreept : MonoBehaviour
{
    public AudioClip goodSpeak;
    public AudioClip normalSpeak;
    public AudioClip badSpeak;
    private AudioSource selectAudio;
    private Dictionary<string, float> dataSet = new Dictionary<string, float>();
    private bool statusStart = false;
    private int i = 1;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GoogleSheets());
    }

    // Update is called once per frame
    void Update()
    {
        if (dataSet.Count == 0) return;
        if (dataSet["Min_" + i.ToString()] <= 200 & statusStart == false & i != dataSet.Count)
        {
            StartCoroutine(PlaySelectAudioBad()); 
            Debug.Log(string.Join(' ', dataSet["Min_" + i.ToString()], "У героя низкий гпм"));
        }

        if (dataSet["Min_" + i.ToString()] > 200 & dataSet["Min_" + i.ToString()] < 300 & statusStart == false & i != dataSet.Count)
        {
            StartCoroutine(PlaySelectAudioNormal()); 
            Debug.Log(string.Join(' ', dataSet["Min_" + i.ToString()], "У героя средний гпм"));
        }

        if (dataSet["Min_" + i.ToString()] >= 300 & statusStart == false & i != dataSet.Count)
        {
            StartCoroutine(PlaySelectAudioGood());
            Debug.Log(string.Join(' ', dataSet["Min_" + i.ToString()],"У героя высокий гпм"));
        }
    }
    IEnumerator GoogleSheets()
    {
        UnityWebRequest curentResp = UnityWebRequest.
            Get("https://sheets.googleapis.com/v4/spreadsheets/1qe5CWBRvBljQd3sBNpIdxwo-UhRUvHJCBq1I025gHIE/values/Лист1?key=AIzaSyDN_YBF3QJQmtFSTmzaRk8_LORTIpDT9Vw   ");
        yield return curentResp.SendWebRequest();
        string rawResp = curentResp.downloadHandler.text;
        var rawJson = JSON.Parse(rawResp);
        foreach (var itemRawJson in rawJson["values"])
        {
            var parseJson = JSON.Parse(itemRawJson.ToString());
            var selectRow = parseJson[0].AsStringList;
            dataSet.Add(("Min_" + selectRow[0]), float.Parse(selectRow[2]));
        }
    }

    IEnumerator PlaySelectAudioGood()
    {
        statusStart = true;
        selectAudio = GetComponent<AudioSource>();
        selectAudio.clip = goodSpeak;
        selectAudio.Play();
        yield return new WaitForSeconds(3);
        statusStart = false;
        i++;
    }
    IEnumerator PlaySelectAudioNormal()
    {
        statusStart = true;
        selectAudio = GetComponent<AudioSource>();
        selectAudio.clip = normalSpeak;
        selectAudio.Play();
        yield return new WaitForSeconds(3);
        statusStart = false;
        i++;
    }
    IEnumerator PlaySelectAudioBad()
    {
        statusStart = true;
        selectAudio = GetComponent<AudioSource>();
        selectAudio.clip = badSpeak;
        selectAudio.Play();
        yield return new WaitForSeconds(4);
        statusStart = false;
        i++;
    }
}
```

</details>

[Ссылка на папку с проектом unity](https://github.com/Seclud/Urfu-data-analysis/tree/main/Task2/Lab2)

## Выводы

Я научился описывать ресурс в игровой экономике. Заполнять google-таблицу автоматически с помощью скрипта python. Связывать данные из таблицы со сценой Unity воспроизводить звуки, описывающие изменение переменной.

## Powered by

**BigDigital Team: Denisov | Fadeev | Panov**
