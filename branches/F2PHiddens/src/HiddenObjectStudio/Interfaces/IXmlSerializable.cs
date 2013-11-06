using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace HiddenObjectStudio
{
	interface IXmlSerializable
	{
		XmlNode SaveToXml(XmlDocument xmlDoc);
		void LoadFromXml(XmlNode node);
	}
}
