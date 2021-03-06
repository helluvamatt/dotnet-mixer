﻿namespace ProjectMixer.UI
{
	partial class MixerOptionsForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MixerOptionsForm));
			this.optionsFormTabControl = new System.Windows.Forms.TabControl();
			this.profilesTabPage = new System.Windows.Forms.TabPage();
			this.settingsTabPage = new System.Windows.Forms.TabPage();
			this.hotkeysTabPage = new System.Windows.Forms.TabPage();
			this.hotkeyListScrollPanel = new System.Windows.Forms.Panel();
			this.hotkeyListLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.hotkeysEnabledCheckBox = new System.Windows.Forms.CheckBox();
			this.optionsFormTabControl.SuspendLayout();
			this.hotkeysTabPage.SuspendLayout();
			this.hotkeyListScrollPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// optionsFormTabControl
			// 
			resources.ApplyResources(this.optionsFormTabControl, "optionsFormTabControl");
			this.optionsFormTabControl.Controls.Add(this.profilesTabPage);
			this.optionsFormTabControl.Controls.Add(this.settingsTabPage);
			this.optionsFormTabControl.Controls.Add(this.hotkeysTabPage);
			this.optionsFormTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
			this.optionsFormTabControl.Multiline = true;
			this.optionsFormTabControl.Name = "optionsFormTabControl";
			this.optionsFormTabControl.SelectedIndex = 0;
			this.optionsFormTabControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.optionsFormTabControl_DrawItem);
			// 
			// profilesTabPage
			// 
			resources.ApplyResources(this.profilesTabPage, "profilesTabPage");
			this.profilesTabPage.Name = "profilesTabPage";
			this.profilesTabPage.UseVisualStyleBackColor = true;
			// 
			// settingsTabPage
			// 
			resources.ApplyResources(this.settingsTabPage, "settingsTabPage");
			this.settingsTabPage.Name = "settingsTabPage";
			this.settingsTabPage.UseVisualStyleBackColor = true;
			// 
			// hotkeysTabPage
			// 
			this.hotkeysTabPage.Controls.Add(this.hotkeyListScrollPanel);
			this.hotkeysTabPage.Controls.Add(this.hotkeysEnabledCheckBox);
			resources.ApplyResources(this.hotkeysTabPage, "hotkeysTabPage");
			this.hotkeysTabPage.Name = "hotkeysTabPage";
			this.hotkeysTabPage.UseVisualStyleBackColor = true;
			// 
			// hotkeyListScrollPanel
			// 
			resources.ApplyResources(this.hotkeyListScrollPanel, "hotkeyListScrollPanel");
			this.hotkeyListScrollPanel.BackColor = System.Drawing.SystemColors.Control;
			this.hotkeyListScrollPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.hotkeyListScrollPanel.Controls.Add(this.hotkeyListLayoutPanel);
			this.hotkeyListScrollPanel.Name = "hotkeyListScrollPanel";
			// 
			// hotkeyListLayoutPanel
			// 
			resources.ApplyResources(this.hotkeyListLayoutPanel, "hotkeyListLayoutPanel");
			this.hotkeyListLayoutPanel.Name = "hotkeyListLayoutPanel";
			// 
			// hotkeysEnabledCheckBox
			// 
			resources.ApplyResources(this.hotkeysEnabledCheckBox, "hotkeysEnabledCheckBox");
			this.hotkeysEnabledCheckBox.Name = "hotkeysEnabledCheckBox";
			this.hotkeysEnabledCheckBox.UseVisualStyleBackColor = true;
			this.hotkeysEnabledCheckBox.CheckedChanged += new System.EventHandler(this.hotkeysEnabledCheckBox_CheckedChanged);
			// 
			// MixerOptionsForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.optionsFormTabControl);
			this.Name = "MixerOptionsForm";
			this.optionsFormTabControl.ResumeLayout(false);
			this.hotkeysTabPage.ResumeLayout(false);
			this.hotkeyListScrollPanel.ResumeLayout(false);
			this.hotkeyListScrollPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl optionsFormTabControl;
		private System.Windows.Forms.TabPage profilesTabPage;
		private System.Windows.Forms.TabPage settingsTabPage;
		private System.Windows.Forms.TabPage hotkeysTabPage;
		private System.Windows.Forms.Panel hotkeyListScrollPanel;
		private System.Windows.Forms.CheckBox hotkeysEnabledCheckBox;
		private System.Windows.Forms.TableLayoutPanel hotkeyListLayoutPanel;
	}
}