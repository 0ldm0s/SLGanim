using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class RTSCamera : MonoBehaviour
{
    public float cameraMoveSpeed = 10;
    //public float cameraRotateSpeed = 100;
    public float cameraScrollSpeed = 300;

    public float minXPos = 30;
    public float maxXPos = 50;

    public float minYPos = 10;
    public float maxYPos = 30;

    public float minZPos = 30;
    public float maxZPos = 50;
    
    public float minD = 10;
    public float maxD = 30;
    public float distanceToGround;
    //private Vector3 lastPosition;   //����ǰ��λ�ñ���
    public  Vector3 LRRecord;       //����ʱ��left/right�����¼��ֵΪ1˵����ֹ������÷����ƶ���
    public Vector3 FBRecord;       //����ʱ��forward/back�����¼
    void LateUpdate()
    {
        float mouseWheel = Input.GetAxis("Mouse ScrollWheel");

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            //lastPosition = transform.position;
            if (Input.mousePosition.x <= 20 && LRRecord != Vector3.left)
            {
                transform.Translate(Vector3.left * cameraMoveSpeed * Time.deltaTime);
                LRRecord = Vector3.zero;
            }
            if (Input.mousePosition.x >= (Screen.width - 20) && LRRecord != Vector3.right)
            {
                transform.Translate(Vector3.right * cameraMoveSpeed * Time.deltaTime);
                LRRecord = Vector3.zero;
            }
            if (Input.mousePosition.y <= 20 && FBRecord != Vector3.back)
            {
                transform.Translate(Vector3.back * cameraMoveSpeed * Time.deltaTime, Space.World);
                FBRecord = Vector3.zero;
            }
            if (Input.mousePosition.y >= (Screen.height - 20) && FBRecord != Vector3.forward)
            {
                transform.Translate(Vector3.forward * cameraMoveSpeed * Time.deltaTime, Space.World);
                FBRecord = Vector3.zero;
            }
            distanceToGround = transform.position.y;
            if (distanceToGround <= minD)
            {
                if (mouseWheel > 0)
                {
                    mouseWheel = 0;
                    distanceToGround = minD;
                }
            }
            else if (distanceToGround >= maxD)
            {
                if (mouseWheel < 0)
                {
                    mouseWheel = 0;
                    distanceToGround = maxD;
                }
            }



            float currentX;
            float currentY;
            float currentZ;





            currentX = transform.position.x;
            currentY = transform.position.y;
            currentZ = transform.position.z;
            currentY -= mouseWheel * cameraScrollSpeed * Time.deltaTime;
            currentZ += mouseWheel * cameraScrollSpeed * Time.deltaTime;
            currentX = Mathf.Clamp(currentX, minXPos, maxXPos);
            currentY = Mathf.Clamp(currentY, minYPos, maxYPos);
            currentZ = Mathf.Clamp(currentZ, minZPos - currentY, maxZPos - currentY);

            transform.position = new Vector3(currentX, currentY, currentZ);
        }


        //RaycastHit hit;
        //if (Physics.Raycast(transform.position, transform.forward, out hit))
        //{
            
        //}
        //else
        //{
        //    RaycastHit hitinfo;
        //    //��ǰ���߼�ⲻ����������߼�ⲻ�������������������ƶ���
        //    if(!Physics.Raycast(transform.position + Vector3.left + Vector3.forward, transform.forward, out hitinfo) && !Physics.Raycast(transform.position + Vector3.left + Vector3.back, transform.forward, out hitinfo))
        //    {
        //        LRRecord = Vector3.left;
        //        transform.position = new Vector3(lastPosition.x, transform.position.y, transform.position.z);
        //    }
        //    //��ǰ���߼�ⲻ�����Һ����߼�ⲻ�������������������ƶ���
        //    if (!Physics.Raycast(transform.position + Vector3.right + Vector3.forward, transform.forward, out hitinfo) && !Physics.Raycast(transform.position + Vector3.right + Vector3.back, transform.forward, out hitinfo))
        //    {
        //        LRRecord = Vector3.right;
        //        transform.position = new Vector3(lastPosition.x, transform.position.y, transform.position.z);
        //    }
        //    //��ǰ���߼�ⲻ������ǰ���߼�ⲻ�������������������ƶ���
        //    if (!Physics.Raycast(transform.position + Vector3.forward + Vector3.left, transform.forward, out hitinfo) && !Physics.Raycast(transform.position + Vector3.forward + Vector3.right, transform.forward, out hitinfo))
        //    {
        //        FBRecord = Vector3.forward;
        //        transform.position = new Vector3(transform.position.x, transform.position.y, lastPosition.z);
        //    }
        //    //��ǰ���߼�ⲻ����������߼�ⲻ�������������������ƶ���
        //    if (!Physics.Raycast(transform.position + Vector3.back + Vector3.left, transform.forward, out hitinfo) && !Physics.Raycast(transform.position + Vector3.back + Vector3.right, transform.forward, out hitinfo))
        //    {
        //        FBRecord = Vector3.back;
        //        transform.position = new Vector3(transform.position.x, transform.position.y, lastPosition.z);
        //    }
        //}
    }
}
