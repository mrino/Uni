using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//목적 : 장소 이동시, 화면 전환 효과를 주고싶다.
// - 화면전환시간
// - 화면전환시 딜레이시간
// - 화면전환용 이미지 (Canvas)
//
public class TranstionManger : MonoBehaviour
{
    // - 화면전환시간
    public float duration;
    // - 화면전환시 딜레이시간
    public float delayTime = 1.5f; 
    // - 화면전환용 이미지 (Canvas)
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
