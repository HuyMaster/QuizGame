using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame {

	internal partial class MultiChoiceQuestion : Form {
		private readonly Question q;
		private readonly Action<bool> callback;

		public MultiChoiceQuestion(string title, Question question, Action<bool> c) {
			q = question;
			Text = title;
			callback = c;
			InitializeComponent();
		}

		private void InitializeComponent() {
			question_panel = new Panel();
			question = new Label();
			table = new TableLayoutPanel();
			c_a = new CheckBox();
			c_b = new CheckBox();
			c_c = new CheckBox();
			c_d = new CheckBox();
			confirm = new Button();
			question_panel.SuspendLayout();
			table.SuspendLayout();
			SuspendLayout();
			//
			// question_panel
			//
			question_panel.Controls.Add(question);
			question_panel.Location = new Point(12, 10);
			question_panel.Name = "question_panel";
			question_panel.Size = new Size(260, 105);
			question_panel.TabIndex = 0;
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
			table.Controls.Add(c_a, 0, 0);
			table.Controls.Add(c_b, 1, 0);
			table.Controls.Add(c_c, 0, 1);
			table.Controls.Add(c_d, 1, 1);
			table.Location = new Point(12, 121);
			table.Name = "table";
			table.RowCount = 2;
			table.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			table.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			table.Size = new Size(260, 100);
			table.TabIndex = 1;
			//
			// c_a
			//
			c_a.AutoSize = true;
			c_a.Location = new Point(3, 3);
			c_a.Name = "c_a";
			c_a.Size = new Size(15, 14);
			c_a.Text = q.answers[0];
			c_a.TabIndex = 0;
			c_a.UseVisualStyleBackColor = true;
			//
			// c_b
			//
			c_b.AutoSize = true;
			c_b.Location = new Point(133, 3);
			c_b.Name = "c_b";
			c_b.Size = new Size(15, 14);
			c_b.Text = q.answers[1];
			c_b.TabIndex = 1;
			c_b.UseVisualStyleBackColor = true;
			//
			// c_c
			//
			c_c.AutoSize = true;
			c_c.Location = new Point(3, 53);
			c_c.Name = "c_c";
			c_c.Size = new Size(15, 14);
			c_c.Text = q.answers[2];
			c_c.TabIndex = 2;
			c_c.UseVisualStyleBackColor = true;
			//
			// c_d
			//
			c_d.AutoSize = true;
			c_d.Location = new Point(133, 53);
			c_d.Name = "c_d";
			c_d.Size = new Size(15, 14);
			c_d.Text = q.answers[3];
			c_d.TabIndex = 3;
			c_d.UseVisualStyleBackColor = true;
			//
			// confirm
			//
			confirm.Location = new Point(197, 227);
			confirm.Name = "confirm";
			confirm.Size = new Size(75, 23);
			confirm.TabIndex = 2;
			confirm.Text = "Confirm";
			confirm.UseVisualStyleBackColor = true;
			confirm.Click += ConfirmQuestion;
			//
			// MultiChoiceQuestion
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
			if (c_a.Checked) {
				answer |= 0x1000;
			}
			if (c_b.Checked) {
				answer |= 0x0100;
			}
			if (c_c.Checked) {
				answer |= 0x0010;
			}
			if (c_d.Checked) {
				answer |= 0x0001;
			}
			callback.Invoke((answer & q.correctAnswer) == q.correctAnswer);
			Dispose();
		}

		private Panel question_panel;
		private Label question;
		private TableLayoutPanel table;
		private CheckBox c_a;
		private CheckBox c_b;
		private CheckBox c_c;
		private CheckBox c_d;
		private Button confirm;
	}
}