using USPG_PII_Ejercicio_ED.DobleLinkList;
using USPG_PII_Ejercicio_ED.History;

namespace USPG_PII_Ejercicio_ED
{
    public partial class frmEditorTxt : Form
    {
            private HistoryList<DocState> _history;

            private bool _isRestoringState = false;

            public frmEditorTxt()
            {
                InitializeComponent();

                var initialState = new DocState { Text = "" };

                _history = new HistoryList<DocState>(initialState);

                textBox1.Text = initialState.Text;
            }
            private void BtnSave_Click(object? sender, EventArgs e)
            {
                var currentState = new DocState { Text = textBox1.Text };
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
