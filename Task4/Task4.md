# АНАЛИЗ ДАННЫХ И ИСКУССТВЕННЫЙ ИНТЕЛЛЕКТ [in GameDev]
Отчет по лабораторной работе #4 выполнил(а):
- Тихонов Егор Станиславович
- РИ-220947

Отметка о выполнении заданий (заполняется студентом):

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
Ознакомиться с основыми работы перцептрона, реализовать его обучение логическим операциям

## Задание 1
### в проекте Unity реализовать перцептрон, который умеет производить вычисления
- ### OR | дать комментарии о корректности работы

![image](https://media.discordapp.net/attachments/914593555526320151/1179252015172436068/image.png?ex=65791b05&is=6566a605&hm=fd8b5e60e639a592a221604c11fe417bde92f4abb6367ddf2e7268893f2f57a7&=&format=webp&width=1247&height=662)

#### Обучился за 5 эпох, корректно считает операции

- ### AND | дать комментарии о корректности работы
  
![image](https://media.discordapp.net/attachments/914593555526320151/1179252257619984444/image.png?ex=65791b3f&is=6566a63f&hm=a836f8e59b12b0e797ccf9fd3fe500e5f95b34225b21fa824012ab3c8c0633e8&=&format=webp&width=1247&height=662)
![image](https://media.discordapp.net/attachments/914593555526320151/1179252258152665158/image.png?ex=65791b3f&is=6566a63f&hm=0c72ec0d0a00e78b0c2bd73227a640ee4830deaaeefc1ee5d8c5897d34dec90e&=&format=webp&width=1247&height=662)

#### Обучился за 13 эпох, корректно считает операции

- ### NAND | дать комментарии о корректности работы

![image](https://media.discordapp.net/attachments/914593555526320151/1179252510704279622/image.png?ex=65791b7c&is=6566a67c&hm=4fb2d60b693024c0e3f2192144139e600ac43d943da0933cddf4311d18e56f33&=&format=webp&width=1247&height=662)
![image](https://media.discordapp.net/attachments/914593555526320151/1179252511127896114/image.png?ex=65791b7c&is=6566a67c&hm=573fb0c0323f2f8fd58bd5bf4638b2cd84baaf9ee2b8485c4fc018f9d7125b8e&=&format=webp&width=1247&height=662)

#### Обучился за 11 эпох, корреткно считает операции

- ### XOR | дать комментарии о корректности работы

![image](https://media.discordapp.net/attachments/914593555526320151/1179252800006406279/image.png?ex=65791bc0&is=6566a6c0&hm=35f044358b58ca7e31050bbef17552ac7a2dae6391492feb3e3ae94cbbe79750&=&format=webp&width=1247&height=662)

#### Не смог научится корректно считать XOR, потому что не может четко провести границу, для правильного и неправильного ответа



## Задание 2
### Построить графики зависимости количества эпох от ошибки  обучения. Указать от чего зависит необходимое количество эпох обучения.

![image](https://media.discordapp.net/attachments/914593555526320151/1179260312126488716/image.png?ex=657922c0&is=6566adc0&hm=189576dc50b4f206a49d03f2c86275fbd869fd6d6050bbeeaecbe3aab8bbad02&=&format=webp&width=946&height=592)
[Таблица](https://docs.google.com/spreadsheets/d/1PmL7G05f914hMwYdI4-4fhMW7YPjLFXcYRHd9J1Im-I/edit?usp=sharing)

Необходимое количество эпох обучения зависит от сложности функции, ее линейной сепарабельности, порядка входа данных и изначальных весов.

Для функции, у которой сложно провести прямую линию, для однозначного отделения результатов (XOR), перцептрон не смог обучится. Для функций AND, NAND, OR было затрачено немного эпох, потому что это простые функции. Разница в количестве эпох обучения OR и AND/NAND, вероятно можно объяснить тем, что в функции AND другой порядок следования выходных значений и тем, что изначально были выбранны случайные веса, далекие от необходимых значений.

## Задание 3
### Построить визуальную модель работы перцептрона на сцене Unity.

![image](https://media.discordapp.net/attachments/914593555526320151/1179278586268614697/image.png?ex=657933c4&is=6566bec4&hm=6d168e6a496d76837b633dc4407caeaf304b7126da68ee8032394c7f535094da&=&format=webp&width=1247&height=662)

#### Я создал сцену в unity с интерфейсом, где можно выбрать функцию, на основе которой обучался перцептрон и значение, подающиеся на вход. Левые кубики представляют входные данные, правый кубик - выходные

<details>
<summary>Скрипт для взаиомдействия с интерфейсом</summary>

```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CubeController : MonoBehaviour
{
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    public TMP_Dropdown functionDropdown;
    public TMP_Dropdown input1Dropdown;
    public TMP_Dropdown input2Dropdown;
    public Perceptron perceptronAND;
    public Perceptron perceptronOR;
    public Perceptron perceptronNAND;
    public Perceptron perceptronXOR;
    private Perceptron activePerceptron;

    void Start()
    {
        activePerceptron = perceptronOR;

        functionDropdown.value = 0;
        functionDropdown.RefreshShownValue();

        input1Dropdown.value = 0;
        input1Dropdown.RefreshShownValue();

        input2Dropdown.value = 0;
        input2Dropdown.RefreshShownValue();

        functionDropdown.onValueChanged.AddListener(delegate { ChangeActivePerceptron(functionDropdown.value); UpdateOutputCubeColor(); });
        input1Dropdown.onValueChanged.AddListener(delegate { UpdateCubeColor(cube1, input1Dropdown.value); UpdateOutputCubeColor(); });
        input2Dropdown.onValueChanged.AddListener(delegate { UpdateCubeColor(cube2, input2Dropdown.value); UpdateOutputCubeColor(); });
    }

    void ChangeActivePerceptron(int index)
    {

        activePerceptron = index switch
        {
            1 => perceptronAND,
            0 => perceptronOR,
            2 => perceptronNAND
        };
    }

    void UpdateCubeColor(GameObject cube, int value)
    {
        Color color = value == 1 ? Color.white : Color.black;
        cube.GetComponent<Renderer>().material.color = color;
    }

    void UpdateOutputCubeColor()
    {
        double output = activePerceptron.CalcOutput(input1Dropdown.value, input2Dropdown.value);
        UpdateCubeColor(cube3, output == 1 ? 1 : 0);
    }
}

```
</details>


## Выводы

В этой работе я ознакомилсяс принципом работы перцептрона, обучил его логическим функциям OR, AND, NAND. Сделал сцену на юнити с визуализацией его работы.

| Plugin | README |
| ------ | ------ |
| Dropbox | [plugins/dropbox/README.md][PlDb] |
| GitHub | [plugins/github/README.md][PlGh] |
| Google Drive | [plugins/googledrive/README.md][PlGd] |
| OneDrive | [plugins/onedrive/README.md][PlOd] |
| Medium | [plugins/medium/README.md][PlMe] |
| Google Analytics | [plugins/googleanalytics/README.md][PlGa] |

## Powered by

**BigDigital Team: Denisov | Fadeev | Panov**