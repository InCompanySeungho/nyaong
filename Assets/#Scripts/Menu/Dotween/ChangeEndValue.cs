using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ChangeEndValue : MonoBehaviour
{
    // Ʈ���� ��ǥ���� �ٲ� �� ChangeEndValue


    Tweener moveTween; // Tweener = Move �� ���� Ʈ���� ����Ѵ�.
    Vector3 initPos;
    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
        moveTween = transform.DOMove(initPos, 1).SetAutoKill(false); // �ڵ����� X( Tweener �� ��� ��Ȱ�� �Ѵ�)
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
		{
            //this.transform.DOKill();
            //this.transform.DOMove(Input.mousePosition, 1);
            moveTween.ChangeEndValue(Input.mousePosition, 1, true).Restart();
            // �Ķ����| 1: �� ��ǥ��, 2:�� Ʈ���ð�, 3:���� ���¿��� �ٷ� ������ ����

        }
        else if(Input.GetMouseButtonUp(0))
		{
            //this.transform.DOKill();
            //this.transform.DOLocalMove(Vector3.zero, 0.1f);
            moveTween.ChangeEndValue(initPos, 0.3f, true).Restart();
            // �Ķ����| 1: �� ��ǥ��, 2:�� Ʈ���ð�, 3:���� ���¿��� �ٷ� ������ ����

        }

        if(Input.GetKeyDown(KeyCode.Q))
		{
            moveTween.Kill();
            Debug.Log("Ʈ�� �����ؼ� ������ ����");
		}
    }
}
