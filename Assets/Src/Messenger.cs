using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.XR.ARFoundation;
using Pack;

public class Messenger : MonoBehaviour
{
    [SerializeField]
    private JsonSerializerSettings m_Settings;
    public JsonSerializerSettings settings{ get{return m_Settings;} set{m_Settings = value;}}
    
    [SerializeField]
    private ARParticipantManager m_ParticipantManager;
    public ARParticipantManager participantManager
    {
        get { return m_ParticipantManager; }
        set { m_ParticipantManager = value; }
    }

    [SerializeField]
    private PackMember m_PackMember;
    public PackMember packMember
    {
        get { return m_PackMember; }
        set { m_PackMember = value; }
    }
    
    void Start(){
        packMember = GameObject.FindGameObjectWithTag("PackMember").GetComponent<PackMember>();

        settings = new JsonSerializerSettings();
        settings.Formatting = Formatting.Indented;
        settings.ReferenceLoopHandling = ReferenceLoopHandling.Error;
    }

    public void OnParticipantsChanged(ARParticipantsChangedEventArgs args){
        Debug.Log("Participants changed...");
        foreach(ARParticipant participant in args.added)
        {
            Debug.Log("Participant: " + participant.trackableId + " added.");
        }
        foreach(ARParticipant participant1 in args.removed){
            Debug.Log("Participant " + participant1.trackableId + " removed.");
        }
        foreach(ARParticipant participant2 in args.updated) {
            Debug.Log("Participant " + participant2.trackableId + " updated.");
        }
    }

    public void CreateParticipantManager(){
        gameObject.AddComponent<ARParticipantManager>();
        participantManager = GetComponent<ARParticipantManager>();
        packMember.alpha = true;
    }
}
