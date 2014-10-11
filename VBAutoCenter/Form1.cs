/*
 * Cassio Acherman 
 * Student ID - 200267816
 * Rapid Application Development Assignment 1
 * -This application allows the user to calculate the price of a car 
 * with different options, with different prices for each option selected-
 * October 7th, 2014
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VBAutoCenter
{
    public partial class VBAutoCenterForm : Form
    {
        //declaring CONSTANTS
        const decimal STEREO_SYSTEM = 425.76m;
        const decimal LEATHER_INTERIOR = 987.41m;
        const decimal COMPUTER_NAVIGATION = 1741.23m;
        const decimal PEARLIZED = 345.72m;
        const decimal CUSTOMIZED_DETAILING = 599.99m;
       

       
        public VBAutoCenterForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //exit the application
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            //this label is just a text
        }

        private void VBAutoCenterForm_Load(object sender, EventArgs e)
        {
            //this is just the form

            //loading form with requested standard values
            standardRadioButton.Checked = true;
            accessoriesTextBox.Text = "$0.00";
            tradeinTextBox.Text = "0.00";
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            //clear all the text boxes
            carSalesPriceTextBox.Clear();
            accessoriesTextBox.Clear();
            subtotalTextBox.Clear();
            salesTaxTextBox.Clear();
            totalTextBox.Clear();
            tradeinTextBox.Clear();
            amountDueTextBox.Clear();

            //bring the cursor to the Car Sales Price text box
            carSalesPriceTextBox.Focus();

            //loading form with requested standard values
            standardRadioButton.Checked = true;
            accessoriesTextBox.Text = "$0.00";
            tradeinTextBox.Text = "0.00";

        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            /*logic of the calculation button:
             * carSalesPrice + accessories = subtotal
             * subtotal * tax = totalCarPrice 
             * totalCarPrice - tradeIn = amountDue
             * 
             * this will calculate the total price of the car with tax and trad-in values
             */

            //declarin local variables
            decimal carSalesPriceDecimal, subTotalDecimal,
                totalCarPriceDecimal, tradeInDecimal, amountDueDecimal, salesTaxDecimal;

            //I had to assign to default value so the compiler can compile the program
            // Im not sure why it was giving me error.
            decimal accessoriesDecimal = 0.0m;

            decimal accessoriesTotalDecimal = 0.0m;
            //declare local constant
            const decimal TAX_RATE = 0.15m;

            //calculation and input validation starts here
            if (carSalesPriceTextBox.Text == "")
            {
                MessageBox.Show("Must add a Value for the Car Price", "Data Entry Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                carSalesPriceTextBox.SelectAll();
                carSalesPriceTextBox.Focus();
            }
            else
            {
                //validate car price input
                try
                {
                    carSalesPriceDecimal = decimal.Parse(carSalesPriceTextBox.Text);
                    if (carSalesPriceDecimal <= 0)
                    {
                       MessageBox.Show("The Price must be positive value", "Data Entry Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                        carSalesPriceTextBox.SelectAll();
                        carSalesPriceTextBox.Focus();
                    }
                    else
                    {
                        //validate trade-in value input
                        try
                        {
                            tradeInDecimal = decimal.Parse(tradeinTextBox.Text);
                            if (tradeInDecimal < 0)
                            {
                                MessageBox.Show("The Trade-in Value must be positive", "Data entry Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                tradeinTextBox.SelectAll();
                                tradeinTextBox.Focus();
                            }
                            else
                            {
                                //calculation the check buttons
                                if (computerNavigationCheckBox.Checked == true)
                                {
                                    accessoriesDecimal += COMPUTER_NAVIGATION;
                                }
                                if ( leatherInteriorCheckBox.Checked == true)
                                {
                                    accessoriesDecimal += LEATHER_INTERIOR;
                                }
                                if (stereoSystemcheckBox.Checked == true)
                                {
                                    accessoriesDecimal += STEREO_SYSTEM;
                                }

                               
                                //calculating the radio butons
                                if (pearlizedRadioButton.Checked == true)
                                {
                                    accessoriesDecimal += PEARLIZED;
                                }
                                if (customizedRadioButton.Checked == true)
                                {
                                    accessoriesDecimal += CUSTOMIZED_DETAILING;
                                }
                                accessoriesTotalDecimal = accessoriesDecimal;

                                accessoriesTextBox.Text = accessoriesTotalDecimal.ToString();


                                //after checkin all 2 inputs do the calculation
                                subTotalDecimal = carSalesPriceDecimal + accessoriesDecimal;
                                salesTaxDecimal = subTotalDecimal * TAX_RATE;
                                totalCarPriceDecimal = subTotalDecimal + salesTaxDecimal;
                                amountDueDecimal = totalCarPriceDecimal - tradeInDecimal;

                                //display the values
                                //accessories - im not sure how to solve this one
                                subtotalTextBox.Text = subTotalDecimal.ToString("C");
                                salesTaxTextBox.Text = salesTaxDecimal.ToString("C");
                                totalTextBox.Text = totalCarPriceDecimal.ToString("C");
                                amountDueTextBox.Text = amountDueDecimal.ToString("C");
                            }
                        }

                        catch (FormatException tradeInException)
                        {
                            MessageBox.Show("The Trade-In Price must be numeric", "Data Entry Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tradeinTextBox.SelectAll();
                            //bring the focus back to the box
                            tradeinTextBox.Focus();
                        }
                        catch (Exception ex1)
                        {
                            MessageBox.Show(ex1.Message);
                        }
                    }
                }
                 catch (FormatException carPriceException)
                {
                    MessageBox.Show("The Car price must be numeric", "Data Entry Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    carSalesPriceTextBox.SelectAll();
                    //bring the focus back to the box
                    carSalesPriceTextBox.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }  
            }//end of the first else
        }//end of calculate button
    }
}
