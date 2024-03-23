using QuizGame.controller;
using QuizGame.@interface;

namespace QuizGame.gui {

	internal class MultiChoiceQuestionGui : BaseQuestionGui {
		private readonly string name;
		private readonly MultiChoiceQuestion question;
		private readonly QuestionController.Result result;

		public MultiChoiceQuestionGui(string name, MultiChoiceQuestion question, ref QuestionController.Result result) : base() {
			this.name = name;
			this.question = question;
			this.result = result;
			InitializeComponent();
		}

		protected override void ConfirmAction(object? sender, EventArgs e) {
			int answer = 0x0000;
			answer |= answer_1.Checked ? 0x1000 : 0;
			answer |= answer_2.Checked ? 0x0100 : 0;
			answer |= answer_3.Checked ? 0x0010 : 0;
			answer |= answer_4.Checked ? 0x0001 : 0;

			result.Correct = answer == question.CorrectAnswer && question.CorrectAnswer != 0;
			Dispose();
		}

		private void InitializeComponent() {
			answer_table = new TableLayoutPanel();
			answer_1 = new CheckBox();
			answer_2 = new CheckBox();
			answer_3 = new CheckBox();
			answer_4 = new CheckBox();
			answer_table.SuspendLayout();
			SuspendLayout();
			//
			// answer_table
			//
			answer_table.ColumnCount = 2;
			answer_table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			answer_table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			answer_table.Controls.Add(answer_1, 0, 0);
			answer_table.Controls.Add(answer_2, 1, 0);
			answer_table.Controls.Add(answer_3, 0, 1);
			answer_table.Controls.Add(answer_4, 1, 1);
			answer_table.Dock = DockStyle.Fill;
			answer_table.Location = new Point(3, 19);
			answer_table.Name = "answer_table";
			answer_table.RowCount = 2;
			answer_table.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			answer_table.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			answer_table.Size = new Size(554, 142);
			answer_table.TabIndex = 0;
			//
			// checkBox1
			//
			answer_1.AutoSize = true;
			answer_1.Location = new Point(3, 3);
			answer_1.Name = "answer_1";
			answer_1.Size = new Size(83, 19);
			answer_1.TabIndex = 0;
			answer_1.Text = question.Answers[0];
			answer_1.UseVisualStyleBackColor = true;
			//
			// checkBox2
			//
			answer_2.AutoSize = true;
			answer_2.Location = new Point(280, 3);
			answer_2.Name = "answer_2";
			answer_2.Size = new Size(83, 19);
			answer_2.TabIndex = 1;
			answer_2.Text = question.Answers[1];
			answer_2.UseVisualStyleBackColor = true;
			//
			// checkBox3
			//
			answer_3.AutoSize = true;
			answer_3.Location = new Point(3, 74);
			answer_3.Name = "answer_3";
			answer_3.Size = new Size(83, 19);
			answer_3.TabIndex = 2;
			answer_3.Text = question.Answers[2];
			answer_3.UseVisualStyleBackColor = true;
			//
			// checkBox4
			//
			answer_4.AutoSize = true;
			answer_4.Location = new Point(280, 74);
			answer_4.Name = "answer_4";
			answer_4.Size = new Size(83, 19);
			answer_4.TabIndex = 3;
			answer_4.Text = question.Answers[3];
			answer_4.UseVisualStyleBackColor = true;
			//
			// MultiChoiceQuestionGui
			//
			ClientSize = new Size(584, 361);
			base.question.Text = question.Question;
			answer_area.Controls.Add(answer_table);
			Text = name;
			Name = "MultiChoiceQuestionGui";
			answer_table.ResumeLayout(false);
			answer_table.PerformLayout();
			ResumeLayout(false);
		}

		private CheckBox answer_1;
		private CheckBox answer_2;
		private CheckBox answer_3;
		private CheckBox answer_4;
		private TableLayoutPanel answer_table;
	}
}