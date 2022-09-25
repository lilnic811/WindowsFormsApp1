namespace Alarm501
{
    partial class AlarmView
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
            this.ux_AlarmList = new System.Windows.Forms.ListBox();
            this.ux_AddButton = new System.Windows.Forms.Button();
            this.ux_EditButton = new System.Windows.Forms.Button();
            this.ux_SnoozeButton = new System.Windows.Forms.Button();
            this.ux_StopButton = new System.Windows.Forms.Button();
            this.ux_alarmStatusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ux_AlarmList
            // 
            this.ux_AlarmList.FormattingEnabled = true;
            this.ux_AlarmList.ItemHeight = 16;
            this.ux_AlarmList.Location = new System.Drawing.Point(12, 105);
            this.ux_AlarmList.Name = "ux_AlarmList";
            this.ux_AlarmList.Size = new System.Drawing.Size(364, 148);
            this.ux_AlarmList.TabIndex = 0;
            this.ux_AlarmList.SelectedIndexChanged += new System.EventHandler(this.ux_AlarmList_SelectedIndexChanged);
            // 
            // ux_AddButton
            // 
            this.ux_AddButton.Location = new System.Drawing.Point(13, 29);
            this.ux_AddButton.Name = "ux_AddButton";
            this.ux_AddButton.Size = new System.Drawing.Size(128, 60);
            this.ux_AddButton.TabIndex = 1;
            this.ux_AddButton.Text = "+ Add";
            this.ux_AddButton.UseVisualStyleBackColor = true;
            this.ux_AddButton.Click += new System.EventHandler(this.ux_AddButton_Click);
            // 
            // ux_EditButton
            // 
            this.ux_EditButton.Location = new System.Drawing.Point(248, 29);
            this.ux_EditButton.Name = "ux_EditButton";
            this.ux_EditButton.Size = new System.Drawing.Size(128, 60);
            this.ux_EditButton.TabIndex = 2;
            this.ux_EditButton.Text = "Edit";
            this.ux_EditButton.UseVisualStyleBackColor = true;
            this.ux_EditButton.Click += new System.EventHandler(this.ux_EditButton_Click);
            // 
            // ux_SnoozeButton
            // 
            this.ux_SnoozeButton.Enabled = false;
            this.ux_SnoozeButton.Location = new System.Drawing.Point(13, 321);
            this.ux_SnoozeButton.Name = "ux_SnoozeButton";
            this.ux_SnoozeButton.Size = new System.Drawing.Size(128, 57);
            this.ux_SnoozeButton.TabIndex = 3;
            this.ux_SnoozeButton.Text = "Snooze";
            this.ux_SnoozeButton.UseVisualStyleBackColor = true;
            this.ux_SnoozeButton.Click += new System.EventHandler(this.ux_SnoozeButton_Click);
            // 
            // ux_StopButton
            // 
            this.ux_StopButton.Enabled = false;
            this.ux_StopButton.Location = new System.Drawing.Point(248, 321);
            this.ux_StopButton.Name = "ux_StopButton";
            this.ux_StopButton.Size = new System.Drawing.Size(127, 57);
            this.ux_StopButton.TabIndex = 4;
            this.ux_StopButton.Text = "Stop";
            this.ux_StopButton.UseVisualStyleBackColor = true;
            this.ux_StopButton.Click += new System.EventHandler(this.ux_StopButton_Click);
            // 
            // ux_alarmStatusLabel
            // 
            this.ux_alarmStatusLabel.AutoSize = true;
            this.ux_alarmStatusLabel.Location = new System.Drawing.Point(12, 266);
            this.ux_alarmStatusLabel.Name = "ux_alarmStatusLabel";
            this.ux_alarmStatusLabel.Size = new System.Drawing.Size(82, 16);
            this.ux_alarmStatusLabel.TabIndex = 5;
            this.ux_alarmStatusLabel.Text = "Alarm Status";
            // 
            // AlarmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 392);
            this.Controls.Add(this.ux_alarmStatusLabel);
            this.Controls.Add(this.ux_StopButton);
            this.Controls.Add(this.ux_SnoozeButton);
            this.Controls.Add(this.ux_EditButton);
            this.Controls.Add(this.ux_AddButton);
            this.Controls.Add(this.ux_AlarmList);
            this.Name = "AlarmView";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Close_Alarm);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ux_AlarmList;
        private System.Windows.Forms.Button ux_AddButton;
        private System.Windows.Forms.Button ux_EditButton;
        private System.Windows.Forms.Button ux_SnoozeButton;
        private System.Windows.Forms.Button ux_StopButton;
        private System.Windows.Forms.Label ux_alarmStatusLabel;
    }
}

