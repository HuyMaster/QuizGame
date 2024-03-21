using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame {

	internal partial class SingleChoiceQuestion : Form {
		private readonly Question q;
		private readonly Action<bool> callback;

		public SingleChoiceQuestion(string title, Question question, Action<bool> c) {
			q = question;
			Text = title;
			callback = c;
			InitializeComponent();
		}

		private void InitializeComponent() {
			question_panel = new Panel();
			question = new Label();
			table = new TableLayoutPanel();
			answer_1 = new RadioButton();
			answer_2 = new RadioButton();
			answer_3 = new RadioButton();
			answer_4 = new RadioButton();
			confirm = new Button();
			question_panel.SuspendLayout();
			table.SuspendLayout();
			SuspendLayout();
			//
			// question_panel
			//
			question_panel.Controls.Add(question);
			question_panel.Location = new Point(12, 9);
			question_panel.Name = "question_panel";
			question_panel.Size = new Size(260, 105);
			question_panel.TabIndex = 2;
			//
			// question
			//
			question.AutoSize = true;
			question.Location = new Point(12, 9);
			question.Name = "question";
			question.Text = q.question;
			question.Size = new Size(0, 15);
			question.TabIndex = 0;
			//
			// table
			//
			table.ColumnCount = 2;
			table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			table.Controls.Add(answer_1, 0, 0);
			table.Controls.Add(answer_2, 1, 0);
			table.Controls.Add(answer_3, 0, 1);
			table.Controls.Add(answer_4, 1, 1);
			table.Location = new Point(12, 120);
			table.Name = "table";
			table.RowCount = 2;
			table.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			table.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			table.Size = new Size(260, 100);
			table.TabIndex = 1;
			//
			// answer_1
			//
			answer_1.AutoSize = true;
			answer_1.Location = new Point(3, 3);
			answer_1.Name = "answer_1";
			answer_1.Size = new Size(14, 13);
			answer_1.Text = q.answers[0];
			answer_1.TabIndex = 0;
			answer_1.UseVisualStyleBackColor = true;
			//
			// answer_2
			//
			answer_2.AutoSize = true;
			answer_2.Location = new Point(133, 3);
			answer_2.Name = "answer_2";
			answer_2.Size = new Size(14, 13);
			answer_2.Text = q.answers[1];
			answer_2.TabIndex = 1;
			answer_2.UseVisualStyleBackColor = true;
			//
			// answer_3
			//
			answer_3.AutoSize = true;
			answer_3.Location = new Point(3, 53);
			answer_3.Name = "answer_3";
			answer_3.Size = new Size(14, 13);
			answer_3.Text = q.answers[2];
			answer_3.TabIndex = 2;
			answer_3.UseVisualStyleBackColor = true;
			//
			// answer_4
			//
			answer_4.AutoSize = true;
			answer_4.Location = new Point(133, 53);
			answer_4.Name = "answer_4";
			answer_4.Size = new Size(14, 13);
			answer_4.Text = q.answers[3];
			answer_4.TabIndex = 3;
			answer_4.UseVisualStyleBackColor = true;
			//
			// confirm
			//
			confirm.Location = new Point(197, 226);
			confirm.Name = "confirm";
			confirm.Size = new Size(75, 23);
			confirm.TabIndex = 0;
			confirm.Text = "Confirm";
			confirm.UseVisualStyleBackColor = true;
			confirm.Click += ConfirmQuestion;
			//
			// SingleChoiceQuestion
			//
			ClientSize = new Size(284, 261);
			Controls.Add(question_panel);
			Controls.Add(table);
			Controls.Add(confirm);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			question_panel.ResumeLayout(false);
			question_panel.PerformLayout();
			table.ResumeLayout(false);
			table.PerformLayout();
			CenterToScreen();
			ResumeLayout(false);
		}

		private void ConfirmQuestion(object? sender, EventArgs e) {
			int answer = 0x0000;
			if (answer_1.Checked) {
				answer = 0x1000;
			}
			if (answer_2.Checked) {
				answer = 0x0100;
			}
			if (answer_3.Checked) {
				answer = 0x0010;
			}
			if (answer_4.Checked) {
				answer = 0x0001;
			}
			callback.Invoke((answer & q.correctAnswer) != 0);
			Dispose();
		}

		private Label question;
		private TableLayoutPanel table;
		private RadioButton answer_1;
		private RadioButton answer_2;
		private RadioButton answer_3;
		private RadioButton answer_4;
		private Panel question_panel;
		private Button confirm;
	}
}