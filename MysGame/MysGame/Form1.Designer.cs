namespace MysGame;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
        homePanel = new System.Windows.Forms.Panel();
        home_exitButton = new System.Windows.Forms.Button();
        home_settingButton = new System.Windows.Forms.Button();
        home_loadGameButton = new System.Windows.Forms.Button();
        home_newGameButton = new System.Windows.Forms.Button();
        home_titleLabel = new System.Windows.Forms.Label();
        textBox = new System.Windows.Forms.Label();
        gamePanel = new System.Windows.Forms.Panel();
        homePanel.SuspendLayout();
        gamePanel.SuspendLayout();
        SuspendLayout();
        // 
        // homePanel
        // 
        homePanel.BackColor = System.Drawing.Color.Black;
        homePanel.Controls.Add(home_exitButton);
        homePanel.Controls.Add(home_settingButton);
        homePanel.Controls.Add(home_loadGameButton);
        homePanel.Controls.Add(home_newGameButton);
        homePanel.Controls.Add(home_titleLabel);
        homePanel.Location = new System.Drawing.Point(322, 46);
        homePanel.Name = "homePanel";
        homePanel.Size = new System.Drawing.Size(181, 207);
        homePanel.TabIndex = 0;
        // 
        // home_exitButton
        // 
        home_exitButton.Location = new System.Drawing.Point(191, 451);
        home_exitButton.Name = "home_exitButton";
        home_exitButton.Size = new System.Drawing.Size(100, 41);
        home_exitButton.TabIndex = 4;
        home_exitButton.UseVisualStyleBackColor = true;
        home_exitButton.Click += home_exitButton_Click;
        // 
        // home_settingButton
        // 
        home_settingButton.Location = new System.Drawing.Point(191, 404);
        home_settingButton.Name = "home_settingButton";
        home_settingButton.Size = new System.Drawing.Size(100, 41);
        home_settingButton.TabIndex = 3;
        home_settingButton.UseVisualStyleBackColor = true;
        // 
        // home_loadGameButton
        // 
        home_loadGameButton.Location = new System.Drawing.Point(191, 357);
        home_loadGameButton.Name = "home_loadGameButton";
        home_loadGameButton.Size = new System.Drawing.Size(100, 41);
        home_loadGameButton.TabIndex = 2;
        home_loadGameButton.UseVisualStyleBackColor = true;
        // 
        // home_newGameButton
        // 
        home_newGameButton.Location = new System.Drawing.Point(191, 310);
        home_newGameButton.Name = "home_newGameButton";
        home_newGameButton.Size = new System.Drawing.Size(100, 41);
        home_newGameButton.TabIndex = 1;
        home_newGameButton.UseVisualStyleBackColor = true;
        home_newGameButton.Click += home_newGameButton_Click;
        // 
        // home_titleLabel
        // 
        home_titleLabel.Font = new System.Drawing.Font("Ink Free", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        home_titleLabel.ForeColor = System.Drawing.Color.White;
        home_titleLabel.Location = new System.Drawing.Point(73, 75);
        home_titleLabel.Name = "home_titleLabel";
        home_titleLabel.Size = new System.Drawing.Size(343, 151);
        home_titleLabel.TabIndex = 0;
        home_titleLabel.Text = "title";
        // 
        // textBox
        // 
        textBox.Font = new System.Drawing.Font("Ink Free", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        textBox.ForeColor = System.Drawing.Color.White;
        textBox.Location = new System.Drawing.Point(33, 61);
        textBox.Name = "textBox";
        textBox.Size = new System.Drawing.Size(145, 70);
        textBox.TabIndex = 5;
        textBox.Text = "prologue";
        // 
        // gamePanel
        // 
        gamePanel.BackColor = System.Drawing.Color.Black;
        gamePanel.Controls.Add(textBox);
        gamePanel.Location = new System.Drawing.Point(139, 319);
        gamePanel.Name = "gamePanel";
        gamePanel.Size = new System.Drawing.Size(216, 207);
        gamePanel.TabIndex = 6;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.DimGray;
        ClientSize = new System.Drawing.Size(884, 561);
        Controls.Add(homePanel);
        Controls.Add(gamePanel);
        Location = new System.Drawing.Point(15, 15);
        MaximizeBox = false;
        MinimizeBox = false;
        ShowIcon = false;
        Text = "MysGame";
        homePanel.ResumeLayout(false);
        gamePanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label textBox;
    private System.Windows.Forms.Panel gamePanel;

    private System.Windows.Forms.Label home_titleLabel;
    private System.Windows.Forms.Button home_newGameButton;
    private System.Windows.Forms.Button home_loadGameButton;
    private System.Windows.Forms.Button home_settingButton;
    private System.Windows.Forms.Button home_exitButton;

    private System.Windows.Forms.Panel homePanel;

    #endregion
}