using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace HiddenObjectStudio.Core.SceneManagement
{
	public class Subscription
	{
		public static string EventAttributeName = "event";
		public static string AnimationAttributeName = "animation";
        public string Name = "subscribe";
        
        public String Event;
        public String SubSctiptAnimation;

        private XmlNode _node;

		public void LoadFromXml(XmlNode xmlNode)
		{
            if (xmlNode.NodeType != XmlNodeType.Comment)
            {
                Name = xmlNode.Name;
                if (xmlNode.Attributes[EventAttributeName] != null)
                {
                    Event = xmlNode.Attributes[EventAttributeName].Value;
                }
                else
                {
                    MessageBox.Show("Subscribe node in map node - " + xmlNode.ParentNode.Name + " - doesn't have Event Attribut!!!");
                }
                if (xmlNode.Attributes[AnimationAttributeName] != null)
                {
                    SubSctiptAnimation = xmlNode.Attributes[AnimationAttributeName].Value;
                }
                else
                {
                    MessageBox.Show("Subscribe node in map node - " + xmlNode.ParentNode.Name + " - doesn't have Animation Attribut!!!");
                }
            }
		}

        public void AddEventToSubcribe(string newEvent)
        {
            Event = newEvent;
        }

        public void AddAnimationToSubcribe(string newAnimation)
        {
           SubSctiptAnimation = newAnimation;
        }

		public void SaveToXml(XmlNode xmlNode)
		{
            XmlElement node = (XmlElement)xmlNode;
            node.SetAttribute(EventAttributeName, Event);
            node.SetAttribute(AnimationAttributeName, SubSctiptAnimation);
		}

        public bool CheckSubcribeToExist(string inputEvent, string inputAnimation)
        {
            if ((Event == inputEvent) && (SubSctiptAnimation == inputAnimation))
            {
                return true;
            }
            return false;
        }
	}
}