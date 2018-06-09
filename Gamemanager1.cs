using UnityEngine;
using HealingWorldPacketData;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamemanager1 : MonoBehaviour {
    
    public static void fail()
    {
        Text fail = GameObject.Find("loginFail").GetComponent<Text>();
        fail.text = "실패";
        Debug.Log(fail + " + " + fail.text);
    }
    


    public void LogoutButton() {
        hpBar.scon = false;
        Network.Logout();

    }

    public void button1()
    {
        Network.Login("113.198.238.63", 3000);
        //nw.loginCheck = true;
    }

    public void button2()
    {
        Network.Logout();
        //nw.loginCheck = false;
    }

    public void button3()
    {
        Network.Send(0,null);
    }

    public void button4()
    {
        Network.Send(0,null);
    }

    public void Start()
    {
        
    }

    public void Update()
    {
        

        
    }
    

}
