using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HiddenObjectStudio.Core.LocationManagement;
using HiddenObjectStudio.Core.InventoriesManagement;

namespace QuestMonkey
{
	public partial class GenerateTemplateForm : Form
	{
		public bool IsModified;

		private QuestGenerator _generator;
		private LocationManager _locationManager;
		private QuestsManger _questManager;


		public GenerateTemplateForm(LocationManager locationManager, QuestsManger questsManager, GlintManager glintManager, Inventories inventory)
		{
			InitializeComponent();

			IsModified = false;

			_locationManager = locationManager;
			_questManager = questsManager;
			_generator = new QuestGenerator(locationManager, questsManager, glintManager, inventory, textBoxReport);
		}

		private void GenerateTemplateForm_Load(object sender, EventArgs e)
		{
			
		}

		private void buttonGenerate_Click(object sender, EventArgs e)
		{
			_generator.Generate();
			IsModified = true;
		}

// 		public void P()
// 		{
// 			//qg = new QuestGenerator(ProjectPath + "bin\\data\\gameplay\\main\\scenes");
// 
// 			textBoxGeneratedPreview.Text = qg.Doc.InnerXml;
// 			//qg.ParseScriptFile(ProjectPath + "bin\\data\\gameplay\\main\\scenes\\guest_room\\script.lua");
// 
// 			textBoxInventoryItemsQuests.Text = qg.Inventory;
// 		}

	}
}
