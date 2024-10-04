using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class CameraRotator : MonoBehaviour
{
    // 목적 마우스(터치)를 통해서 camera(user)를 회전
    // - 마우스(터치) 입력 event
    public float mouseX, mouseY;
    // - 민감도(회전 속도)
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 목적 : 마우스(터치)를 통해서 camera(user)를 회전
        // 4. 마우스를 누르고 있는 경우에만
        if (Input.GetMouseButton(0)){
            // 3. 마우스가 어디로 움직였는가?
            // ㄴ 3-a. 좌우 방향 hoirzontal
            float h = Input.GetAxis("Mouse X");
            // ㄴ 3-b. 상하 방향 vertical
            float v = Input.GetAxis("Mouse Y");
            // 2. 어디로 회전 시킬것인가
            // p(다음 회전위치) = p0(현재 회전 위치) +vt(속력 *방향)
            mouseX = mouseX + h * speed * Time.deltaTime;
            mouseY = mouseY + v * speed * Time.deltaTime;
            // 1. 얼마나 빠르게 회전시킬것인가
            transform.localEulerAngles = new Vector3(mouseY,-mouseX,0);
        }
    }
}
