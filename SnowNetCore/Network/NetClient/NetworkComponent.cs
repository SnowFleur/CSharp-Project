using System;
using System.Net.Sockets;
using UnityEngine;
using SnowNetEngine;
using UnityEditorInternal;

/*
 * 유니티와 닷넷프레임워크를 이어 줄 컴포넌트 -->유니티는 싱글코어 이기 때문에 이러한 중간 클래스가 필요하다.
 * 
 */
public class NetworkComponent : MonoBehaviour
{
    private CSnowNetwork netwowrk_;
    private CSnowConnector connector_;


    [Header("Server Address")] public string ip;
    public int port;

    private bool multiPlay_; //싱글 OR 멀티

    // Start is called before the first frame update
    void Start()
    {
        multiPlay_ = false;
        netwowrk_ = new CSnowNetwork();
        connector_ = new CSnowConnector(netwowrk_);
        //연결 성공시 호출될 콜백 함수  
        connector_.CallBackPostConnect += PostConnect;
    }

    // 네트워크접속을 시도할 것이라면 여기 함수를 통해서 시작
    // 나중에 싱글 멀티를 구별해서 진행해야할 수 있기 때문이다.(테스트든 뭐든 간에)
    public void TryConnectToServer(string ip, int port)
    {
        if (multiPlay_ == false)
        {
            connector_.OnConnect(ip, port);
        }
    }

    //여기에서 넘어오는 session은 접속이 완료된 세션
    public void PostConnect(CSnowSession session)
    {
        multiPlay_ = true;
    }

    // Update is called once per frame
    void Update()
    {
    }
}