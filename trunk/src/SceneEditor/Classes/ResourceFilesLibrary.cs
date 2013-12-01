using System;
using System.Collections.Generic;
using System.Text;

namespace SceneEditor
{
	public class ResourceFilesLibrary
	{
		private List<string> _files;

		public ResourceFilesLibrary()
		{
			_files = new List<string>();
		}

		public void Add(string fileName)
		{
			_files.Add(fileName);
		}

		public void Add(ref string[] fileNames)
		{
			for (int i = 0; i < fileNames.Length; ++i )
				Add(fileNames[i]);
		}

		public void Remove(string fileName)
		{
			int index = -1;
			for (int i = 0; i < _files.Count; ++i)
				if (_files[i].ToLower() == fileName.ToLower())
				{
					index = i;
					break;
				}

			if (index != -1)
				_files.RemoveAt(index);

		}

		public List<string> Files
		{
			get { return _files;} 
		}
	}
}
