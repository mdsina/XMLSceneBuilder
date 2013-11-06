using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using SceneEditor.Classes;
using SceneEditor.Classes.Collections;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using System.Collections;
using DevExpress.XtraBars.Helpers;
using System.Windows.Forms;



namespace SceneEditor.Forms
{
    public partial class Form1 : XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            SkinHelper.InitSkinPopupMenu(mPaintStyle); InitTreeListControl(); 
        }
        void InitTreeListControl()
        {
            Projects projects = InitData();
            
        }
        Projects InitData()
        {
            Projects projects = new Projects();
            projects.Add(new Project("Project A", false));
            projects.Add(new Project("Project B", false));
            projects[0].Projects.Add(new Project("Task 1", true));
            projects[0].Projects.Add(new Project("Task 2", true));
            projects[0].Projects.Add(new Project("Task 3", true));
            projects[0].Projects.Add(new Project("Task 4", true));
            projects[1].Projects.Add(new Project("Task 1", true));
            projects[1].Projects.Add(new Project("Task 2", true));
            return projects;
        }
     
      

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            SceneManagerForm childForm = new SceneManagerForm();

            childForm.MdiParent = this;
            childForm.Show();
        }

    }
}