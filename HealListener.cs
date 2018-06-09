using UnityEngine;
using HealingWorldPacketData;
using UnityEngine.SceneManagement;

public static class HealListener{
    public static void SmartListener(HealPacket pack) {
        switch (pack.protocol){
            case 0:
                break;
            case 100://로그인 성공(서버에서 접속자의 유저키를 전송함.서버에서 현재 위치, 현재 위치에 있는 모든 유저정보 전송해서 Directory에 입력)
                //LoginSuccess loginSuccess = (LoginSuccess)pack;
                GetAllPlayerInfo info = (GetAllPlayerInfo)pack;
                //HealingFactory.myPlayerNum=info.PlayerNum;
                HealingFactory.nowMapHaveAllPlayers = info.AllPlayerInfo;
                Debug.Log("로그인 성공");
                Debug.Log(HealingFactory.nowMapHaveAllPlayers.Count);
                Debug.Log("플레이어 정보 :"+HealingFactory.nowMapHaveAllPlayers[HealingFactory.myPlayerNum].Level);
                hpBar.scon = true;
                Network.loginCheck = true;

                break;
            case 200://로그인 실패
                Gamemanager1.fail();
                break;
            case 10000://플레이어가 다른 필드로 넘어갈 때, 해당 필드의 유저 정보를 전송받음
                PlayerLocation loc = (PlayerLocation)pack;
                HealingFactory.nowMapHaveAllPlayers[loc.PlayerNum].X = loc.X;
                HealingFactory.nowMapHaveAllPlayers[loc.PlayerNum].Y = loc.Y;
                break;
            case 11000://다른 플레이어의 이동 정보
                break;
            case 11001://현재 맵에서 새로운 플레이어가 등장했음.
                break;
            case 11002://현재 맵에 있던 플레이어가 나갔음.
                break;
            case 100000://스테이터스 갱신
                break;
            case 100010://레벨 상승
                break;
            case 100020://경험치 상승
                break;
            case 100030://어빌리티 상승
                break;
            case 100040://공격력 상승
                break;
            case 100050://솜씨 상승
                break;
            case 100060://골드 상승
                break;
            case 100061://골드 소비
                break;
        }
    }
}
