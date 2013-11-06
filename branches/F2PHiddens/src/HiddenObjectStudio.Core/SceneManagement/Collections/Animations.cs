using System.Collections.Generic;
using System.Xml;

namespace HiddenObjectStudio.Core.SceneManagement
{
	public class Animations : List<Animation>
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

		public Animations()
		{

		}


		#region IXmlSerializable Members

        public void SaveToXml(XmlNode xmlNode)
        {
            XmlDocument xmlDoc = xmlNode.OwnerDocument;
                        
            foreach (Animation animation in this)
            {
                XmlNode animationNode = null;
                animationNode = xmlNode.SelectSingleNode(animation.Name);

                if (animationNode == null)
                {
                    animationNode = xmlDoc.CreateElement(animation.Name);
                    xmlNode.AppendChild(animationNode);
                }

                animation.SaveToXml(animationNode);
                
                xmlNode.AppendChild(animationNode);
            }
        }

		public void LoadFromXml(XmlNode node)
		{
			Clear();

			foreach (XmlNode animationNode in node.ChildNodes)
			{
				Animation newAnimation = new Animation();
				newAnimation.LoadFromXml(animationNode);
				Add(newAnimation);
			}
		}


		#endregion

		public Animation GetAnimation(string name)
		{
			foreach (Animation animation in this)
			{
				if (animation.Name == name)
					return animation;
			}

			return null;
		}
	};
}