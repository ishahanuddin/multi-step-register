using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        bool isError = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblValidation.Text = "";

            if (!IsPostBack)
            {
                // Initialize the form on the first load
                pnlStep1.Visible = true;
                pnlStep2.Visible = false;
                pnlStep3.Visible = false;
                btnPrevious.Visible = false;
                btnNext.Visible = true;
                btnSubmit.Visible = false;
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (pnlStep1.Visible)
            {
                if (IsValidStep1())
                {
                    pnlStep1.Visible = false;
                    pnlStep2.Visible = true;
                    btnPrevious.Visible = true;
                    lblProgress.Text = "Step 2 of 3";
                }
            }
            else if (pnlStep2.Visible)
            {
                if (IsValidStep2())
                {
                    pnlStep2.Visible = false;
                    pnlStep3.Visible = true;
                    btnNext.Visible = false;
                    btnSubmit.Visible = true;
                    lblProgress.Text = "Step 3 of 3";
                    DisplayConfirmation();
                }
            }
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            if (pnlStep2.Visible)
            {
                pnlStep2.Visible = false;
                pnlStep1.Visible = true;
                btnPrevious.Visible = false;
                lblProgress.Text = "Step 1 of 3";
            }
            else if (pnlStep3.Visible)
            {
                pnlStep3.Visible = false;
                pnlStep2.Visible = true;
                btnNext.Visible = true;
                btnSubmit.Visible = false;
                lblProgress.Text = "Step 2 of 3";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Perform registration and save data
            string fullName = txtFullName.Text;
            Session["name"] = fullName;

            // Redirect to a welcome page
            Response.Redirect("welcome.aspx");
        }

        private bool IsValidStep1()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) || !Regex.IsMatch(txtFullName.Text, @"^(\s+)?\w+\s+\w+(\s+)?"))
            {
                ShowValidationError("Please enter a valid full name with at least two words.");
                isError = true;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text) || txtAddress.Text.Length < 10)
            {
                ShowValidationError("Please enter address that have more than 10 characters.");
                isError = true;
            }

            if (string.IsNullOrWhiteSpace(ddlAddressCountry.SelectedValue))
            {
                ShowValidationError("Please select a country.");
                isError = true;
            }

            if (isError)
                return false;
            
            HideValidationError();
            return true;
        }

        private bool IsValidStep2()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || txtUsername.Text.Length < 6 || !IsAlphaNumeric(txtUsername.Text))
            {
                ShowValidationError("Please enter a valid username with at least 6 alphanumeric characters.");
                isError = true;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text.Length < 8 || !HasMixedCharacters(txtPassword.Text))
            {
                ShowValidationError("Please enter a valid password with at least 8 characters, including letters, numbers, and special characters.");
                isError = true;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                ShowValidationError("Passwords do not match.");
                isError = true;
            }

            if (isError)
                return false;

            HideValidationError();
            return true;
        }

        private bool IsAlphaNumeric(string input)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(input, "^[a-zA-Z0-9]+$");
        }

        private bool HasMixedCharacters(string input)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(input, "(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^a-zA-Z\\d]).+");
        }

        private void ShowValidationError(string message)
        {
            lblValidation.Text = lblValidation.Text + "<br> - " + message;
        }

        private void HideValidationError()
        {
            lblValidation.Text = "";
        }

        private void DisplayConfirmation()
        {
            confirmFullName.InnerText = txtFullName.Text;
            confirmAddress.InnerText = txtAddress.Text + ", " + ddlAddressCountry.SelectedValue;
            confirmUsername.InnerText = txtUsername.Text;
        }
    }
}
