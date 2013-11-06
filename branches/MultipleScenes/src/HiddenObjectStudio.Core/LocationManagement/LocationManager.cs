using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Collections.Specialized;

namespace HiddenObjectStudio.Core.LocationManagement
{
	public class LocationManager
	{
		private XmlDocument _doc;

		private string _fileName;

		private DateTime _lastWriteTime;

		public List<Location> Locations;

		public List<SceneInfo> AllScenes;

        public List<SceneInfo> AllMainScenes;

		public List<string> AllMiniGameNames;

		public LocationManager(string levelsFileName)
		{
			_fileName = levelsFileName;

			Locations = new List<Location>();

			AllScenes = new List<SceneInfo>();

            AllMainScenes = new List<SceneInfo>();

			AllMiniGameNames = new List<string>();

			_doc = new XmlDocument();

			_doc.Load(_fileName);

			FileInfo fi = new FileInfo(_fileName);

			fi.Refresh();

			_lastWriteTime = fi.LastWriteTimeUtc;


			XmlNode stageNode = _doc.DocumentElement.SelectSingleNode("stage");

			foreach (XmlNode levelNode in stageNode)
			{
                if (levelNode.NodeType != XmlNodeType.Comment)
                {
                    Location newLocation = new Location((XmlElement)levelNode);

                    AllScenes.AddRange(newLocation.AllScenes);

                    AllMainScenes.Add(newLocation.AllScenes[0]);

                    AllScenes.AddRange(newLocation.AllSubscreens);

                    Locations.Add(newLocation);

                    AllMiniGameNames.AddRange(newLocation.MiniGameNames);
                }
            }
		}

		public void Save()
		{
			_doc.Save(_fileName);

			FileInfo fi = new FileInfo(_fileName);
			fi.Refresh();
			_lastWriteTime = fi.LastWriteTimeUtc;
		}

// 		public SceneInfo FindSceneOrSubscreenByName(string sceneName)
// 		{
// 			foreach (Location place in Locations)
// 			{
// 				if (place.MainScene.Name == sceneName)
// 				{
// 					return place.MainScene;
// 				}
// 				else
// 				{
// 					SceneInfo foundScene = place.MainScene.GetChildScene(sceneName);
// 
//                     if (foundScene != null)
//                     {
//                         return foundScene;
//                     }
//                     else
//                     {
//                         foreach (SceneInfo subSubs in place.MainScene.ChildScenes)
//                         {
//                             SceneInfo foundSubScene = subSubs.GetChildScene(sceneName);
//                             if (foundSubScene != null)
//                             {
//                                 return foundSubScene;
//                             }
//                         }
//                     }
// 				}
// 			}
// 
// 			return null;
// 		}
// 
// 		public SceneInfo FindSceneOrSubscreenByFolderName(string folderName)
// 		{
// 			foreach (Location place in Locations)
// 			{
// 				if (place.MainScene.FolderName == folderName)
// 				{
// 					return place.MainScene;
// 				}
// 				else
// 				{
// 					SceneInfo foundScene = place.MainScene.GetChildSceneByFolderName(folderName);
// 
// 					if (foundScene != null)
// 					{
// 						return foundScene;
// 					}
//                     else
//                     {
//                         foreach (SceneInfo subSubs in place.MainScene.ChildScenes)
//                         {
//                             SceneInfo foundSubScene = subSubs.GetChildSceneByFolderName(folderName);
//                             if (foundSubScene != null)
//                             {
//                                 return foundSubScene;
//                             }
//                         }
//                     }
// 				}
// 			}
// 
// 			return null;
// 		}

		public Location GetLocation(string locationName)
		{
			foreach (Location location in Locations)
			{
				if (location.Name == locationName)
				{
					return location;
				}
			}

			return null;
		}

		public bool CheckFileForModification()
		{
			FileInfo fi = new FileInfo(_fileName);
			fi.Refresh();

			TimeSpan diff = fi.LastWriteTimeUtc - _lastWriteTime;

			bool isModified = diff > TimeSpan.FromSeconds(1);

			if (isModified)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
