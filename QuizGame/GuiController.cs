namespace QuizGame {

	internal class GuiController {
		public static readonly GuiController instance = new();
		private readonly AtomicReference<Form> controller = new(new MainGui());
		private bool started = false;

		private GuiController() {
			Logger.i("GUI Controller starting...");
		}

		public void Start() {
			if (started) {
				Logger.w("GUI Controller already started");
			} else {
				Show(controller.value);
				started = true;
			}
		}

		public void Change(Form NextForm) {
			Logger.d($"Changed GUI {controller.value.GetType().Name} -> {NextForm.GetType().Name}");
			if (NextForm.GetType() == controller.value.GetType())
				Logger.w("New GUI same class as current!");
			controller.value.Dispose();
			Show(NextForm);
		}

		private void Show(Form Form) {
			Logger.i($"GUI {controller.value.GetType().Name} showing");
			controller.value = Form;
			Form.Disposed += GuiClose;
			controller.value.ShowDialog();
		}

		private void GuiClose(object? sender, EventArgs e) {
			if (sender is Form form)
				Logger.i($"GUI {form.GetType().Name} closed");
		}
	}
}