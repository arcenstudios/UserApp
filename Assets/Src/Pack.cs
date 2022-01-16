using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

namespace Pack {
    [Serializable]
    public struct Pack
    {
        [SerializeField]
        private List<PackMember> m_Members;
        public ReadOnlyCollection<PackMember> members
        {
            get { return m_Members.AsReadOnly(); }
        }

        [SerializeField]
        private PackMember m_Alpha;
        public PackMember alpha
        {
            get { return m_Alpha; }
            set { m_Alpha = value; }
        }

        [SerializeField]
        private string m_PackName;
        public string packName
        {
            get { return m_PackName; }
            set { m_PackName = value; }
        }

        public Pack(string name)
        {
            m_Members = new List<PackMember>();
            m_Alpha = null;
            m_PackName = name;
        }

        public void AddMember(PackMember member)
        {
            if (!m_Members.Contains(member))
            {
                m_Members.Append(member);
            }
        }

        public void RemoveMember(PackMember member)
        {
            if (m_Members.Contains(member))
            {
                m_Members.Remove(member);
            }
        }
    }
}

