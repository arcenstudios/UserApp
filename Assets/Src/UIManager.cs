using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject currentPanel;
    public Object setNamePanel;
    public Object selectOptionPanel;
    public Object selectPackPanel;
    public Object createPackPanel;

    void Start() {
        currentPanel = InstantiateItem(setNamePanel);
    }
    
    public void ShowSetUserName(){
        ClearCurrentPanel();
        currentPanel = InstantiateItem(setNamePanel);

        InputField nameEntry = null;
        Button confirmButton = null;

        foreach (Transform child in currentPanel.transform.GetComponentInChildren<Transform>())
        {
            if (child.transform.tag.Equals("NamedEntry"))
            {
                nameEntry = child.transform.gameObject.GetComponentInChildren<InputField>();
            }

            if (child.transform.tag.Equals("ConfirmButton"))
            {
                confirmButton = child.transform.gameObject.GetComponent<Button>();
            }
        }

        confirmButton.onClick.AddListener(() => {
            if (nameEntry.text != "" && nameEntry.text != null)
            {
                ShowSelectOptionPanel();
            }
        });
    }

    public void ShowSelectOptionPanel(){
        ClearCurrentPanel();
        currentPanel = InstantiateItem(selectOptionPanel);

        Button createButton = null;
        Button joinButton = null;
        
        foreach(Transform obj in currentPanel.transform.GetComponentsInChildren<Transform>())
        {
            if(obj.transform.tag.Equals("CreatePackButton"))
            {
                createButton = obj.GetComponent<Button>();
            }

            if(obj.transform.tag.Equals("JoinPackButton"))
            {
                joinButton = obj.GetComponent<Button>();
            }
        }

        createButton.onClick.AddListener(() => {
            ShowCreatePackPanel();
        });

        joinButton.onClick.AddListener(() => {
            ShowPackSelectionPanel();
        });
    }

    public void ShowPackSelectionPanel(){
        ClearCurrentPanel();
        currentPanel = InstantiateItem(selectPackPanel);
    }

    public void ShowCreatePackPanel(){
        ClearCurrentPanel();
        currentPanel = InstantiateItem(createPackPanel);
    }

    public void ClearCurrentPanel(){
        GameObject.DestroyImmediate(currentPanel, true);
    }
    
    public GameObject InstantiateItem(Object item){
        GameObject obj = Object.Instantiate(item, GetComponent<RectTransform>().anchoredPosition, Quaternion.identity, this.transform) as GameObject;
        return obj;
    }
}
