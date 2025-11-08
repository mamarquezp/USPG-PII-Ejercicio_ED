using System.Threading.Tasks;
using USPG_PII_Ejercicio_ED.DobleLinkList;
using USPG_PII_Ejercicio_ED.History;

namespace USPG_PII_Ejercicio_ED
{
    public partial class frmEditorTxt : Form
    {
        private int debounceTime = 500;

        private HistoryList<DocState> _history;
        private bool _isRestoringState = false;
        private CancellationTokenSource? _debounceTokenSource;

        public frmEditorTxt()
        {
            InitializeComponent();

            var initialState = new DocState { Text = "" };

            _history = new HistoryList<DocState>(initialState);

            _history.Capacity = 5;

            textBox1.Text = initialState.Text;

            btnUndo.Click += BtnUndo_Click;
            btnRedo.Click += BtnRedo_Click;
            textBox1.TextChanged += textBox1_TextChanged;

            UpdateButtons();
        }

        private void SaveCurrentState()
        {
            string newText = textBox1.Text;
            string? lastSavedText = _history.CurrentState?.Text;

            if (string.Equals(newText, lastSavedText))
            {
                return;
            }

            var currentState = new DocState { Text = newText };
            _history.Push(currentState);
            UpdateButtons();
        }
        private void BtnSave_Click(object? sender, EventArgs e)
        {
            string newText = textBox1.Text;
            string lastSavedText = _history.CurrentState?.Text;
            if (string.Equals(newText, lastSavedText))//comparación contra el último guardado
            {
                return;
            }

            var currentState = new DocState { Text = newText };
            _history.Push(currentState);
            UpdateButtons();
        }
        private void BtnUndo_Click(object? sender, EventArgs e)
        {
            var previousState = _history.UndoOrDefault(null);

            if (previousState != null)
            {
                _isRestoringState = true;
                textBox1.Text = previousState.Text;
                textBox1.Select(textBox1.Text.Length, 0);
                _isRestoringState = false;

                UpdateButtons();
            }
        }
        private void BtnRedo_Click(object? sender, EventArgs e)
        {
            var nextState = _history.RedoOrDefault(null);

            if (nextState != null)
            {
                _isRestoringState = true;
                textBox1.Text = nextState.Text;
                textBox1.Select(textBox1.Text.Length, 0);
                _isRestoringState = false;

                UpdateButtons();
            }
        }

        private void UpdateButtons()
        {
            btnUndo.Enabled = _history.CanUndo;
            btnRedo.Enabled = _history.CanRedo;
        }

        private async void textBox1_TextChanged(object? sender, EventArgs e)
        {
            // 1. Si el cambio vino de Undo/Redo, no hagas nada.
            if (_isRestoringState) return;

            try
            {
                _debounceTokenSource?.Cancel();

                _debounceTokenSource = new CancellationTokenSource();

                await Task.Delay(debounceTime, _debounceTokenSource.Token);

                SaveCurrentState();
            }
            catch (TaskCanceledException)
            {}
        }

        /*
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!_isRestoringState)
            {
            }
        }
        */
    }
}
