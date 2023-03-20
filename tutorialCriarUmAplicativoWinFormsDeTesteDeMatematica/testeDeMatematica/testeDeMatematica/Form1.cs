using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testeDeMatematica
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();
        int num_soma1,
            num_soma2;

        int num_subtrai1,
            num_subtrai2;

        int num_multiplica1,
            num_multiplica2;

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        int num_divide1,
            num_divide2;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                // If CheckTheAnswer() returns true, then the user 
                // got the answer right. Stop the timer  
                // and show a MessageBox.
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                                "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                // If CheckTheAnswer() returns false, keep counting
                // down. Decrease the time left by one second and 
                // display the new time left by updating the 
                // Time Left label.
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
                if(timeLeft<5) timeLabel.BackColor = Color.Red;
            }
            else
            {
                // If the user ran out of time, stop the timer, show
                // a MessageBox, and fill in the answers.
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = num_soma1 + num_soma2;
                subtraction.Value = num_subtrai1 - num_subtrai2;
                multiplication.Value = num_multiplica1 * num_multiplica2;
                division.Value = num_divide1 / num_divide2;
                startButton.Enabled = true;
            }
        }

        int timeLeft;

        public void StartTheQuiz()
        {

            num_soma1 = randomizer.Next(51);
            num_soma2 = randomizer.Next(51);
            plusLeftLabel.Text = num_soma1.ToString();
            plusRightLabel.Text = num_soma2.ToString();
            sum.Value = 0;

            num_subtrai1 = randomizer.Next(1, 101);
            num_subtrai2 = randomizer.Next(1, num_subtrai1);
            minusLeftLabel.Text = num_subtrai1.ToString();
            minusRightLabel.Text = num_subtrai2.ToString();
            subtraction.Value = 0;

            num_multiplica1 = randomizer.Next(2, 11);
            num_multiplica2 = randomizer.Next(2, 11);
            timesLeftLabel.Text = num_multiplica1.ToString();
            timesRightLabel.Text = num_multiplica2.ToString();
            multiplication.Value = 0;

            num_divide1 = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            num_divide2 = num_divide1 * temporaryQuotient;
            dividLeftLabel.Text = num_divide2.ToString();
            dividRightLabel.Text = num_divide1.ToString();
            division.Value = 0;

            // Start the timer.
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();

        }

        private bool CheckTheAnswer()
        {
            if ((num_soma1 + num_soma2 == sum.Value)
                && (num_subtrai1 - num_subtrai2 == subtraction.Value)
                && (num_multiplica1 * num_multiplica2 == multiplication.Value)
                && (num_divide2 / num_divide1 == division.Value))
                return true;
            else
                return false;
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

 

        public Form1()
        {
            InitializeComponent();
        }
    }
}
