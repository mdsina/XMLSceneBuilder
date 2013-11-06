using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace SceneEditor.Classes.Collections
{
	class AnimationsCollection
	{
		private List<Animation> _animations;

		public AnimationsCollection()
		{
			_animations = new List<Animation>();
		}

		public Animation this[string name]
		{
			get 
			{
				foreach (Animation animation in _animations)
				{
					if (animation.Name == name)
						return animation; 
				}

				return null;
			}
		}

		public void Add(Animation newAnimation)
		{
			if (newAnimation == null) return;

			_animations.Add(newAnimation);
		}

		public XmlElement SaveToXml(XmlDocument xmlDoc)
		{
			XmlElement animationsNode = xmlDoc.CreateElement("animations");
			foreach (Animation animation in _animations)
			{
				animationsNode.AppendChild(animation.SaveToXml(animationsNode));
			}

			return animationsNode;
		}

		public void LoadFromXml(XmlNode node)
		{
			foreach (XmlNode animationNode in node.ChildNodes)
			{
				Animation newAnimation = new Animation();
				newAnimation.LoadFromXml(animationNode);
				Add(newAnimation);
			}

		}
	}
}
