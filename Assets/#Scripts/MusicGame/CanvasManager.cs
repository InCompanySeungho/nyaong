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
    private void Awake()
    {
        m_ped = new PointerEventData(null);
        slider.maxValue = maxValue;
        sliderValue = maxValue / 2;
    }
    // Start is called before the first frame update
    void Start()
    {
        slider.value = sliderValue;
    }

    // Update is called once per frame
    void Update()
    {
        InputSystem();
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
            //Debug.Log("����Ʈ");
            MultiManager.instance.FuncJudge_Perfect();
            //SliderValueChange(2, true);
            StartCoroutine(CRT_sliderValueSmooth(3));
        }
        else if (MultiManager.instance.bGood)
        {
            //Debug.Log("��");
            MultiManager.instance.FuncJudge_Good();
            SliderValueChange(1, true);

        }
        else if (MultiManager.instance.bBad)
        {
            //Debug.Log("����");
            MultiManager.instance.FuncJudge_Bad();
            SliderValueChange(1, false);

        }
    }


    void Input_Right()
    {
    }

    public void SliderValueChange(float length, bool inCrease)
    {
        //StartCoroutine(CRT_sliderValueSmooth(length, inCrease));
        /*
        if (inCrease)
            slider.value += length;
        else if (!inCrease)
            slider.value -= length;*/
    }

    IEnumerator CRT_sliderValueSmooth(float length)
    {
        float currentValue = slider.value;
        while (sliderValue <= currentValue + length)
        {
            Debug.Log("�����̴� ����");
            sliderValue += length / 10;
            slider.value = sliderValue;
            yield return new WaitForSeconds(0.02f);
        }
    }
}
    /*
            while (sliderValue <= slider.value - length)
            {
                Debug.Log("�����̴� ����");

                slider.value -= length / 10;
                yield return new WaitForSeconds(0.01f);

            }*/
    