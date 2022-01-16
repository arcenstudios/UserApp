using UnityEditor.UIElements;
using UnityEngine;

public class SelectOptionManager : MonoBehaviour
{
    public void OnCreateClicked(){
        GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().ShowCreatePackPanel();
    }

    public void OnJoinClicked(){
        GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().ShowPackSelectionPanel();
    }
}
