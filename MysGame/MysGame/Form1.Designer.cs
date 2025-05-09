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
        home_titleLabel = new System.Windows.Forms.Label();
        home_newGameButton = new System.Windows.Forms.Button();
        home_roadGameButton = new System.Windows.Forms.Button();
        home_settingButton = new System.Windows.Forms.Button();
        home_exitButton = new System.Windows.Forms.Button();
        home_galleryButton = new System.Windows.Forms.Button();
        homePanel = new System.Windows.Forms.Panel();
        gamePanel = new System.Windows.Forms.Panel();
        game_phoneBoxLabel = new System.Windows.Forms.Label();
        homePanel.SuspendLayout();
        gamePanel.SuspendLayout();
        SuspendLayout();
        // 
        // home_titleLabel
        // 
        home_titleLabel.Font = new System.Drawing.Font("Ink Free", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        home_titleLabel.ForeColor = System.Drawing.Color.White;
        home_titleLabel.Location = new System.Drawing.Point(-8, 54);
        home_titleLabel.Name = "home_titleLabel";
        home_titleLabel.Size = new System.Drawing.Size(540, 169);
        home_titleLabel.TabIndex = 0;
        home_titleLabel.Text = "home_title";
        home_titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // home_newGameButton
        // 
        home_newGameButton.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        home_newGameButton.Location = new System.Drawing.Point(0, 307);
        home_newGameButton.Name = "home_newGameButton";
        home_newGameButton.Size = new System.Drawing.Size(159, 49);
        home_newGameButton.TabIndex = 1;
        home_newGameButton.TabStop = false;
        home_newGameButton.Text = "새 게임";
        home_newGameButton.UseVisualStyleBackColor = true;
        home_newGameButton.Click += home_newGameButton_Click;
        // 
        // home_roadGameButton
        // 
        home_roadGameButton.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        home_roadGameButton.Location = new System.Drawing.Point(0, 362);
        home_roadGameButton.Name = "home_roadGameButton";
        home_roadGameButton.Size = new System.Drawing.Size(159, 49);
        home_roadGameButton.TabIndex = 2;
        home_roadGameButton.TabStop = false;
        home_roadGameButton.Text = "불러오기";
        home_roadGameButton.UseVisualStyleBackColor = true;
        // 
        // home_settingButton
        // 
        home_settingButton.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        home_settingButton.Location = new System.Drawing.Point(0, 472);
        home_settingButton.Name = "home_settingButton";
        home_settingButton.Size = new System.Drawing.Size(159, 49);
        home_settingButton.TabIndex = 3;
        home_settingButton.TabStop = false;
        home_settingButton.Text = "설정";
        home_settingButton.UseVisualStyleBackColor = true;
        // 
        // home_exitButton
        // 
        home_exitButton.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        home_exitButton.Location = new System.Drawing.Point(0, 527);
        home_exitButton.Name = "home_exitButton";
        home_exitButton.Size = new System.Drawing.Size(159, 49);
        home_exitButton.TabIndex = 4;
        home_exitButton.TabStop = false;
        home_exitButton.Text = "게임 종료";
        home_exitButton.UseVisualStyleBackColor = true;
        home_exitButton.Click += home_exitButton_Click;
        // 
        // home_galleryButton
        // 
        home_galleryButton.Font = new System.Drawing.Font("Ink Free", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        home_galleryButton.Location = new System.Drawing.Point(0, 417);
        home_galleryButton.Name = "home_galleryButton";
        home_galleryButton.Size = new System.Drawing.Size(159, 49);
        home_galleryButton.TabIndex = 5;
        home_galleryButton.TabStop = false;
        home_galleryButton.Text = "도감";
        home_galleryButton.UseVisualStyleBackColor = true;
        // 
        // homePanel
        // 
        homePanel.BackColor = System.Drawing.Color.Black;
        homePanel.Controls.Add(home_titleLabel);
        homePanel.Controls.Add(home_exitButton);
        homePanel.Controls.Add(home_galleryButton);
        homePanel.Controls.Add(home_settingButton);
        homePanel.Controls.Add(home_newGameButton);
        homePanel.Controls.Add(home_roadGameButton);
        homePanel.Dock = System.Windows.Forms.DockStyle.Fill;
        homePanel.Location = new System.Drawing.Point(0, 0);
        homePanel.Name = "homePanel";
        homePanel.Size = new System.Drawing.Size(524, 801);
        homePanel.TabIndex = 6;
        homePanel.Visible = false;
        // 
        // gamePanel
        // 
        gamePanel.BackColor = System.Drawing.Color.Black;
        gamePanel.Controls.Add(game_phoneBoxLabel);
        gamePanel.Location = new System.Drawing.Point(129, 226);
        gamePanel.Name = "gamePanel";
        gamePanel.Size = new System.Drawing.Size(369, 384);
        gamePanel.TabIndex = 7;
        gamePanel.Visible = false;
        // 
        // game_phoneBoxLabel
        // 
        game_phoneBoxLabel.BackColor = System.Drawing.Color.DimGray;
        game_phoneBoxLabel.Font = new System.Drawing.Font("Ink Free", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        game_phoneBoxLabel.ForeColor = System.Drawing.Color.White;
        game_phoneBoxLabel.Location = new System.Drawing.Point(80, 54);
        game_phoneBoxLabel.Name = "game_phoneBoxLabel";
        game_phoneBoxLabel.Size = new System.Drawing.Size(361, 666);
        game_phoneBoxLabel.TabIndex = 6;
        game_phoneBoxLabel.Text = "phoneBox";
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.DimGray;
        ClientSize = new System.Drawing.Size(524, 801);
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

    private System.Windows.Forms.Label game_phoneBoxLabel;

    private System.Windows.Forms.Panel gamePanel;

    private System.Windows.Forms.Button home_settingButton;
    private System.Windows.Forms.Button home_exitButton;
    private System.Windows.Forms.Button home_galleryButton;
    private System.Windows.Forms.Panel homePanel;

    private System.Windows.Forms.Button home_roadGameButton;

    private System.Windows.Forms.Button home_newGameButton;

    private System.Windows.Forms.Label home_titleLabel;

    #endregion
}