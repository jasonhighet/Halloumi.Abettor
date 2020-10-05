using System.ComponentModel;
using System.Diagnostics;

namespace Halloumi.Abettor.Controllers
{
    partial class AbettorController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cpuCounter = new System.Diagnostics.PerformanceCounter();
            this.ramCounter = new System.Diagnostics.PerformanceCounter();
            ((System.ComponentModel.ISupportInitialize)(this.cpuCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ramCounter)).BeginInit();
            // 
            // cpuCounter
            // 
            this.cpuCounter.CategoryName = "Processor";
            this.cpuCounter.CounterName = "% Processor Time";
            this.cpuCounter.InstanceName = "_Total";
            // 
            // ramCounter
            // 
            this.ramCounter.CategoryName = "Memory";
            this.ramCounter.CounterName = "% Committed Bytes In Use";
            ((System.ComponentModel.ISupportInitialize)(this.cpuCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ramCounter)).EndInit();

        }

        #endregion

        private PerformanceCounter cpuCounter;
        private PerformanceCounter ramCounter;
    }
}
