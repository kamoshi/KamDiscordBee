
namespace MusicBeePlugin
{
    partial class SettingsWindow
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
            System.Windows.Forms.GroupBox groupBox2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.GroupBox groupBox1;
            System.Windows.Forms.Label label2;
            this.textBoxAssetKey = new System.Windows.Forms.TextBox();
            this.checkBoxUseCustomAssetKey = new System.Windows.Forms.CheckBox();
            this.textBoxLargeImageDetail = new System.Windows.Forms.TextBox();
            this.textBoxTopLine = new System.Windows.Forms.TextBox();
            this.checkBoxTrackNoCount = new System.Windows.Forms.CheckBox();
            this.textBoxBottomLine = new System.Windows.Forms.TextBox();
            this.checkBoxTimeShowRemaining = new System.Windows.Forms.CheckBox();
            this.checkBoxTimeShow = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.buttonDefaults = new System.Windows.Forms.Button();
            this.textBoxAppId = new System.Windows.Forms.TextBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            label1 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            label2 = new System.Windows.Forms.Label();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(this.textBoxAppId);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(this.textBoxAssetKey);
            groupBox2.Controls.Add(this.checkBoxUseCustomAssetKey);
            groupBox2.Controls.Add(this.textBoxLargeImageDetail);
            groupBox2.Location = new System.Drawing.Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(268, 129);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Large Image";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(21, 101);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(73, 17);
            label1.TabIndex = 10;
            label1.Text = "Asset key:";
            // 
            // textBoxAssetKey
            // 
            this.textBoxAssetKey.Location = new System.Drawing.Point(129, 98);
            this.textBoxAssetKey.Name = "textBoxAssetKey";
            this.textBoxAssetKey.Size = new System.Drawing.Size(117, 22);
            this.textBoxAssetKey.TabIndex = 11;
            // 
            // checkBoxUseCustomAssetKey
            // 
            this.checkBoxUseCustomAssetKey.AutoSize = true;
            this.checkBoxUseCustomAssetKey.Location = new System.Drawing.Point(6, 51);
            this.checkBoxUseCustomAssetKey.Name = "checkBoxUseCustomAssetKey";
            this.checkBoxUseCustomAssetKey.Size = new System.Drawing.Size(254, 21);
            this.checkBoxUseCustomAssetKey.TabIndex = 10;
            this.checkBoxUseCustomAssetKey.Text = "Use custom asset (dynamic covers)";
            this.checkBoxUseCustomAssetKey.UseVisualStyleBackColor = true;
            this.checkBoxUseCustomAssetKey.CheckedChanged += new System.EventHandler(this.checkBoxUseCustomAssetKey_CheckedChanged);
            // 
            // textBoxLargeImageDetail
            // 
            this.textBoxLargeImageDetail.Location = new System.Drawing.Point(6, 21);
            this.textBoxLargeImageDetail.Name = "textBoxLargeImageDetail";
            this.textBoxLargeImageDetail.Size = new System.Drawing.Size(253, 22);
            this.textBoxLargeImageDetail.TabIndex = 9;
            this.textBoxLargeImageDetail.TextChanged += new System.EventHandler(this.textBoxLargeImageDetail_TextChanged);
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(this.textBoxTopLine);
            groupBox1.Controls.Add(this.checkBoxTrackNoCount);
            groupBox1.Controls.Add(this.textBoxBottomLine);
            groupBox1.Controls.Add(this.checkBoxTimeShowRemaining);
            groupBox1.Controls.Add(this.checkBoxTimeShow);
            groupBox1.Location = new System.Drawing.Point(286, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(267, 158);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Rich presence info";
            groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // textBoxTopLine
            // 
            this.textBoxTopLine.Location = new System.Drawing.Point(6, 21);
            this.textBoxTopLine.Name = "textBoxTopLine";
            this.textBoxTopLine.Size = new System.Drawing.Size(253, 22);
            this.textBoxTopLine.TabIndex = 6;
            this.textBoxTopLine.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // checkBoxTrackNoCount
            // 
            this.checkBoxTrackNoCount.AccessibleDescription = "Show track number and track count in rich presence";
            this.checkBoxTrackNoCount.AccessibleName = "Show track number and track count";
            this.checkBoxTrackNoCount.AutoSize = true;
            this.checkBoxTrackNoCount.Location = new System.Drawing.Point(6, 131);
            this.checkBoxTrackNoCount.Name = "checkBoxTrackNoCount";
            this.checkBoxTrackNoCount.Size = new System.Drawing.Size(253, 21);
            this.checkBoxTrackNoCount.TabIndex = 8;
            this.checkBoxTrackNoCount.Text = "Show track number and track count";
            this.checkBoxTrackNoCount.UseVisualStyleBackColor = true;
            // 
            // textBoxBottomLine
            // 
            this.textBoxBottomLine.Location = new System.Drawing.Point(6, 49);
            this.textBoxBottomLine.Name = "textBoxBottomLine";
            this.textBoxBottomLine.Size = new System.Drawing.Size(253, 22);
            this.textBoxBottomLine.TabIndex = 5;
            // 
            // checkBoxTimeShowRemaining
            // 
            this.checkBoxTimeShowRemaining.AccessibleDescription = "Shows remaining time rather than elapsed time";
            this.checkBoxTimeShowRemaining.AccessibleName = "Show remaining time";
            this.checkBoxTimeShowRemaining.AutoSize = true;
            this.checkBoxTimeShowRemaining.Location = new System.Drawing.Point(6, 104);
            this.checkBoxTimeShowRemaining.Name = "checkBoxTimeShowRemaining";
            this.checkBoxTimeShowRemaining.Size = new System.Drawing.Size(160, 21);
            this.checkBoxTimeShowRemaining.TabIndex = 7;
            this.checkBoxTimeShowRemaining.Text = "Show remaining time";
            this.checkBoxTimeShowRemaining.UseVisualStyleBackColor = true;
            this.checkBoxTimeShowRemaining.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBoxTimeShow
            // 
            this.checkBoxTimeShow.AccessibleDescription = "Enables time in rich presence";
            this.checkBoxTimeShow.AccessibleName = "Display time playing";
            this.checkBoxTimeShow.AutoSize = true;
            this.checkBoxTimeShow.Location = new System.Drawing.Point(6, 77);
            this.checkBoxTimeShow.Name = "checkBoxTimeShow";
            this.checkBoxTimeShow.Size = new System.Drawing.Size(155, 21);
            this.checkBoxTimeShow.TabIndex = 3;
            this.checkBoxTimeShow.Text = "Display time playing";
            this.checkBoxTimeShow.UseVisualStyleBackColor = true;
            this.checkBoxTimeShow.CheckedChanged += new System.EventHandler(this.checkBoxTimeShow_CheckedChanged);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(198, 147);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(73, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(110, 147);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(71, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonDefaults
            // 
            this.buttonDefaults.Location = new System.Drawing.Point(18, 147);
            this.buttonDefaults.Name = "buttonDefaults";
            this.buttonDefaults.Size = new System.Drawing.Size(75, 23);
            this.buttonDefaults.TabIndex = 10;
            this.buttonDefaults.Text = "Default";
            this.buttonDefaults.UseVisualStyleBackColor = true;
            this.buttonDefaults.Click += new System.EventHandler(this.buttonDefaults_Click);
            // 
            // textBoxAppId
            // 
            this.textBoxAppId.Location = new System.Drawing.Point(129, 72);
            this.textBoxAppId.Name = "textBoxAppId";
            this.textBoxAppId.Size = new System.Drawing.Size(117, 22);
            this.textBoxAppId.TabIndex = 12;
            this.textBoxAppId.TextChanged += new System.EventHandler(this.textBoxAppId_TextChanged);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(21, 75);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(98, 17);
            label2.TabIndex = 13;
            label2.Text = "Application ID:";
            label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 176);
            this.Controls.Add(this.buttonDefaults);
            this.Controls.Add(groupBox1);
            this.Controls.Add(groupBox2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Name = "SettingsWindow";
            this.Text = "SettingsWindow";
            this.Load += new System.EventHandler(this.SettingsWindow_Load);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox checkBoxTimeShow;
        private System.Windows.Forms.TextBox textBoxBottomLine;
        private System.Windows.Forms.TextBox textBoxTopLine;
        private System.Windows.Forms.CheckBox checkBoxTimeShowRemaining;
        private System.Windows.Forms.CheckBox checkBoxTrackNoCount;
        private System.Windows.Forms.TextBox textBoxLargeImageDetail;
        private System.Windows.Forms.TextBox textBoxAssetKey;
        private System.Windows.Forms.CheckBox checkBoxUseCustomAssetKey;
        private System.Windows.Forms.TextBox textBoxAppId;
        private System.Windows.Forms.Button buttonDefaults;
    }
}