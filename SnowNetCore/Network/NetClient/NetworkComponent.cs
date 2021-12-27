using System;
using UnityEngine;
using SnowNetEngine;

/*
 * 유니티와 닷넷프레임워크를 이어 줄 컴포넌트 -->유니티는 싱글코어 이기 때문에 이러한 중간 클래스가 필요하다.
 * 
 */
public class NetworkComponent : MonoBehaviour
{
    private CSnowNetService netSerivce_;
    
    [Header("Server Address")] 
    public string ip;
    public int port;
    
    private bool isMulti_; //멀티 or 싱글

    // Start is called before the first frame update
    void Start()
    {
        isMulti_ = false;
        netSerivce_ = new CSnowNetService();
        TryConnectToServer(ip, port);
    }

    // 네트워크접속을 시도할 것이라면 여기 함수를 통해서 시작
    // 나중에 싱글 멀티를 구별해서 진행해야할 수 있기 때문이다.(테스트든 뭐든 간에)
    public void TryConnectToServer(string ip, int port)
    {
        netSerivce_.ConnectToServer(ip, port);
        //연결이 성공했다면
        isMulti_ = true;
        //Todo 실패했다면 몇번 정도 더 트라이 하는 로직을 만들자!
    }

    // Update is called once per frame
    void Update()
    {
    }
}