using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SpeechToText_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SpeechRecognitionEngine recognizere = new SpeechRecognitionEngine();
            recognizere.SetInputToDefaultAudioDevice();
            Grammar grammar = new DictationGrammar();
            recognizere.LoadGrammar(grammar);
            recognizere.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
            recognizere.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            richTextBox1.Text += e.Result.Text + "\r\n";
        }
    }
}
