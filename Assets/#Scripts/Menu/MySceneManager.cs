using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MySceneManager : MonoBehaviour
{
	public CanvasGroup img_Fade; // ������ ���
	float fadeDuration = 2; // �����Ǵ� �ð�
	public GameObject go_Loading; // �ε� �ִϸ��̼� ������ ����ִ� ���� ������Ʈ
	public Text text_Loading; // �ۼ�Ʈ ������ �ؽ�Ʈ


	public InputField inputField_ID;
	public InputField inputField_PW;

	string answer_ID = "root";
	string answer_PW = "1234";
	public GameObject go_LoginView;
	public Button btn_Login;

	public static MySceneManager Instance
	{
		get
		{
            return instance;
		}
	}
    public static MySceneManager instance;
	private void Start()
	{
		if(instance != null)
		{
			Destroy(this.gameObject);
			return;
		}
		instance = this;

		DontDestroyOnLoad(this.gameObject);
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void Awake()
	{
		btn_Login.onClick.AddListener(btnFunc_Login);
		inputField_ID.Select();
	}
	private void Update()
    {
		if (Input.GetKeyDown(KeyCode.Tab)) tabkeyManager();
		if (Input.GetKeyDown(KeyCode.Return)) btnFunc_Login();
		//if(Input.GetKeyDown(keycode))
	}


	void tabkeyManager()
    {
		inputField_PW.Select();
    }
	void btnFunc_Login()
    {
		if(inputField_ID.text == answer_ID)
        {
			if(inputField_PW.text == answer_PW)
            {
				Debug.Log("�α��� ����!");
				MySceneManager.instance.LoadScene("2");
            }
			else
            {
				Debug.Log("��й�ȣ Ȯ����");
				inputField_PW.text = null;
            }
        }
		else
        {
			Debug.Log("�������� �ʴ� �����̴�");
			inputField_PW.text = null;
        }

    }



    #region Login
    private void OnDestroy()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}
	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		img_Fade.DOFade(0, fadeDuration) // alpha 0�Ǳ�
			.OnStart(() =>
			{
				go_Loading.SetActive(false); // �ε� �̹��� �Ⱥ�������
			})
			.OnComplete(() =>
			{
				img_Fade.blocksRaycasts = false;
			});
	}
	public void ChangeScene(string sceneName) //��ȯ�� �� �̸�
	{
		Debug.Log("ChangeScene");
		img_Fade.DOFade(1, fadeDuration).OnStart(() =>
		{
			img_Fade.blocksRaycasts = true; // Ŭ�� ����
		}).OnComplete(() =>
		{
			// �ε�ȭ�� ���� �� �ε� ����
			StartCoroutine(LoadScene(sceneName));
		});
    }


    IEnumerator LoadScene(string sceneName)
    {
        go_Loading.SetActive(true);

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false; // �ۼ�Ʈ �����̿� | �ۼ�Ʈ 100 �Ǹ� Ȱ��ȭ ��Ŵ

        float past_time = 0;
        float percentage = 0;

        while (!async.isDone)
        {
            yield return null;

            past_time += Time.deltaTime;

            if (percentage >= 90)
            {
                percentage = Mathf.Lerp(percentage, 100, past_time);

                if (percentage == 100)
                {
                    async.allowSceneActivation = true; // �� ��ȯ �غ� �Ϸ�(percentage �� 100�̴�)
                }
            }
            else
            {
                percentage = Mathf.Lerp(percentage, async.progress * 100f, past_time);
                if (percentage >= 90)
                    past_time = 0;
            }
            text_Loading.text = percentage.ToString("0") + "%";  // �ۼ�Ʈ ǥ��
        }
    }
    #endregion
}
