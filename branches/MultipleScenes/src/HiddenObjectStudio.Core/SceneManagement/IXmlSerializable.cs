using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace HiddenObjectStudio.Core.SceneManagement
{
	interface IXmlSerializable
	{
		XmlNode SaveToXml(XmlDocument xmlDoc);
		void LoadFromXml(XmlNode node);
	}
}
