using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dic_Test : MonoBehaviour
{
    Dictionary<string, dic_Item> itemMap;
    // Start is called before the first frame update

    object a = 20;
    void Start()
    {
        //Debug.Log("A = " +  a);
        //Debug.Log("A*  = " + a.ToString());

        itemMap = new Dictionary<string, dic_Item>();

        string name;

        // ?������ �߰�
        name = "������ ȭ��";
        itemMap.Add(name, new dic_Item(name, 8, 15));

        name = "��ũ ��ġ";
        itemMap.Add(name, new dic_Item(name, 16, 4));

        name = "�������� ��";
        itemMap.Add(name, new dic_Item(name, 8, 10));

        name = "������ ��ǥ";
        //itemMap.Add(name, new dic_Itme(name, 13, 15));
        itemMap["������ ��ǥ"] = new dic_Item(name, 13, 15);

        // ?������ �˻�
        if (itemMap.ContainsKey ("��ũ ��ġ"))
        {
            dic_Item item = itemMap["��ũ ��ġ"];
            item.Show(); // �����۸�,�ѹ�, Ű, �ε��� �� ���
        }

        // ?������ ���
        var enumerator = itemMap.GetEnumerator(); // GetEnumerator = Dictionary<TKey, TValue> �� �ݺ��ϴ� �����ڸ� ��ȯ�Ѵ�.

        while(enumerator.MoveNext()) // MoveNext = �����ڸ� Dictionary<TKey, TValue> �� ���� ��ҷ� �̵��Ѵ�.
        {
            var pair = enumerator.Current;
            dic_Item item = pair.Value; // Dictionary �� Current �� ������ ��
            item.Show(); 
        }

        // ?������ ���� ( Ű )
        bool result = itemMap.Remove("�������� ��"); // bool Ÿ�� ����
        if(result)
        {
            Debug.Log("�������� �� ����");
        }

        // ?������ ���
        foreach(KeyValuePair<string, dic_Item> pair in itemMap)
        {
            dic_Item item = pair.Value; // itemMap(Dictoinary<string, dic_Item>() �߿��� pair
            item.Show();
        }

        // ? Dictionary ����
        itemMap.Clear();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
