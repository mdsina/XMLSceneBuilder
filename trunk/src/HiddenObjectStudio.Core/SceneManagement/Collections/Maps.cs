using System.Collections.Generic;
using System.Xml;

namespace HiddenObjectStudio.Core.SceneManagement
{
	public class Maps : List<Map>
	{
        public string[] Names
        {
            get
            {
                string[] names;
                names = new string[this.Count];

                for (int i = 0; i < this.Count; ++i)
                {
                    names[i] = this[i].Name;
                }

                return names;
            }
        }

		public Maps()
		{ 
		}

        public void SaveToXml(XmlNode xmlNode)
        {
            XmlDocument xmlDoc = xmlNode.OwnerDocument;

            foreach (Map map in this)
            {
                XmlNode mapNode = null;
                mapNode = xmlNode.SelectSingleNode(map.Name);

                if (mapNode == null)
                {
                    mapNode = xmlDoc.CreateElement(map.Name);
                    xmlNode.AppendChild(mapNode);
                }

                map.SaveToXml(mapNode);

                xmlNode.AppendChild(mapNode);
            }
        }

		public void LoadFromXml(XmlNode xmlNode)
		{
        	Clear();

            foreach (XmlNode mapNode in xmlNode.ChildNodes)
			{
                Map newMap = new Map(mapNode.Name);
                newMap.LoadFromXml(mapNode);
                Add(newMap);
			}
		
		}

        public Map GetMap (string name)
        {
            foreach (Map map in this)
            {
                if (map.Name == name)
                {
                    return map;
                }
            }

            return null;
        }
	}
}