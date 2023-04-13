using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnMap : MonoBehaviour
{
    private const float cord_x = -0.713f;
    private const float cord_y_base = -1.2f;
    private const float cord_y_upper = 0.4f;    
    private const float cord_z = 0.02f;
    private List<GameObject> list_base = new List<GameObject>();
    private List<GameObject> list_upper = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < 7; ++i)
        {
            GameObject clone = Instantiate(prefab, new Vector3(cord_x - 3f + 1.2f * i, cord_y_upper, cord_z), Quaternion.identity); 
            // создаем копию куба, который висит в позиции за камерой
            list_upper.Add(clone);                                                                     
            // Добавляем куб в список
        }
        for (int i = 0; i < 5; ++i)
        {
            GameObject clone = Instantiate(prefab, new Vector3(cord_x - 3f + 1.2f * i, cord_y_base, cord_z), Quaternion.identity); 
            // создаем копию куба, который висит в позиции за камерой
            list_base.Add(clone);                                                                     
            // Добавляем куб в список
        }
    }
    public GameObject prefab;
    private float cooldown = 0; // кулдаун между кубами, чтобы спавнить их ровно друг за другом

    private const int cap = 30; // максимальное количество кубов
    int gap_base = 0;
    int gap_upper = 0;

    public Text goals_count;
    public int cnt = 0;
    
    void Update()
    {

        if(list_base.Count == cap) // проверяем, не слишком ли много у нас кубов
        {
            Destroy(list_base[0]); // удаляем объект куба, чтобы он реально пропал из игры
            list_base.RemoveAt(0); // удаляем его из списка, он на 0ой позиции,
                                   // т.к. чем реньше добавили, тем он дальше уехал
        }
        
        if(list_upper.Count == cap) // проверяем, не слишком ли много у нас кубов
        {
            Destroy(list_upper[0]); // удаляем объект куба, чтобы он реально пропал из игры
            list_upper.RemoveAt(0); // удаляем его из списка, он на 0ой позиции,
                                    // т.к. чем реньше добавили, тем он дальше уехал
        }

        if (cooldown <= 0 && gap_upper != 0) // проверка, что проехал ровно один куб
        {
            GameObject clone = Instantiate(prefab, new Vector3(cord_x + 4.2f, cord_y_upper, cord_z), Quaternion.identity); 
            // создаем копию куба, который висит в позиции за камерой
            list_upper.Add(clone);                                                                     
            // Добавляем куб в список
        }
        
        if (cooldown <= 0 && gap_base != 0) // проверка, что проехал ровно один куб
        {
            GameObject clone = Instantiate(prefab, new Vector3(cord_x + 4.2f, cord_y_base, cord_z), Quaternion.identity); 
            // создаем копию куба, который висит в позиции за камерой
            list_base.Add(clone);                                                                     
            // Добавляем куб в список
        }

        float delta = 0.0043f; // смещение куба за фрейм
        foreach (GameObject cube in list_upper)
        {
            cube.transform.position = cube.transform.position + new Vector3(-delta, 0, 0); // смещение каждого куба 
        }
        foreach (GameObject cube in list_base)
        {
            cube.transform.position = cube.transform.position + new Vector3(-delta, 0, 0); // смещение каждого куба 
        }

        if (cooldown <= 0 && gap_base == 0 && gap_upper == 0)
        {
            float choose = Random.Range(0, 2);
            if (choose == 1)
            {
                gap_base = 1;
                GameObject clone = Instantiate(prefab, new Vector3(cord_x + 4.2f, cord_y_base, cord_z), Quaternion.identity); 
                // создаем копию куба, который висит в позиции за камерой
                list_base.Add(clone);                                                                     
                // Добавляем куб в список
            }
            else
            {
                gap_upper = 1;
                GameObject clone = Instantiate(prefab, new Vector3(cord_x + 4.2f, cord_y_upper, cord_z), Quaternion.identity); 
                // создаем копию куба, который висит в позиции за камерой
                list_upper.Add(clone);                                                                     
                // Добавляем куб в список
            }
        }

        if (cooldown <= 0) // проверка, что проехал ровно один куб
        {
            cooldown = 1.2f; // длина куба, чтобы считать на сколько мы должны сдвинуть все кубы,
                             // чтобы освободилось место для ещё одного
            if(gap_upper == 0)
            {
                cnt++;
                goals_count.text = "CЧЁТ:" + cnt;
                gap_upper = Random.Range(1, 5);
            }
            else
            {
                gap_upper--;
            }
            if(gap_base == 0)
            {
                cnt++;
                goals_count.text = "СЧЁТ:" + cnt;
                gap_base = Random.Range(1, 5);
            }
            else
            {
                gap_base--;
            }
        }

        cooldown -= delta; // счтаем на сколько ещё мы должны сдвинуть все кубы
    }
}
