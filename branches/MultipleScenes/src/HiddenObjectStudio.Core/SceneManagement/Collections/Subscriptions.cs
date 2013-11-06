using System.Collections.Generic;
using System.Xml;
using SceneEditor.Classes.Collections;

namespace SceneEditor.Classes
{
	public class Subscriptions : List<Subscription>
	{
		public static string SubscriptionNodeName = "subscribe";

		public Subscriptions()
		{
			
		}

		public void LoadFromXml(XmlNode xmlNode, Events events, Animations animations)
		{
			foreach (XmlNode subscriptionNode in xmlNode.ChildNodes)
			{
				string eventName = subscriptionNode.Attributes[Subscription.EventAttributeName].Value;
				
				Subscription subscription = GetSubscriptionByEventName(eventName);	

				if (subscription != null)
				{
					subscription.LoadFromXml(subscriptionNode, events, animations);
				}
			}
		}

		public void SaveToXml(XmlNode xmlNode)
		{
			XmlDocument xmlDoc = xmlNode.OwnerDocument;

			foreach (Subscription subscription in this)
			{
				string xPath = "[@" + Subscription.EventAttributeName + "=" + subscription.Event.Name + "]";
				
				XmlNode subscriptionNode = xmlNode.SelectSingleNode(xPath) ?? xmlDoc.CreateElement(SubscriptionNodeName);

				subscription.SaveToXml(subscriptionNode);
			}
		}

		public Subscription GetSubscriptionByEvent(Event evnt)
		{
			foreach (Subscription subscription in this)
			{
				if (subscription.Event.Name == evnt.Name)
				{
					return subscription;
				}
			}

			return null;
		}

		public Subscription GetSubscriptionByEventName(string eventName)
		{
			foreach (Subscription subscription in this)
			{
				if (subscription.Event.Name == eventName)
				{
					return subscription;
				}
			}

			return null;
		}
	}
}