namespace VRApplicationWF.VirtualReality.Forms
{
    partial class GUI
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
            this.spawnX = new System.Windows.Forms.TextBox();
            this.spawnY = new System.Windows.Forms.TextBox();
            this.spawnZ = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.filepath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nodeName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.scale = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // spawnX
            // 
            this.spawnX.Location = new System.Drawing.Point(1021, 45);
            this.spawnX.Name = "spawnX";
            this.spawnX.Size = new System.Drawing.Size(74, 22);
            this.spawnX.TabIndex = 1;
            this.spawnX.Text = "0";
            // 
            // spawnY
            // 
            this.spawnY.Location = new System.Drawing.Point(1139, 45);
            this.spawnY.Name = "spawnY";
            this.spawnY.Size = new System.Drawing.Size(74, 22);
            this.spawnY.TabIndex = 2;
            this.spawnY.Text = "0";
            // 
            // spawnZ
            // 
            this.spawnZ.Location = new System.Drawing.Point(1261, 45);
            this.spawnZ.Name = "spawnZ";
            this.spawnZ.Size = new System.Drawing.Size(74, 22);
            this.spawnZ.TabIndex = 3;
            this.spawnZ.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(985, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "x:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1101, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "y:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1220, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "z:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1051, 146);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "spawn objects";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_SpawnObjects);
            // 
            // filepath
            // 
            this.filepath.Location = new System.Drawing.Point(1139, 89);
            this.filepath.Name = "filepath";
            this.filepath.Size = new System.Drawing.Size(196, 22);
            this.filepath.TabIndex = 8;
            this.filepath.Text = "data/NetworkEngine/models/trees/fantasy/tree1.obj";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1062, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "filepath:";
            // 
            // nodeName
            // 
            this.nodeName.Location = new System.Drawing.Point(946, 92);
            this.nodeName.Name = "nodeName";
            this.nodeName.Size = new System.Drawing.Size(85, 22);
            this.nodeName.TabIndex = 10;
            this.nodeName.Text = "test";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(849, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "nodeName:";
            // 
            // scale
            // 
            this.scale.Location = new System.Drawing.Point(918, 45);
            this.scale.Name = "scale";
            this.scale.Size = new System.Drawing.Size(52, 22);
            this.scale.TabIndex = 12;
            this.scale.Text = "1.0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(849, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "scale:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1202, 549);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 29);
            this.button2.TabIndex = 14;
            this.button2.Text = "get Scene";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_GetScene);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1202, 497);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(101, 33);
            this.button3.TabIndex = 15;
            this.button3.Text = "reset Scene";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_resetScene);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1202, 440);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(101, 29);
            this.button4.TabIndex = 16;
            this.button4.Text = "do Stuff";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_doStuff);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1381, 620);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.scale);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nodeName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filepath);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.spawnZ);
            this.Controls.Add(this.spawnY);
            this.Controls.Add(this.spawnX);
            this.Name = "GUI";
            this.Text = "GUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox spawnX;
        private System.Windows.Forms.TextBox spawnY;
        private System.Windows.Forms.TextBox spawnZ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox filepath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nodeName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox scale;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}