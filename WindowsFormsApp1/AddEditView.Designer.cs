namespace Alarm501
{
    partial class AddEditView
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
            this.ux_TimePick = new System.Windows.Forms.DateTimePicker();
            this.ux_SoundComboBox = new System.Windows.Forms.ComboBox();
            this.ux_CancelButton = new System.Windows.Forms.Button();
            this.ux_SetButton = new System.Windows.Forms.Button();
            this.ux_ActiveCheckBox = new System.Windows.Forms.CheckBox();
            this.ux_snoozeLengthLabel = new System.Windows.Forms.Label();
            this.ux_snoozeUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.ux_snoozeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ux_TimePick
            // 
            this.ux_TimePick.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.ux_TimePick.Location = new System.Drawing.Point(12, 12);
            this.ux_TimePick.Name = "ux_TimePick";
            this.ux_TimePick.ShowUpDown = true;
            this.ux_TimePick.Size = new System.Drawing.Size(152, 22);
            this.ux_TimePick.TabIndex = 0;
            // 
            // ux_SoundComboBox
            // 
            this.ux_SoundComboBox.FormattingEnabled = true;
            this.ux_SoundComboBox.Location = new System.Drawing.Point(13, 44);
            this.ux_SoundComboBox.Name = "ux_SoundComboBox";
            this.ux_SoundComboBox.Size = new System.Drawing.Size(232, 24);
            this.ux_SoundComboBox.TabIndex = 1;
            this.ux_SoundComboBox.Text = "Alarm Sound";
            // 
            // ux_CancelButton
            // 
            this.ux_CancelButton.Location = new System.Drawing.Point(12, 122);
            this.ux_CancelButton.Name = "ux_CancelButton";
            this.ux_CancelButton.Size = new System.Drawing.Size(75, 23);
            this.ux_CancelButton.TabIndex = 2;
            this.ux_CancelButton.Text = "Cancel";
            this.ux_CancelButton.UseVisualStyleBackColor = true;
            this.ux_CancelButton.Click += new System.EventHandler(this.ux_CancelButton_Click);
            // 
            // ux_SetButton
            // 
            this.ux_SetButton.Location = new System.Drawing.Point(170, 122);
            this.ux_SetButton.Name = "ux_SetButton";
            this.ux_SetButton.Size = new System.Drawing.Size(75, 23);
            this.ux_SetButton.TabIndex = 3;
            this.ux_SetButton.Text = "Set";
            this.ux_SetButton.UseVisualStyleBackColor = true;
            this.ux_SetButton.Click += new System.EventHandler(this.ux_SetButton_Click);
            // 
            // ux_ActiveCheckBox
            // 
            this.ux_ActiveCheckBox.AutoSize = true;
            this.ux_ActiveCheckBox.Location = new System.Drawing.Point(199, 16);
            this.ux_ActiveCheckBox.Name = "ux_ActiveCheckBox";
            this.ux_ActiveCheckBox.Size = new System.Drawing.Size(46, 20);
            this.ux_ActiveCheckBox.TabIndex = 4;
            this.ux_ActiveCheckBox.Text = "On";
            this.ux_ActiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // ux_snoozeLengthLabel
            // 
            this.ux_snoozeLengthLabel.AutoSize = true;
            this.ux_snoozeLengthLabel.Location = new System.Drawing.Point(12, 80);
            this.ux_snoozeLengthLabel.Name = "ux_snoozeLengthLabel";
            this.ux_snoozeLengthLabel.Size = new System.Drawing.Size(106, 16);
            this.ux_snoozeLengthLabel.TabIndex = 5;
            this.ux_snoozeLengthLabel.Text = "Snooze Duration";
            // 
            // ux_snoozeUpDown
            // 
            this.ux_snoozeUpDown.Location = new System.Drawing.Point(153, 78);
            this.ux_snoozeUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ux_snoozeUpDown.Name = "ux_snoozeUpDown";
            this.ux_snoozeUpDown.Size = new System.Drawing.Size(92, 22);
            this.ux_snoozeUpDown.TabIndex = 6;
            this.ux_snoozeUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // AddEditView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 164);
            this.Controls.Add(this.ux_snoozeUpDown);
            this.Controls.Add(this.ux_snoozeLengthLabel);
            this.Controls.Add(this.ux_ActiveCheckBox);
            this.Controls.Add(this.ux_SetButton);
            this.Controls.Add(this.ux_CancelButton);
            this.Controls.Add(this.ux_SoundComboBox);
            this.Controls.Add(this.ux_TimePick);
            this.Name = "AddEditView";
            this.Text = "AddEditView";
            ((System.ComponentModel.ISupportInitialize)(this.ux_snoozeUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker ux_TimePick;
        private System.Windows.Forms.ComboBox ux_SoundComboBox;
        private System.Windows.Forms.Button ux_CancelButton;
        private System.Windows.Forms.Button ux_SetButton;
        private System.Windows.Forms.CheckBox ux_ActiveCheckBox;
        private System.Windows.Forms.Label ux_snoozeLengthLabel;
        private System.Windows.Forms.NumericUpDown ux_snoozeUpDown;
    }
}