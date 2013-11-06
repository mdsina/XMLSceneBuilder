using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;


namespace HiddenObjectStudio.Core.SceneManagement
{
	public class Map
	{
		public string Name;

        public List<Subscription> SubScriptions = new List<Subscription>();
	//	public Subscriptions Subscriptions;

		public Map(string name)
		{
			Name = name;
		}
        
        public void LoadFromXml(XmlNode xmlNode)
        {
            foreach (XmlNode subScriptionNode in xmlNode.ChildNodes)
            {
                Subscription subScription = new Subscription();
                subScription.LoadFromXml(subScriptionNode);
                SubScriptions.Add(subScription);
            } 
        }

        public void CreateSubsrcibtion(string newEvent, string newAnimation)
        {
            Subscription newSubscription = new Subscription();
            newSubscription.Event = newEvent;
            newSubscription.SubSctiptAnimation = newAnimation;

            SubScriptions.Add(newSubscription);
        }

        public void SaveToXml(XmlNode xmlNode)
        {
            //xmlNode.RemoveAll();
            foreach (Subscription subScribe in SubScriptions)
            {
               XmlNode newNode = xmlNode.OwnerDocument.CreateElement(subScribe.Name);
               subScribe.SaveToXml(newNode);
               xmlNode.AppendChild(newNode);
            }
            
        }
    
	}
}