using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using agora_gaming_rtc;

public class AgoraInterface : MonoBehaviour
{
    private static string appId = "aacbc6bff87f4f57ba6430dfb6902066";
    public IRtcEngine mrtcEngine;
    public uint mRemotePeer;

    public void loadEngine()
    {
        //start sdk
        Debug.Log("Initializing Engine");
        if(mrtcEngine != null)
        {
            Debug.Log("Engine already Exits...please unload");
            return;
        }
        //init rtc engine
        mrtcEngine = IRtcEngine.GetEngine(appId);
        //set log level
        mrtcEngine.SetLogFilter(LOG_FILTER.DEBUG);


    }
    public void joinChannel(string channelName)
    {
        Debug.Log("Joinning Channel :"+channelName);
        if(mrtcEngine == null)
        {
            Debug.Log("Initialize Engine before joining channel");
            return;
        }
        //set callbacks
        mrtcEngine.OnJoinChannelSuccess = OnJoinChannelSuccess;
        mrtcEngine.OnUserJoined = OnUserJoined;
        mrtcEngine.OnUserOffline = OnUserJoined;
        //enable video
        mrtcEngine.EnableVideo();
        //enable camera output callback
        mrtcEngine.EnableVideoObserver();
        //join the channel
        mrtcEngine.JoinChannel(channelName, null, 0);
    }
    public void leaveChannel()
    {
        Debug.Log("Leaving Channel");
        if (mrtcEngine == null)
        {
            Debug.Log("Initialize Engine before leaving channel");
            return;
        }
        //leave channel
        mrtcEngine.LeaveChannel();

        //disable camera
        mrtcEngine.DisableVideoObserver();
    }
    public void unLoadEngine()
    {
        Debug.Log("Unloading Engine");
        if(mrtcEngine != null)
        {
            IRtcEngine.Destroy();
            mrtcEngine = null;
        }
    }
    //implement engine callbacks
    private void OnJoinChannelSuccess(string channelName,uint uid, int elapsed)
    {
        Debug.Log("Successfully joined channel " + channelName + "with id= " + uid);
    }
    private void OnUserJoined(uint uid, int elapsed)
    {
        Debug.Log("New user has joined channel with id = " + uid);
    }
    private void OnUserJoined()
    {

    }

}
