using Pack;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreatePackManager : MonoBehaviour
{
    [SerializeField]
    private Button m_ConfirmButton;
    public Button confirmButton
    {
        get { return m_ConfirmButton; }
        set { m_ConfirmButton = value; }
    }

    [SerializeField]
    private Pack.Pack m_CreatedPack;
    public Pack.Pack createdPack
    {
        get { return m_CreatedPack; }
        set { m_CreatedPack = value; }
    }

    [SerializeField]
    private bool m_PackCreated = false;
    public bool packCreated
    {
        get { return m_PackCreated; }
        set { m_PackCreated = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject packMember = GameObject.FindGameObjectWithTag("PackMember");
        TMP_InputField inputField = GetComponent<TMP_InputField>();

        if (inputField != null)
        {
            GetComponent<TMP_InputField>().onValueChanged.AddListener((text) => {
                if (text != "")
                {
                    createdPack = new Pack.Pack(text);
                    createdPack.AddMember(packMember.GetComponent<PackMember>());
                    packCreated = true;
                }
                else
                {
                    packCreated = false;
                }
            });
        } 
    }

    public void OnConfirmPressed() {
        if (packCreated) {
            Debug.Log("OnConfirmCalled");
            GameObject.FindGameObjectWithTag("Messenger").GetComponent<Messenger>().CreateParticipantManager();
            GameObject.DestroyImmediate(this.gameObject, true);
        }
    }
}
