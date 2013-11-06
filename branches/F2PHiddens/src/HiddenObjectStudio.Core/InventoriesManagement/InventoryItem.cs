using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace HiddenObjectStudio.Core.InventoriesManagement
{
    public struct DropZone
    {
        public string dropZoneName;

        public string animatedApplicationValue;
    }

    public struct Part
    {
        public string partName;

        public string partShader;
    }

    public class InventoryItem
    {
        private static string InvItemAttributeFullName = "full_name";
        private static string InvItemAttributeShader = "shader";
        private static string InvItemAttributeParts = "parts";
        private static string InvItemAttributeIcon = "icon";
        private static string InvItemAttributeDropZones = "drop_zones";

        public XmlElement _node;
        public List<DropZone> DropZonesList;
        public List<Part> PartsList;
        public string NameItemInTextsXML;

        public InventoryItem(XmlNode node)
        {
            _node = (XmlElement)node;
            
            Name = _node.Name;

            DropZonesList = new List<DropZone>();
            PartsList = new List<Part>();

            if (_node.ChildNodes.Count > 0)
            {
                foreach (XmlNode itemChildNode in _node.ChildNodes)
                {
                    if (itemChildNode.Name == InvItemAttributeDropZones)
                    {
                        foreach (XmlNode dropZoneNode in itemChildNode.ChildNodes)
                        {
                            if (dropZoneNode.NodeType != XmlNodeType.Comment)
                            {
                                DropZone dropZones = new DropZone();
                                dropZones.dropZoneName = dropZoneNode.Name;

                                if (dropZoneNode.Attributes["animated_application"] != null)
                                {
                                    dropZones.animatedApplicationValue = dropZoneNode.Attributes["animated_application"].Value;
                                }

                                DropZonesList.Add(dropZones);
                            }
                        }
                    }
                    if (itemChildNode.Name == InvItemAttributeParts)
                    {
                        foreach (XmlNode partNode in itemChildNode.ChildNodes)
                        {
                            Part part = new Part();
                            part.partName = partNode.Name;

                            part.partShader = partNode.Attributes["shader"].Value;

                            PartsList.Add(part);
                        }
                    }
                }
            }
          
        }

        public string Name { get; set; }

        public string InvItemFullName
        {
            get
            {
                return _node.GetAttribute(InvItemAttributeFullName);
            }

            set
            {
                _node.SetAttribute(InvItemAttributeFullName, value);
            }

        }

        public string InvItemShaderName
        {
            get
            {
                return _node.GetAttribute(InvItemAttributeShader);
            }

            set
            {
                _node.SetAttribute(InvItemAttributeShader, value);
            }

        }

        
    }
}
