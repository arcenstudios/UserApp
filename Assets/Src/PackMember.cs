using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityMultipeerConnectivity;

namespace Pack {
    public class PackMember : MonoBehaviour
    {
        [SerializeField]
        private string m_MemberName = "";
        public string memberName
        {
            get { return m_MemberName; }
            set { m_MemberName = value; }
        }

        [SerializeField]
        private bool m_InPack = false;
        public bool inPack
        {
            get { return m_InPack; }
            set { m_InPack = value; }
        } 

        [SerializeField]
        private bool m_Alpha = false;
        public bool alpha
        {
            get { return m_Alpha; }
            set { m_Alpha = value; }
        }

        void Start() {
            var mcSession = UnityMCSessionNativeInterface.GetMcSessionNativeInterface(); 
            var arSession = GameObject.FindGameObjectWithTag("ARSession").GetComponent<ARSession>();
            
            mcSession.DataReceivedEvent += OnMessageReceived;
        }

        public void OnMessageReceived(byte[] message){
            Debug.Log(message.ToString());
        }

        public new void SendMessage(string message){
           
        }
    }
}

