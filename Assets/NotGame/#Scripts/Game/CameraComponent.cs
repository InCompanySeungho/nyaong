using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraComponent : MonoBehaviour
{
    // ���콺 �̵����� �þ� ���� ȸ��

    public Transform objectToFollow;
    public float followSpeed = 10f;
    public float sensitivity = 500;
    public float clampAngle = 70f;

    private float rotX;
    private float rotY;

    public Transform realCamera;
    public Camera Cam_Game;
    public Vector3 dirNormalized; // ���⸸ ��Ÿ����
    public Vector3 finalDir; // ���������� ������ ���Ͱ�

    public float minDistance; // �ּҰŸ�
    public float maxDistance; // �ִ�Ÿ�
    public float finalDistance;
    public float smoothness = 10f;



    // ���콺 �ٷ� ī�޶� �þ߰�����
    public GameObject characterHead;
    float wheelSpeed = 10.0f;
    public Transform cameraTarget;
    Vector3 worldDefaultForward; // �ٶ󺸰� �Ǵ� ����, ���� �׳� �������� �Ǿ�����. ĳ���Ͱ� �ٶ󺸴� �������� �����������
    private void Awake()
    {
        //t_Cam = this.gameObject.transform;
        Cam_Game = realCamera.GetComponent<Camera>();

        //worldDefaultForward = transform.forward; // ���� ���� �ϴ°� �̰� �����ΰ�?
    }
    private void Start()
    {
        rotX = transform.localRotation.eulerAngles.x;
        rotY = transform.localRotation.eulerAngles.y;

        dirNormalized = realCamera.localPosition.normalized; // ���⸸ ����
        finalDistance = realCamera.localPosition.magnitude; // ũ�⸸ ����

       
    }
    private void Update()
    {
        CamMoveSystem_update();
    }
    private void LateUpdate()
    {
        CamMoveSystem_lateupdate();
    }
    void CamMoveSystem_update()
    {
        rotX += -(Input.GetAxis("Mouse Y")) * sensitivity * Time.deltaTime;
        rotY += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion rot = Quaternion.Euler(rotX, rotY, 0);
        transform.rotation = rot;
    }
    void CamMoveSystem_lateupdate()
    {
        //transform.position = Vector3.MoveTowards(transform.position, objectToFollow.position, followSpeed * Time.deltaTime);

        finalDir = transform.TransformPoint(dirNormalized * maxDistance);

        RaycastHit hit;
        if (Physics.Linecast(transform.position, finalDir, out hit))
        {
            finalDistance = Mathf.Clamp(hit.distance, minDistance, maxDistance);
        }
        else
        {
            finalDistance = maxDistance;
        }
        realCamera.localPosition = Vector3.Lerp(realCamera.localPosition, dirNormalized * finalDistance, Time.deltaTime * smoothness);

    }



    void sightviewChange()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel") * wheelSpeed;

        // �ִ� ����
        if (Cam_Game.fieldOfView <= 20.0f && scroll < 0)
        {
            Cam_Game.fieldOfView = 20.0f;
        }
        // �ִ� �� �ƿ�
        else if (Cam_Game.fieldOfView >= 60.0f && scroll > 0)
        {
            Cam_Game.fieldOfView = 60.0f;
        }
        else
        {
            Cam_Game.fieldOfView += scroll;
        }

        // ���� ���� ������ ���� ĳ���� �ٶ󺸵���
        if (Cam_Game.fieldOfView <= 30.0f)
        {
            Debug.Log("ĳ���� �Ĵٺ�");
            Cam_Game.transform.rotation = Quaternion.Slerp(Cam_Game.transform.rotation,
                Quaternion.LookRotation(characterHead.transform.position - Cam_Game.transform.position), -0.15f);

            ///Cam_Game.transform.LookAt(characterHead.transform);


        }
        else
        {
            Debug.Log("�Ϲ� ����");

            Cam_Game.transform.rotation = Quaternion.Slerp(Cam_Game.transform.rotation, Quaternion.LookRotation(worldDefaultForward), 0.15f);
        }

    }
}
