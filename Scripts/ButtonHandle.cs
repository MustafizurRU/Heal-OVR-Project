using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandle : MonoBehaviour
{
   public void onClickButton()
    {
        Debug.Log("Button Name is : " + name);
        ///GameObject go = GameObject.Find("NameInput");
       /// InputField inputName = go.GetComponent<InputField>();
      ///  Debug.Log("Your Name is \' " + inputName.text + "\' ");
      if(name.CompareTo("JoinButton") == 0)
        {
            onJoinButtonClicked();
        }
      else if(name.CompareTo("LeaveButton") == 0)
        {
            onLeaveButtonClicked();

        }


    }
    private void onJoinButtonClicked()
    {
        Debug.Log("You Are In");
        GameObject go = GameObject.Find("NameInput");
        InputField inputName = go.GetComponent<InputField>();
    }
    private void onLeaveButtonClicked()
    {
        Debug.Log("You Are Out");
       
    }
}
