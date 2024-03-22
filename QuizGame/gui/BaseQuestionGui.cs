namespace QuizGame.gui {

	internal abstract partial class BaseQuestionGui : Form {

		public BaseQuestionGui() {
			InitializeComponent();
		}

		private void InitializeComponent() {
			question_area = new GroupBox();
			question = new Label();
			answer_area = new GroupBox();
			confirmButton = new Button();
			question_area.SuspendLayout();
			SuspendLayout();
			//
			// question_area
			//
			question_area.Controls.Add(question);
			question_area.Location = new Point(12, 12);
			question_area.Name = "question_area";
			question_area.Size = new Size(560, 138);
			question_area.TabStop = false;
			question_area.Text = "Question";
			//
			// question
			//
			question.AutoSize = true;
			question.Dock = DockStyle.Fill;
			question.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
			question.Location = new Point(3, 19);
			question.Name = "question";
			question.Size = new Size(0, 21);
			question.TabIndex = 0;
			//
			// answer_area
			//
			answer_area.Location = new Point(12, 156);
			answer_area.Name = "answer_area";
			answer_area.Size = new Size(560, 164);
			answer_area.TabStop = false;
			answer_area.Text = "Answer";
			//
			// confirmButton
			//
			confirmButton.Location = new Point(497, 326);
			confirmButton.Name = "confirmButton";
			confirmButton.Size = new Size(75, 23);
			confirmButton.Text = "Confirm";
			confirmButton.UseVisualStyleBackColor = true;
			confirmButton.Click += ConfirmAction;
			//
			// BaseQuestionGui
			//
			ClientSize = new Size(584, 361);
			Controls.Add(question_area);
			Controls.Add(answer_area);
			Controls.Add(confirmButton);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "BaseQuestionGui";
			StartPosition = FormStartPosition.CenterScreen;
			question_area.ResumeLayout(false);
			question_area.PerformLayout();
			ResumeLayout(false);
		}

		protected abstract void ConfirmAction(object? sender, EventArgs e);

		protected GroupBox question_area;
		protected GroupBox answer_area;
		protected Button confirmButton;
		protected Label question;
	}
}