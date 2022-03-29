using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ImageShow : MonoBehaviour
{
	Sequence mySequence;
	// Start is called before the first frame update

	private void OnEnable()
	{
		mySequence.Restart();
	}
	void Start()
	{
		/*
		mySequence = DOTween.Sequence()
			.SetAutoKill(false)
			.OnStart(() =>
		{
			this.transform.localScale = Vector3.zero;
			this.GetComponent<CanvasGroup>().alpha = 0;
		})
	.Append(this.transform.DOScale(1, 1).SetEase(Ease.OutBounce))
	.Join(this.GetComponent<CanvasGroup>().DOFade(1, 1));*/
	//.SetDelay(0.3f));

		mySequence = DOTween.Sequence()
			.SetAutoKill(false)
			.Append(this.transform.DOScale(1, 1).From(0)
			.SetEase(Ease.OutBounce))
			.Join(GetComponent<CanvasGroup>().DOFade(1, 1).From(0)).Pause();  // pause : �ʱ�ȭ ���ڸ��� �ٷ� ������� �ʰ�.
		// OnStart���� �������ִ����� From�� �Ķ���� �� 0 ���� ���ؼ� �ʱⰪ�� 0 �� �ȴ�.
			
	}

	// Update is called once per frame
	void Update()
	{

	}
}
