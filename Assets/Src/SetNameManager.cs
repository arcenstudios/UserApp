using Pack;
using UnityEngine;
using UnityEngine.UI;

public class SetNameManager : MonoBehaviour
{
    [SerializeField]
    private string m_MemberName = "";
    public string memberName
    {
        get { return m_MemberName; }
        set { m_MemberName = value; }
    }

    [SerializeField]
    private bool m_NameSet = false;
    public bool nameSet
    {
        get { return m_NameSet; }
        set { m_NameSet = value; }
    }

   void Start() {
       GetComponentInChildren<InputField>().onValueChanged.AddListener((text) => {
           if(text.Equals(""))
           {
               nameSet = false;
           }
           else {
               nameSet = true;
           }

           memberName = text;
       });
   }

    public void OnConfirmPressed() {
        if (nameSet)
        {
            GameObject packMember = GameObject.FindGameObjectWithTag("PackMember");
            packMember.GetComponent<PackMember>().memberName = memberName;
            GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().ShowSelectOptionPanel();
        }
    }
}
