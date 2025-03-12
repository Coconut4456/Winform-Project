using System.ComponentModel;

namespace ColorBlock;

partial class Form2
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        SetPlayTimeLabel = new System.Windows.Forms.Label();
        plusPlayTime = new System.Windows.Forms.Button();
        minusPlayTime = new System.Windows.Forms.Button();
        playtimeLabel = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // SetPlayTimeLabel
        // 
        SetPlayTimeLabel.Location = new System.Drawing.Point(-8, 0);
        SetPlayTimeLabel.Name = "SetPlayTimeLabel";
        SetPlayTimeLabel.Size = new System.Drawing.Size(202, 27);
        SetPlayTimeLabel.TabIndex = 0;
        SetPlayTimeLabel.Text = "SetPlayTime";
        SetPlayTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // plusPlayTime
        // 
        plusPlayTime.Location = new System.Drawing.Point(97, 81);
        plusPlayTime.Name = "plusPlayTime";
        plusPlayTime.Size = new System.Drawing.Size(79, 26);
        plusPlayTime.TabIndex = 1;
        plusPlayTime.Text = "+10";
        plusPlayTime.UseVisualStyleBackColor = true;
        plusPlayTime.Click += plusPlayTime_Click;
        // 
        // minusPlayTime
        // 
        minusPlayTime.Location = new System.Drawing.Point(12, 81);
        minusPlayTime.Name = "minusPlayTime";
        minusPlayTime.Size = new System.Drawing.Size(79, 26);
        minusPlayTime.TabIndex = 2;
        minusPlayTime.Text = "-10";
        minusPlayTime.UseVisualStyleBackColor = true;
        minusPlayTime.Click += minusPlayTime_Click;
        // 
        // playtimeLabel
        // 
        playtimeLabel.Location = new System.Drawing.Point(-8, 27);
        playtimeLabel.Name = "playtimeLabel";
        playtimeLabel.Size = new System.Drawing.Size(202, 51);
        playtimeLabel.TabIndex = 3;
        playtimeLabel.Text = "playTime";
        playtimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // Form2
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(186, 113);
        Controls.Add(playtimeLabel);
        Controls.Add(minusPlayTime);
        Controls.Add(plusPlayTime);
        Controls.Add(SetPlayTimeLabel);
        MaximizeBox = false;
        MinimizeBox = false;
        Text = "debug";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button plusPlayTime;
    private System.Windows.Forms.Button minusPlayTime;
    private System.Windows.Forms.Label playtimeLabel;

    private System.Windows.Forms.Label SetPlayTimeLabel;

    #endregion
}