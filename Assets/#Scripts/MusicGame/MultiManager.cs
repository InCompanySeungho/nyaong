using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiManager : MonoBehaviour
{
    public static MultiManager instance;

    public GameObject go_noteRed;
    public GameObject go_noteBlue;
    Queue<Note> randomNoteQueue = new Queue<Note>();

	private void Awake()
	{
		instance = this;
	}
	void Initialize(int initCount)
	{
		for (int i = 0; i < initCount; i++)
		{
			randomNoteQueue.Enqueue(CreateNewObject());
		}
	}
	Note CreateNewObject()
	{
		var newObj = Instantiate(go_noteRed).GetComponent<Note>(); // �ΰ��� ������ �������� �����ǰ� �غ�����
		newObj.gameObject.SetActive(false); // �����Ҷ��� ��Ȱ��ȭ���·�
		newObj.transform.SetParent(transform);
		newObj.transform.position = this.transform.position;
		Debug.Log(newObj.transform.position);
		return newObj;
	}

}
