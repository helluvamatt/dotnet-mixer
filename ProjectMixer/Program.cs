﻿using Common.TrayApplication;
using log4net.Config;
using Mono.Options;
using ProjectMixer.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectMixer
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			// Check if this is the only instance of this application
			if (!SingleInstance.Start())
			{
				// This is not the only instance, exit
				Console.WriteLine(Resources.AnotherInstance);
				return;
			}

			// Configure logging
			BasicConfigurator.Configure();

			// Create the TrayApplicationContext - the controller of the entire application
			MixerTrayApplicationContext ctxt = new MixerTrayApplicationContext();
			ctxt.Logger.Info("Initializing...");

			// Options
			OptionSet options = new OptionSet() {
				{ "startup", "Do not show the options form.", v => ctxt.ShowOptionsForm = v == null }
			};
			options.Parse(args);

			// Initialize the application
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			ctxt.InitializeContext();

			// Run the application
			ctxt.Logger.Info("Initialized. Starting main loop...");
			try
			{
				Application.Run(ctxt);
			}
			catch (Exception ex)
			{
				ctxt.Logger.Error("Unexpected exception:", ex);
				MessageBox.Show(ex.Message, Resources.ProgramTerminated, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			// Log the shutdown
			ctxt.Logger.Info("Exiting...");

			// all finished so release the mutex
			SingleInstance.Stop();
		}
	}
}
