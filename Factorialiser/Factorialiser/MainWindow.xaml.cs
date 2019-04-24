using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Factorialiser.Classes;

namespace Factorialiser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public MainWindow()
        {
            InitializeComponent();
        }      

        private void buttonCalculate_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {

                // check if textboxInput.Text is empty (or only contains white space), 
                // if this is the case then throw a NullValueException
                if (textBoxInput.Text == "")
                {
                    throw new NullValueException();
                }

                //declare a variable here called input or datatype int
                int input;              


//----------------------------------------------

                try
                {
                    // try and parse the text input into textboxInput into an integer and assign it to input
                    input = int.Parse(textBoxInput.Text);

                    // log a Debug level log event here with the message "MainForm.buttonCalculate_Click: input successfully parsed"
                    logger.Debug("MainForm.buttonCalculate_Click: input successfully parsed");

                }
                catch (FormatException)
                {
                    // log a Debug level log event here with the message "MainForm.buttonCalculate_Click: input parse failed"
                    logger.Debug("MainForm.buttonCalculate_Click: input parse failed");
                    // throw a NotIntegerException 
                    MessageBox.Show("Not Integer entered! Please type any number");
                    throw new NotIntegerException("Not Integer Entered displayed");
                   
                }


                // pass the input to the Calculator.Factorial method and store the retuen value in a variable
                var result = Calculator.Factorial(input);

                // log a Debug level log event here with the message "MainForm.buttonCalculate_Click: Calculate.Factorial suceeded"
                logger.Debug("MainForm.buttonCalculate_Click: Calculate.Factorial suceeded");

                // change the text of labelOutput to reflect
                labelOutput.Content = result.ToString();
                textBoxInput.Clear();
                
                // log a Debug level log event here with the message "MainForm.buttonCalculate_Click: labelOutput successfully updated"
                logger.Debug("MainForm.buttonCalculate_Click: labelOutput successfully updated");
                

            }
            catch (NullValueException n) 
            {
                // clear the labelOutput text and the textboxInput.Text
                textBoxInput.Clear();
                labelOutput.Content = "";
                // present a message box saying ("Nothing Entered - Please enter an integer")
                MessageBox.Show("Nothing Entered - Please enter an integer");
                // log the event as an Error Level log  
                // with the message "MainForm.buttonCalculate_Click: NullValueException message displayed"
                logger.Error("MainForm.buttonCalculate_Click: NullValueException message displayed");       
               

            }
            // ###########
            // add additional catches here, one for each of your custom exception types, in each one
            // clear the labelOutput text and the textboxInput.Text
            // display an approprate message box message and log the event as an Error level
            // using the same format as used in the NullValueException catch
            // ##########
            catch (NumberTooLowException)
            {
                logger.Error("Number entered too low exception displayed");
                textBoxInput.Clear();
                labelOutput.Content = "";
                MessageBox.Show("Please enter a number greater than 0");
                
            }
            catch(NumberTooHighException)
            {
                logger.Error("Number entered too high exception displayed");
                textBoxInput.Clear();
                labelOutput.Content = "";
                MessageBox.Show("Please enter a number lower than 30");
            }

            catch (Exception ex)
            {
                // clear the labelOutput text and the textboxInput.Text
                textBoxInput.Clear();
                labelOutput.Content = "";
                // present a message box saying ("Unknown Error")
                MessageBox.Show("Unknow Error");
                // log the event as an Fatal Level log 
                // with the message ("MainForm.buttonCalculate_Click: Unknown Error : " + ex.message)
                logger.Fatal("MainForm.buttonCalculate_Click: Unknown Error : " + ex.Message);                
               
            }


        }

        private void TextBoxInput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
