using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PackListItem : MonoBehaviour
{
    [SerializeField]
    private PackListManager m_PackListManager;
    public PackListManager packListManager
    {
        get { return m_PackListManager; }
        set { m_PackListManager = value; }
    }

    [SerializeField]
    private string m_PackName;
    public string packName
    {
        get { return m_PackName; }
        set { m_PackName = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        packName = GetComponent<TMP_Text>().text;
        packListManager = GameObject.FindGameObjectWithTag("PackListManager").GetComponent<PackListManager>();
    }

    public void OnClicked()
    {
        packListManager.selectedPack = packName;
        packListManager.packSelected = true;
        
    }
}
