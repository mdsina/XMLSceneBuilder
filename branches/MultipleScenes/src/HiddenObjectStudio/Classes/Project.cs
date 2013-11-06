using System;
using System.Xml;
using System.IO;


namespace HiddenObjectStudio.Classes
{
	public class Project
	{
		public string Name;
		public string ProjectPath;

        public string use_include;

		//public Scene Scene;
		
		public Project()
		{
			NewProject();
		}

		public void NewProject()
		{
			Name = "untitled";
         
			//Scene = new Scene();
		}

		public void OpenProject(string fileName)
		{
			if (!File.Exists(fileName)) throw new Exception("Open project: Can't find file '" + fileName +"'");

			//FileName = fileName;


			//Scene.LoadFromXml(sceneNode);
		}

		public void SaveProject()
		{
// 			if (string.IsNullOrEmpty(FileName)) throw new Exception("Save Project: FileName is null!");
// 
//             XmlDocument xmlDoc = new XmlDocument();
// 
//             XmlNode sceneNode = xmlDoc.CreateElement(Name);
//             xmlDoc.AppendChild(sceneNode);
// 
//            // Scene.SaveToXml(sceneNode);
// 
// 			//SaveToXml(xmlDoc);
// 	//		xmlDoc.AppendChild(sceneNode);
// 			xmlDoc.Save(FileName);
		}
         
		public void SaveProjectAs(string fileName)
		{
// 			FileName = fileName;
// 			SaveProject();
		}


	}
}