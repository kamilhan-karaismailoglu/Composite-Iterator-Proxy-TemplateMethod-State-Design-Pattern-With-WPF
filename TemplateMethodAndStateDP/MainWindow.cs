using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TemplateMethodAndStateDP
{
    public partial class MainWindow : Window
    {
        #region Template Method DP Classes

        abstract class TemplateClass
        {
            string text;
            public string Text { get => text; set => text = value; }

            string Text1() => "The text of the TextBlock of the selected list item: \n";
            abstract public string Text2();
            public void TemplateMethod()
            {
                Text = Text1();
                Text += Text2();
            }
        }
        class Concrete1 : TemplateClass
        {
            public override string Text2()
            {
                return "XML in Action";
            }
        }
        class Concrete2 : TemplateClass
        {
            public override string Text2()
            {
                return "Programming Microsoft Windows With C#";
            }
        }
        class Concrete3 : TemplateClass
        {
            public override string Text2()
            {
                return "Inside C#";
            }
        }
        class Concrete4 : TemplateClass
        {
            public override string Text2()
            {
                return "Introducing Microsoft .NET";
            }
        }
        #endregion

        #region State DP Classes

        public interface IState
        {
            public Brush BoxBackground { get; set;} 
            public Brush LabelColor { get; set; }
            void CreatColors();
        }

        public class State1 : IState
        {
            public Brush BoxBackground { get; set; }
            public Brush LabelColor { get; set; }

            public void CreatColors()
            {
                BoxBackground = Brushes.Black;
                LabelColor = Brushes.White; 
            }
        }

        public class State2 : IState
        {
            public Brush BoxBackground { get; set; }
            public Brush LabelColor { get; set; }

            public void CreatColors()
            {
                BoxBackground = Brushes.Yellow;
                LabelColor = Brushes.Green;
            }
        }

        public class State3 : IState
        {
            public Brush BoxBackground { get; set; }
            public Brush LabelColor { get; set; }

            public void CreatColors()
            {
                BoxBackground = Brushes.LightGreen;
                LabelColor = Brushes.Red;
            }
        }

        public class State4 : IState
        {
            public Brush BoxBackground { get; set; }
            public Brush LabelColor { get; set; }

            public void CreatColors()
            {
                BoxBackground = Brushes.LightBlue;
                LabelColor = Brushes.Black;
            }
        }

        public class ContextState
        {
            private IState state;
            public Brush BoxBackground { get; set; }
            public Brush LabelColor { get; set; }

            public ContextState(IState _state)
            {
                state = _state;
                CreatColors();
            }

            public void CreatColors()
            {
                state.CreatColors();
                BoxBackground = state.BoxBackground;
                LabelColor = state.LabelColor;
            }

            public void ChangeState(IState _state)
            {
                state = _state;
            }
        }
        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreatMessageBox(object sender, RoutedEventArgs e)
        {
            #region Template Method DP

            TemplateClass _TemplateClass = null;

            switch (myListBox.SelectedIndex)
            {
                case 0:
                    _TemplateClass = new Concrete1();
                    break;
                case 1:
                    _TemplateClass = new Concrete2();
                    break;
                case 2:
                    _TemplateClass = new Concrete3();
                    break;
                case 3:
                    _TemplateClass = new Concrete4();
                    break;
            }

            _TemplateClass.TemplateMethod();
            MessageBox.Show(_TemplateClass.Text, "info");

            #endregion
        }

        private void CreatStateButton_Click(object sender, RoutedEventArgs e)
        {
            #region State DP

            int index = StateListBox.SelectedIndex;
            ContextState cs;
            
            switch (index)
            {
                case 0:
                    cs = new ContextState(new State1());
                    StateBox.Background = cs.BoxBackground;
                    StateLabel.Foreground = cs.LabelColor;                
                    break;
                case 1:
                    cs = new ContextState(new State2());
                    StateBox.Background = cs.BoxBackground;
                    StateLabel.Foreground = cs.LabelColor;
                    break;
                case 2:
                    cs = new ContextState(new State3());
                    StateBox.Background = cs.BoxBackground;
                    StateLabel.Foreground = cs.LabelColor;
                    break;
                case 3:
                    cs = new ContextState(new State4());
                    StateBox.Background = cs.BoxBackground;
                    StateLabel.Foreground = cs.LabelColor;
                    break;
            }

            #endregion
        }
    }
}