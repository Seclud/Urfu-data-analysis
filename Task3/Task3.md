# АНАЛИЗ ДАННЫХ И ИСКУССТВЕННЫЙ ИНТЕЛЛЕКТ [in GameDev]
Отчет по лабораторной работе #3 выполнил:
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
- Задание 1.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Задание 2.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Задание 3.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Выводы.
- ✨Magic ✨

## Цель работы
Разработать оптимальный баланс для десяти уровней игры Dragon Picker


## Задание 1
### Предложите вариант изменения найденных переменных для 10 уровней в игре. Визуализируйте изменение уровня сложности в таблице. 

Переменные
Speed - отвечает за скорость движения дракона
chanceDirection - Шанс изменить направление движения
leftRightDistance - Максимальное расстояние, которое дракон может пролететь на сцене
timeBetweenEggDrops - отвечает за время между сбросом яиц

Я решил изменять эти параметры (увеличивать или уменьшать) для увеличения сложности. Изменение параметров было отображено на столбчатой диаграмме.  
Изменение уровня сложности решил на графике соотнести с изменением скорости, так как этот параметр наиболее сильно влияет на сложность игры.
![image](https://github.com/Seclud/Urfu-data-analysis/assets/82933148/b1ed02e1-7635-4251-9895-643376a2d60e)

После теста первых данных и проведения балансировки, я решил добавить в скрипт дракона кулдаун на смену направления, чтобы дракон не застревал часто в одной точке, меняя постоянно свое направление

<details>
<summary>Измененный скрипт дракона</summary>

```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDragon : MonoBehaviour
{
    public GameObject dragonEggPrefab;
    public float speed = 1;
    public float timeBetweenEggDrops = 1f;
    public float leftRightDistance = 10f;
    public float chanceDirection = 0.1f;
    private float directionChangeCooldown = 2.0f; // Кулдаун в секундах
    private float timeSinceDirectionChange = 0.0f; // Время с последней смены направления

    void Start()
    {
        Invoke("DropEgg", 2f);

    }

    void DropEgg(){
        Vector3 myVector = new Vector3(0.0f, 5.0f, 0.0f);
        GameObject egg = Instantiate<GameObject>(dragonEggPrefab);
        egg.transform.position = transform.position + myVector;
        Invoke("DropEgg", timeBetweenEggDrops);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftRightDistance){
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftRightDistance){
            speed = -Mathf.Abs(speed);
        }
    }
    
    
    private void FixedUpdate() {
        timeSinceDirectionChange += Time.fixedDeltaTime; // Увеличиваю таймер

        if (Random.value < chanceDirection && timeSinceDirectionChange >= directionChangeCooldown)
        {
            speed *= -1;
            timeSinceDirectionChange = 0.0f; // Сбросить таймер
        }
    }
}
```

</details>

## Задание 2
### Создайте 10 сцен на Unity с изменяющимся уровнем сложности.

Репозиторий с проектом на юнити

https://github.com/Seclud/Urfu-data-analysis/tree/main/Task3/DragonPickerDefault-main

## Задание 3
### Решение в 80+ баллов должно заполнять google-таблицу данными из Python. В Python данные также должны быть визуализированы.

[Ссылка на таблицу](https://docs.google.com/spreadsheets/d/1gX0QoAih_NlwM91knSoOocxWcyhtXib_C4j9Bwn2Jdw/edit?usp=sharing)
<details>
<summary>Скрипт питона заполняющий таблицу</summary>

```py
import gspread
import matplotlib.pyplot as plt
import numpy as np

gc = gspread.service_account(filename='ivory-volt-367415-cc8a447ba86e.json')
sh = gc.open("UnityDataScienceLab3")

data = {
    'Level': [1, 2, 3, 4, 5, 6, 7, 8, 9, 10],
    'Dragon Speed': [4, 5, 6, 7, 8, 9, 10, 11, 12, 13],
    'Time Between Egg Drops': [2, 1.05, 1.1, 1.15, 1.2, 1.25, 1.3, 1.35, 1.4, 1.45],
    'Left-Right Distance': [10, 12, 14, 16, 18, 20, 20, 22, 22, 22],
    'Direction Change Probability': [0.01, 0.02, 0.03, 0.04, 0.05, 0.06, 0.07, 0.08, 0.09, 0.1]
}

data_balanced = {
    'Level': [1, 2, 3, 4, 5, 6, 7, 8, 9, 10],
    'Dragon Speed': [4, 6, 8, 10, 12, 14, 16, 18, 20, 22 ],
    'Time Between Egg Drops': [2, 1.85, 1.7, 1.55, 1.4, 1.25, 1.1, 0.95, 0.8, 0.65],
    'Left-Right Distance': [10, 12, 14, 16, 18, 20, 20, 20, 20, 20],
    'Direction Change Probability': [0.01, 0.02, 0.03, 0.04, 0.05, 0.06, 0.07, 0.08, 0.09, 0.1]
}

for i in range(len(data['Level'])):
    row = [data['Level'][i], data['Dragon Speed'][i], data['Time Between Egg Drops'][i],data['Left-Right Distance'][i], data['Direction Change Probability'][i]]
    cell_range = f'A{i+3}:E{i+3}'
    sh.worksheet('Лист2').update(cell_range, [row])
    
    row_balanced =[data_balanced['Level'][i], data_balanced['Dragon Speed'][i], data_balanced['Time Between Egg Drops'][i], data_balanced['Left-Right Distance'][i],data_balanced['Direction Change Probability'][i]]
    cell_range_balanced = f'A{i+16}:E{i+16}'
    sh.worksheet('Лист2').update(cell_range_balanced, [row_balanced])

barWidth = 0.25
fig, axs = plt.subplots(2, figsize =(12, 16)) 

br1 = np.arange(len(data['Level'])) 
br2 = [x + barWidth for x in br1] 
br3 = [x + barWidth for x in br2] 

axs[0].bar(br1, data['Dragon Speed'], color ='r', width = barWidth, 
        edgecolor ='black', label ='Dragon Speed') 
axs[0].bar(br2, data['Time Between Egg Drops'], color ='g', width = barWidth, 
        edgecolor ='black', label ='Egg Drop Frequency') 
axs[0].bar(br3, data['Direction Change Probability'], color ='b', width = barWidth, 
        edgecolor ='black', label ='Direction Change Probability') 

axs[0].set_xlabel('Level', fontweight ='bold', fontsize = 15) 
axs[0].set_ylabel('Value', fontweight ='bold', fontsize = 15) 
axs[0].set_xticks([r + barWidth for r in range(len(data['Dragon Speed']))])
axs[0].set_xticklabels(data['Level'])
axs[0].legend()

br4 = np.arange(len(data_balanced['Level'])) 
br5 = [x + barWidth for x in br4] 
br6 = [x + barWidth for x in br5] 

axs[1].bar(br4, data_balanced['Dragon Speed'], color ='r', width = barWidth, 
        edgecolor ='black', label ='Balanced Dragon Speed') 
axs[1].bar(br5, data_balanced['Time Between Egg Drops'], color ='g', width = barWidth, 
        edgecolor ='black', label ='Balanced Egg Drop Frequency') 
axs[1].bar(br6, data_balanced['Direction Change Probability'], color ='b', width = barWidth, 
        edgecolor ='black', label ='Balanced Direction Change Probability') 

axs[1].set_xlabel('Level', fontweight ='bold', fontsize = 15) 
axs[1].set_ylabel('Value', fontweight ='bold', fontsize = 15) 
axs[1].set_xticks([r + barWidth for r in range(len(data_balanced['Dragon Speed']))])
axs[1].set_xticklabels(data_balanced['Level'])
axs[1].legend()

plt.tight_layout()
plt.show() 
```

</details>  

Визуализация данных с помощью питона
![image](https://github.com/Seclud/Urfu-data-analysis/assets/82933148/f6561268-2544-4f1f-8692-b48beb229a16)


## Выводы
Я определил, от каких параметров зависила сложность игры DragonPicker. Создал разные уровни, на которых изменял сложность с помощью этих параметров. Отбалансировал изначально выбранные параметры. С помощью скрипта питона заполнил таблицу и визуализировал данные

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
