<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Multi-Step Registration</title>
    <style>
        body {
            font-family: Arial, sans-serif;
        }

        .container {
            max-width: 400px;
            margin: 0 auto;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        h2 {
            text-align: center;
        }

        label {
            display: block;
            margin-bottom: 5px;
        }

        input[type="text"],
        input[type="password"],
        textarea,
        select {
            width: 95%;
            padding: 10px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 3px;
        }

        .error {
            color: #FF0000;
            font-size: 12px;
            margin-top: -10px;
            margin-bottom: 10px;
        }

        .btn-container {
            text-align: center;
            margin-top: 20px;
        }

        input[type="submit"] {
            padding: 10px 20px;
            background-color: #007BFF;
            color: #fff;
            border: none;
            border-radius: 3px;
            cursor: pointer;
        }

            input[type="submit"]:hover {
                background-color: #0056b3;
            }

            .error
            {
                color: red;
                font-size: 16px
            }
    </style>
</head>
<body>
    <div class="container">
        <h2>Multi-Step Registration</h2>
        <form id="registrationForm" runat="server">
            <asp:Panel ID="pnlStep1" runat="server" CssClass="step">
                <h2>Step 1: Personal Information</h2>
                <label for="txtFullName">Full Name:</label>
                <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control"></asp:TextBox>
              
                <label for="ddlAddress" style="margin-top: 10px">Address:</label>
                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" Rows="5" TextMode="MultiLine" ></asp:TextBox>
              
                <asp:DropDownList ID="ddlAddressCountry" runat="server" CssClass="form-control" style="margin-top: 10px">
                    <asp:ListItem Text="Select a country" Value=""></asp:ListItem>
                    <asp:ListItem Text="USA" Value="USA"></asp:ListItem>
                    <asp:ListItem Text="Italy" Value="Italy"></asp:ListItem>
                    <asp:ListItem Text="Egypt" Value="Egypt"></asp:ListItem>
                </asp:DropDownList>
            </asp:Panel>

            <asp:Panel ID="pnlStep2" runat="server" CssClass="step">
                <h2>Step 2: Account Setup</h2>
                <label for="txtUsername">Username:</label>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>

                <label for="txtPassword">Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>

                <label for="txtConfirmPassword">Confirm Password:</label>
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
          
            </asp:Panel>

            <asp:Panel ID="pnlStep3" runat="server" CssClass="step">
                <h2>Step 3: Confirmation</h2>
                <div>
                    <strong>Full Name:</strong> <span id="confirmFullName" runat="server"></span>
                    <br />
                    <strong>Address:</strong> <span id="confirmAddress" runat="server"></span>
                    <br />
                    <strong>Username:</strong> <span id="confirmUsername" runat="server"></span>
                    <br />
                </div>
            </asp:Panel>


            <div class="btn-container">
                <asp:Button id="btnPrevious" runat="server" class="step" Text="Previous" OnClick="btnPrevious_Click" />
                <asp:Button id="btnNext" runat="server" class="step" Text="Next" OnClick="btnNext_Click"  />
                <asp:Button id="btnSubmit" runat="server" class="step" Text="Submit" OnClick="btnSubmit_Click"  />
            </div>

            <asp:Label ID="lblValidation" runat="server" class="error"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblProgress" runat="server" class="step"></asp:Label>
        </form>
    </div>
</body>
</html>

