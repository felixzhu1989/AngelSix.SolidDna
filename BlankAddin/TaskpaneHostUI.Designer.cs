namespace BlankAddin
{
    partial class TaskpaneHostUI
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.MyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MyButton
            // 
            this.MyButton.Location = new System.Drawing.Point(35, 33);
            this.MyButton.Name = "MyButton";
            this.MyButton.Size = new System.Drawing.Size(75, 23);
            this.MyButton.TabIndex = 0;
            this.MyButton.Text = "My Button";
            this.MyButton.UseVisualStyleBackColor = true;
            // 
            // TaskpaneHostUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MyButton);
            this.Name = "TaskpaneHostUI";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MyButton;
    }
}
