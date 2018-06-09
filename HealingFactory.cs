using HealingWorldPacketData;
using System.Collections.Generic;


public static class HealingFactory  //180528수정: static 클래스로 변경
{
    public static long myPlayerNum; //내 페이스북 id(이걸로 nowMapHaveAllPlayers의 데이터를 꺼내와서 내꺼다 하고 쓰면 된다.
    public static Dictionary<long, PlayerInformation> nowMapHaveAllPlayers = new Dictionary<long, PlayerInformation>();

    public static void sendMoving(float x, float y)
    {
        //nowMapHaveAllPlayers[myPlayerNum].x = x;            //먼저 내 위치를 컬렉션에 저장하고
        //nowMapHaveAllPlayers[myPlayerNum].y = y;
        PlayerLocation myMoving = new PlayerLocation();     //전송패킷 만든 다음, 데이터를 넣고 전송
        myMoving.PlayerNum = myPlayerNum; myMoving.X = x; myMoving.Y = y;
        Network.Send(10000,myMoving);
    }


}
