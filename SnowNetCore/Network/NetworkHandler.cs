using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnowNetEngine;

/*
 * 유니티와 닷넷프레임워크를 이어 줄 핸들러
 * 
 */
public class NetworkHandler : MonoBehaviour
{

    private CSnowConnector connector_;

    [Header("Server Address")] 
    public string ip;
    public int port;
    
    // Start is called before the first frame update
    void Start()
    {
        connector_ = new CSnowConnector();
        TryConnectToServer(ip, port);
    }

    public void TryConnectToServer(string ip, int port)
    {
        connector_.OnConnect(ip,port);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
