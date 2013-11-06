using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace QuestMonkey
{
	public class SceneGlints
	{
		private XmlDocument _doc;
		private XmlNode _glintsRoot;
		private string _fileName;
		private DateTime _lastWriteTime;
 
		public SceneGlints(string fileName)
		{
			_fileName = fileName;
			_doc = new XmlDocument();

			_glintsRoot = null;

			if (File.Exists(_fileName))
			{
				_doc.Load(_fileName);

				_glintsRoot = _doc.DocumentElement;
			}
			else
			{
				_glintsRoot = _doc.CreateElement("glints");
				_doc.AppendChild(_glintsRoot);
			}


			FileInfo fi = new FileInfo(_fileName);
			fi.Refresh();
			_lastWriteTime = fi.LastWriteTimeUtc;
		}

		public void AddGlint(string glintName, string layerName)
		{
			XmlElement newGlintNode = _doc.CreateElement(glintName);

			newGlintNode.SetAttribute("layer", layerName);

			_glintsRoot.AppendChild(newGlintNode);
		}

		public void RemoveGlint(string glintName)
		{
			XmlNode glintNode = _glintsRoot.SelectSingleNode(glintName);

			if (glintNode != null)
			{
				_glintsRoot.RemoveChild(glintNode);
			}
		}

		public List<Glint> GetAllGlints()
		{
			List<Glint> allGlints = new List<Glint>();

			foreach (XmlNode glintNode in _glintsRoot)
			{
				allGlints.Add(new Glint(glintNode));
			}

			return allGlints;
		}

		public Glint GetGlintByName(string name)
		{
			XmlNode questGlintNode = _glintsRoot.SelectSingleNode(name);

			if (questGlintNode != null)
			{
				return new Glint(questGlintNode);
			}
			else
			{
				return null;
			}

		}

		public bool IsFileModified()
		{
			FileInfo fi = new FileInfo(_fileName);
			fi.Refresh();

			TimeSpan diff	= fi.LastWriteTimeUtc - _lastWriteTime;

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

		public void Save()
		{
			_doc.Save(_fileName);

			FileInfo fi = new FileInfo(_fileName);
			fi.Refresh();
			_lastWriteTime = fi.LastWriteTimeUtc;
		}

	}
}
