using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace HiddenObjectStudio.Core.SceneManagement
{
    public class SubAnimation
    {
        private Dictionary<string, string> _attributes;
        private List<string> _movementPoint;

        private XmlNode _node;
        private bool _movementNodeHasPoints;

        public string Name
        {
            get;
            set;
        }

        public SubAnimation()
		{
            _movementPoint = new List<string>();
			_attributes = new Dictionary<string, string>();
		}

        public void SaveToXml(XmlNode xmlNode)
        {
            XmlDocument xmlDoc = xmlNode.OwnerDocument;

            XmlElement node = (XmlElement)xmlNode;

            foreach (string attrib in _attributes.Keys)
            {
                node.SetAttribute(attrib, _attributes[attrib]);
            }

            if (node.Name == "movement")
            {
                if (_movementNodeHasPoints)
                {
                    XmlElement pointsNode = xmlDoc.CreateElement("points");
                    node.AppendChild(pointsNode);
                    foreach (string pointNodeValue in _movementPoint)
                    {
                        XmlElement pointNode = xmlDoc.CreateElement("point");
                        pointNode.InnerText = pointNodeValue;
                        pointsNode.AppendChild(pointNode);
                    }
                }
            }
        }

        public void LoadFromXml(XmlNode node)
        {
            Name = node.Name;
            _node = node;
            _attributes.Clear();
            if (node.NodeType != XmlNodeType.Comment)
            {
                foreach (XmlAttribute attrib in node.Attributes)
                {
                    _attributes.Add(attrib.Name, attrib.Value);
                }
            }

            if (node.Name == "movement")
            {
                XmlNode pointsNode = node.SelectSingleNode("points");
                if (pointsNode != null)
                {
                    foreach (XmlNode pointNode in pointsNode)
                    {
                        _movementPoint.Add(pointNode.InnerText);
                    }
                    _movementNodeHasPoints = true;
                }
                else
                {
                    _movementNodeHasPoints = false;
                }
            }
        }

        public void AddAttribut(string attributeName, string attributValue)
        {
            _attributes[attributeName] = attributValue;
        }

    }
}
