using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class CanvasManager : MonoBehaviour
{
    const int screen_HEIGHT = 1080;
    const int screen_WIDTH = 1920;

    public Canvas m_canvas;
    PointerEventData m_ped;

    public Slider slider;
    float maxValue = 30f;
    float sliderValue;



    public GameObject img_Perfect;


    [Header("����� ������ġ �׽�Ʈ��")]
    public GameObject img_Right;
    public GameObject img_Left;
    public Text text_Test;
    public Text text_touchCount;
    //public Text text_Right;
    private void Awake()
    {
        m_ped = new PointerEventData(null);
        slider.maxValue = maxValue;
        sliderValue = maxValue / 2;
        text_Test.text = "�ƹ��͵��ȴ���";
    }
    // Start is called before the first frame update
    void Start()
    {
        slider.value = sliderValue;
    }

    // Update is called once per frame
    void Update()
    {
        text_touchCount.text = Input.touchCount.ToString();
        if (Input.touchCount > 0 && Input.touchCount < 2)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.position.x >= screen_WIDTH / 2)
            {
                text_Test.text = "�����ʴ���";
            }
            else
                text_Test.text = "���ʴ���";

            
            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("Began");
            }


        }
        else if(Input.touchCount ==0) 
            text_Test.text = "�ƹ��͵��ȴ���";
        else if(Input.touchCount >= 2)
                text_Test.text = "���� ��������";

        //InputSystem();
        //slider.value = sliderValue;
    }

    void InputSystem()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_ped.position = Input.mousePosition;
            if (m_ped.position.x >= screen_WIDTH / 2)
            {
                Input_Right();
                //Debug.Log("������");
            }
            else
            {
                Input_Left();
                //Debug.Log("����"); 
            }

            MultiManager.instance.StateReset();
        }



        
    }
    void Input_Left()
    {
        if (MultiManager.instance.bPerfect)
        {
            MultiManager.instance.FuncJudge_Perfect();
            //SliderValueChange(2, true);
            StartCoroutine(CRT_sliderValueSmooth(3));
        }
        else if (MultiManager.instance.bGood)
        {
            MultiManager.instance.FuncJudge_Good();
            //SliderValueChange(1, true);
            StartCoroutine(CRT_sliderValueSmooth(2));

        }
        else if (MultiManager.instance.bBad)
        {
            MultiManager.instance.FuncJudge_Bad();
            //StartCoroutine(CRT_sliderValueSmooth());

        }
    }


    void Input_Right()
    {
    }

    IEnumerator CRT_sliderValueSmooth(float length)
    {
        float currentValue = slider.value;
        while (sliderValue <= currentValue + length)
        {
            //Debug.Log("�����̴� ����");
            sliderValue += length * Time.deltaTime * 3;
            slider.value = sliderValue;
            yield return new WaitForSeconds(0.01f);
        }
    }
    public IEnumerator CRT_sliderValueSmooth_Decrease(float length)
	{
        // sliderValue = ������ �����̴� �� ����
        // slider.value = ���� �����̴� �� ����
        // currentVaue = ���� �����̴� �� ��������
        float currentValue = slider.value;
		while (slider.value >= currentValue - length)
		{
            //Debug.Log("�����̴� ����");
            //Debug.Log(".value = " + slider.value + " Value  = " + (currentValue-length));
            sliderValue -= length  * Time.deltaTime * 3;
            slider.value = sliderValue;
            yield return new WaitForSeconds(0.01f);
        }
    }
}