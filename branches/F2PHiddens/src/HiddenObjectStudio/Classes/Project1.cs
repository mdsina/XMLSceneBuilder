using System;
using System.Xml;
using System.IO;
using SceneEditor.Forms;


namespace SceneEditor.Classes
{
	public class Project1
	{
		public string Name;
		public string FileName;
        public string use_include;

		public Scene Scene;
		
		public Project1()
		{
			NewProject();
		}

		public void NewProject()
		{
			Name = "untitled";
            FileName = string.Empty;
			Scene = new Scene();
		}

		public void OpenProject(string fileName)
		{
			if (!File.Exists(fileName)) throw new Exception("Open project: Can't find file '" + fileName +"'");

			FileName = fileName;

			XmlDocument xmlDoc = new XmlDocument();

			xmlDoc.Load(FileName);
            
			XmlNode sceneNode = xmlDoc.DocumentElement;
            Name = sceneNode.Name;
			Scene.LoadFromXml(sceneNode);
		}

		public void SaveProject()
		{
			if (string.IsNullOrEmpty(FileName)) throw new Exception("Save Project: FileName is null!");

            XmlDocument xmlDoc = new XmlDocument();

            XmlNode sceneNode = xmlDoc.CreateElement(Name);
            xmlDoc.AppendChild(sceneNode);

            Scene.SaveToXml(sceneNode);

			//SaveToXml(xmlDoc);
	//		xmlDoc.AppendChild(sceneNode);
			xmlDoc.Save(FileName);
		}
         
		public void SaveProjectAs(string fileName)
		{
			FileName = fileName;
			SaveProject();
		}


	}
}