using UnityEngine;

public class PackListManager : MonoBehaviour
{
    [SerializeField]
    private string m_SelectedPack = "";
    public string selectedPack{
        get { return m_SelectedPack; }
        set { m_SelectedPack = value; }
    }

    [SerializeField]
    private bool m_PackSelected = false;
    public bool packSelected
    {
        get { return m_PackSelected; }
        set { m_PackSelected = value; }
    }

    [SerializeField]
    private PackListItem m_SelectedItem = null;
    public PackListItem selectedItem
    {
        get { return m_SelectedItem; }
        set { m_SelectedItem = value; }
    }

    void Start(){
    }

    public void OnOkPressed(){
        if (packSelected)
        {
            GameObject ui = GameObject.FindGameObjectWithTag("UIManager");
            GameObject packMember = GameObject.FindGameObjectWithTag("PackMember");
            GameObject.Destroy(this);
        }
    }

    public void OnCancelPressed(){
        GameObject ui = GameObject.FindGameObjectWithTag("UIManager");
        ui.GetComponent<UIManager>().ShowSelectOptionPanel();
    }

    public void SetSelectedItem(PackListItem item){
        if (selectedItem == null)
        {
            selectedItem = item;
            UnityEngine.UI.Image img = selectedItem.GetComponent<UnityEngine.UI.Image>();
            img.color = Color.gray;
            packSelected = true;
            selectedPack = item.packName;
        }
        else
        {
            if (item.Equals(selectedItem))
            {
                selectedItem = item;
                packSelected = false;
                selectedPack = null;
                UnityEngine.UI.Image img = item.GetComponent<UnityEngine.UI.Image>();
                img.color = Color.clear;
            }
            else
            {
                packSelected = true;
                selectedItem = item;
                selectedPack = item.packName;
                UnityEngine.UI.Image img = item.GetComponent<UnityEngine.UI.Image>();
            }
        }
    }
}   
