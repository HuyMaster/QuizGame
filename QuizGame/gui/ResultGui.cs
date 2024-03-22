using QuizGame.controller;

namespace QuizGame.gui {

	internal partial class ResultGui : Form {
		private readonly List<QuestionController.Result> results;

		public ResultGui(List<QuestionController.Result> results) {
			this.results = results;
			InitializeComponent();
		}

		private void InitializeComponent() {
			result_table = new DataGridView();
			question = new DataGridViewTextBoxColumn();
			result = new DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize) result_table).BeginInit();
			SuspendLayout();
			//
			// result_table
			//
			result_table.AllowUserToAddRows = false;
			result_table.AllowUserToDeleteRows = false;
			result_table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			result_table.Columns.AddRange([question, result]);
			foreach (QuestionController.Result r in results) {
				int index = result_table.Rows.Add($"{r.Question}", $"{r.Correct}");
				result_table.Rows[index].DefaultCellStyle.BackColor = r.Correct ? Color.Green : Color.Red;
			}
			result_table.Location = new Point(12, 12);
			result_table.Name = "result_table";
			result_table.Dock = DockStyle.Fill;
			result_table.ReadOnly = true;
			result_table.Size = new Size(560, 337);
			result_table.TabIndex = 0;
			//
			// question
			//
			question.DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			question.DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			question.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
			question.HeaderText = $"Question ({results.FindAll(x => x.Correct).Count}/{results.Count})";
			question.Name = "question";
			question.ReadOnly = true;
			question.SortMode = DataGridViewColumnSortMode.NotSortable;
			//
			// result
			//
			result.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
			result.HeaderText = "Result";
			result.Name = "result";
			result.ReadOnly = true;
			result.SortMode = DataGridViewColumnSortMode.NotSortable;
			result.Width = 45;
			//
			// ResultGui
			//
			ClientSize = new Size(584, 361);
			Controls.Add(result_table);
			Name = "ResultGui";
			StartPosition = FormStartPosition.CenterScreen;
			((System.ComponentModel.ISupportInitialize) result_table).EndInit();
			ResumeLayout(false);
		}

		private DataGridViewTextBoxColumn question;
		private DataGridViewTextBoxColumn result;
		private DataGridView result_table;
	}
}