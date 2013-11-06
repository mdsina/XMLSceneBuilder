using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace HiddenObjectStudio.Core.SceneManagement
{
    public enum SubAnimationType
    {
        Follow_mouse,
        Window,
        Fade
    }  

	public class Animation
	{
        public List<SubAnimation> SubAnimations = new List<SubAnimation>();

		public string Name
		{
			get;set;
		}

        public void SaveToXml(XmlNode xmlNode)
		{
            XmlDocument xmlDoc = xmlNode.OwnerDocument;

            foreach (SubAnimation subAnimation in SubAnimations)
            {
                XmlNode subAnimationNode = null;
                subAnimationNode = xmlNode.SelectSingleNode(subAnimation.Name);

                if (subAnimationNode == null)
                {
                    subAnimationNode = xmlDoc.CreateElement(subAnimation.Name);
                    xmlNode.AppendChild(subAnimationNode);
                }

                subAnimation.SaveToXml(subAnimationNode);

                xmlNode.AppendChild(subAnimationNode);
            }
        }

		public void LoadFromXml(XmlNode node)
		{
			Name = node.Name;
           
            foreach (XmlNode subAnimationNode in node.ChildNodes)
            {
                SubAnimation newSubAnimation = new SubAnimation();
                newSubAnimation.LoadFromXml(subAnimationNode);
                SubAnimations.Add(newSubAnimation);
            }
		}

        public SubAnimation GetSubAnimation(string name)
        {
            foreach (SubAnimation subAnimation in SubAnimations)
            {
                if (subAnimation.Name == name)
                    return subAnimation;
            }

            return null;
        }

        public SubAnimation CreateSubAnimation(SubAnimationType type)
        {
            SubAnimation subAnimation = new SubAnimation();
            switch (type)
            {
                case SubAnimationType.Follow_mouse:
                    {
                        subAnimation.Name = "follow_mouse";
                        SubAnimations.Add(subAnimation);
                        break;
                    }
                case SubAnimationType.Fade:
                    {
                        subAnimation.Name = "fade";
                        SubAnimations.Add(subAnimation);
                        break;
                    }
                case SubAnimationType.Window:
                    {
                        subAnimation.Name = "window";
                        SubAnimations.Add(subAnimation);
                        break;
                    }
            }
            return subAnimation;
        }

	}
}
