
namespace LobeClient
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.pathBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.resultPannel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.urlBox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pathBox
            // 
            this.pathBox.Location = new System.Drawing.Point(12, 2);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(706, 21);
            this.pathBox.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "목록 읽기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // resultPannel
            // 
            this.resultPannel.AutoScroll = true;
            this.resultPannel.Location = new System.Drawing.Point(12, 84);
            this.resultPannel.Name = "resultPannel";
            this.resultPannel.Size = new System.Drawing.Size(776, 433);
            this.resultPannel.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(118, 50);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 4;
            this.button2.Text = "분류";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // urlBox
            // 
            this.urlBox.Location = new System.Drawing.Point(12, 23);
            this.urlBox.Name = "urlBox";
            this.urlBox.Size = new System.Drawing.Size(706, 21);
            this.urlBox.TabIndex = 5;
            this.urlBox.Text = "http://localhost:38101/v1/predict/...";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(512, 50);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 6;
            this.button3.Text = "파일 이동";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(618, 50);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 28);
            this.button4.TabIndex = 6;
            this.button4.Text = "파일 복사";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 529);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.urlBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.resultPannel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pathBox);
            this.Name = "MainForm";
            this.Text = "LobeClient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel resultPannel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox urlBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

