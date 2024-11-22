using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




/// <summary>
/// 카메라 회전에 따라 임의의 타켓을 쫒아다님
/// </summary>
//  활용 공식 : lerp 선형
//  [target] 대상
// 목적2 : 임의의 타겟의 회전방향을 자연스럽게 따라다님
// 목적3 : 용도의 맞게 이동/회전을 자유롭게 on/off

public class Follower : MonoBehaviour
{
    [Header("타켓")]
    [SerializeField]private GameObject target;
    [SerializeField]private float speed = 10.0f;
    [SerializeField]private float rotationSpeed = 10.0f;
    // - 이동 기능 on off
    public bool useLerpMove = true;
    // - 회전 기능 on off
    public bool useLerprotate = false;

    // Update is called once per frame
    void Update()
    {
        if(useLerpMove)
            MoveToTargetLerp();
        if(useLerprotate)
            RotateToTargetLerp();
    }

    //tartget을 lerp(보간)이동을 하는 
    private void MoveToTargetLerp(){
        //나의 위치
        Vector3 myPos = transform.position;
        //타겟의 위치
        Vector3 targetPos = target.transform.position;
        // 나의 위치 <> 타켓 위치 사이의 특정 point 구하기
        Vector3 point = transform.position = Vector3.Lerp(myPos,targetPos,speed * Time.deltaTime);
        // 4. 나의 위치를 3번에서 구한 point로 이동
        transform.position = point;
        
    }
    void RotateToTargetLerp(){
        // 1.나의 방향
        Quaternion myDir = transform.rotation;
        // 2.타겟의 방향
        Quaternion targetDir = target.transform.rotation;
        // 3.나의 방향 <> 타켓 방향 사이의 특정 point 구하기
        Quaternion point = Quaternion.Lerp(myDir,targetDir, rotationSpeed * Time.deltaTime);
        // 4. 나의 위치를 3번에서 구한 point로 이동
        transform.rotation = point;
       
    }


}
